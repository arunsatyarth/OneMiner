using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model;
using OneMiner.Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace OneMiner.Coins.EthHash
{
    /// <summary>
    /// this class does not represent a miner program. coz this contains specif info like batfilepath etc
    /// this represents a miner program inside a configured miner. there could be many miners of the same type. eg ethereum, ethereum_sia
    /// for the real representation fo a miner program, look at JsonData.MinerProgram
    /// </summary>
    class ClaymoreMiner : IMinerProgram
    {

        private const string MINERURL = "https://github.com/nanopool/Claymore-Dual-Miner/releases/download/v10.0/Claymore.s.Dual.Ethereum.Decred_Siacoin_Lbry_Pascal.AMD.NVIDIA.GPU.Miner.v10.0.zip";
        private const string EXENAME = "EthDcrMiner64.exe";
        private const string PROCESSNAME = "EthDcrMiner64";
        //private const string STATS_LINK = "http://127.0.0.1:3000/";//This is for zcash claymore
        private const string STATS_LINK = "http://127.0.0.1:3333/";

        public string Script { get; set; }
        public IOutputReader Reader { get; set; }

        public string MinerFolder { get; set; }
        public string MinerEXE { get; set; }
        public string BATFILE { get; set; }
        public bool BATCopied { get; set; }

        public bool AutomaticScriptGeneration { get; set; }


        public MinerProgramState MinerState { get; set; }

        public IMiner Miner { get; set; }
        public ICoin MainCoin { get; set; }
        public ICoin DualCoin { get; set; }

        public ICoinConfigurer MainCoinConfigurer { get; set; }
        public ICoinConfigurer DualCoinConfigurer { get; set; }
        public bool DualMining { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }//claymore ccminer etc
        MinerDownloader m_downloader = null;
        private Process m_Process = null;
        private object m_accesssynch = new object();
        public IOutputReader OutputReader { get; set; }



        public ClaymoreMiner(ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName, IMiner miner)
        {

            MinerState = MinerProgramState.Stopped;

            MainCoin = mainCoin;
            MainCoinConfigurer = mainCoin.SettingsScreen;
            DualCoin = dualCoin;
            if (DualCoin != null)
                DualCoinConfigurer = DualCoin.SettingsScreen;
            DualMining = dualMining;
            Name = minerName;
            Miner = miner;
            AutomaticScriptGeneration = true;
            Type = "Claymore";
            m_downloader = new MinerDownloader(MINERURL, EXENAME);
            OutputReader = new ClayMoreReader(STATS_LINK);

            GenerateScript();

        }



        public bool ReadyForMining()
        {
            return MiningScriptsPresent() && ProgramPresent() && BATCopied;
        }
        public bool MiningScriptsPresent()
        {
            if (BATFILE == null || BATFILE == "")
                return false;
            FileInfo script = new FileInfo(BATFILE);
            if (script.Exists)
                return true;
            return ProgramPresent();
        }
        public bool ProgramPresent()
        {
            if (MinerEXE == null || MinerEXE == "")
                return false;
            FileInfo miner = new FileInfo(MinerEXE);
            if (miner.Exists)
                return true;
            return false;
        }
        public void SaveProgramToDB()
        {
            if (ProgramPresent())
            {
                Config model = Factory.Instance.Model;
                model.AddMinerProgram(this);

            }
        }
        public void SaveScriptToDB()
        {
            if (MiningScriptsPresent())
            {
                Config model = Factory.Instance.Model;
                model.AddMinerScript(this, Miner);

            }
        }

        public string FormBatFileName(string folder)
        {
            return folder + @"\" + Miner.Name + ".bat";
        }
        public void DownloadProgram()
        {
            try
            {
                if (!ProgramPresent())
                {
                    MinerState = MinerProgramState.Downloading;
                    Miner.SetRunningState(this, MinerState);

                    MinerFolder = m_downloader.DownloadFile();
                    MinerEXE = MinerFolder + @"\" + EXENAME;
                    SaveProgramToDB();

                }
                string actualBatfileName = FormBatFileName(MinerFolder);

                if (AutomaticScriptGeneration == false)
                {
                    //this might be becoz user has edited the bat file
                    FileInfo file = new FileInfo(BATFILE);
                    if (file.Exists)
                    {
                        file.CopyTo(actualBatfileName, true);
                    }
                }
                BATFILE = actualBatfileName;
                ConfigureMiner();
                BATCopied = true;
                SaveScriptToDB();
                MinerState = MinerProgramState.Stopped;
            }
            catch (Exception e)
            {
                Logger.Instance.LogError(e.Message);
            }
        }

        public void StartMining()
        {
            //lock ensures that neither can someone kill a miner while it is being started, nor can 2 people start it at same time
            lock (m_accesssynch)
            {
                try
                {
                    FileInfo file = new FileInfo(BATFILE);
                    if (Factory.Instance.CoreObject.MiningCommand!=MinerProgramCommand.Run)
                    {
                        throw new Exception("Mining command is not 'Run'");
                    }
                    if (m_Process != null)
                    {
                        throw new Exception("Process object is not null while starting");
                    }
                    if (file.Exists)
                    {
                        MinerState = MinerProgramState.Running;
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.UseShellExecute = false;
                        //Todo: Enable this when we have feature to configure the settings
                        //info.CreateNoWindow = ! Factory.Instance.Model.Data.Option.ShowMinerWindows;
                        info.FileName = BATFILE;
                        info.WindowStyle = ProcessWindowStyle.Hidden;
                        info.WorkingDirectory = file.DirectoryName + "\\";

                        m_Process = new Process();
                        m_Process.StartInfo = info;
                        bool success = m_Process.Start();
                        if (success)
                        {
                            MinerState = MinerProgramState.Running;
                            Miner.SetRunningState(this, MinerProgramState.Running);
                            Alarm.RegisterForTimer(OutputReader.AlarmRaised);
                        }

                    }

                }
                catch (Exception e)
                {
                    Logger.Instance.LogError(e.ToString());
                }
                finally
                {
                    //MinerState = MinerProgramState.Stopped;
                }
            }
        }
        public void SetRunningState(MinerProgramState state)
        {
            lock (m_accesssynch)
            {
                try
                {
                    MinerState = state;
                    Miner.SetRunningState(this, state);
                }
                catch (Exception e)
                {
                }
            }
        }
        public void KillMiner()
        {
            lock (m_accesssynch)
            {
                try
                {
                    if (m_Process != null)
                    {
                        try
                        {
                            //this actually dos4nt work as we get handle to command prompt used by the miner as its a batch file
                            m_Process.Kill();
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                        }
                    }
                    Process[] allprocess = Process.GetProcessesByName(PROCESSNAME);//this does the job
                    if (allprocess != null && allprocess.Length > 0)
                    {
                        foreach (Process item in allprocess)
                        {
                            item.Kill();
                        }
                    }
                    m_Process = null;
                    MinerState = MinerProgramState.Stopped;
                    Miner.SetRunningState(this, MinerState);

                }
                catch (Exception e)
                {
                    Logger.Instance.LogError(e.ToString());
                }
            }
        }

        public bool Running()
        {
            bool running = false;
            try
            {
                running = !m_Process.HasExited;
            }
            catch (Exception e)
            {
                running = false;
            }
            return running;
        }



        public string GenerateScript()
        {
            try
            {
                //generate script and write to folder
                string command = EXENAME + " -epool " + MainCoinConfigurer.Pool;
                command += " -ewal " + MainCoinConfigurer.Wallet;
                command += " -epsw x ";
                if (DualCoin != null)
                {
                    command += " -dpool " + DualCoinConfigurer.Pool;
                    command += " -dwal " + MainCoinConfigurer.Wallet;
                    command += " -ftime 10 ";

                }

                Script = SCRIPT1 + command;
                AutomaticScriptGeneration = true;
                SaveScriptToDB();
                return Script;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public void ModifyScript(string script)
        {
            Script = script;
            string tempBatFile = "";
            string tempBatFileFolder = "";
            if (MinerFolder != null && MinerFolder != "")
                tempBatFileFolder = MinerFolder;
            else
                tempBatFileFolder = m_downloader.GetTempBatFile(Miner.Id, Type, Miner.Name);
            tempBatFile = FormBatFileName(tempBatFileFolder);

            if (tempBatFile != "")
            {
                BATFILE = tempBatFile;
                SaveToBAtFile();
                AutomaticScriptGeneration = false;
                SaveScriptToDB();
            }
        }
        private void ConfigureMiner()
        {
            try
            {
                if (AutomaticScriptGeneration == false)
                    return;

                GenerateScript();
                SaveToBAtFile();

            }
            catch (Exception e)
            {
            }
        }
        private void SaveToBAtFile()
        {
            try
            {
                FileStream stream = File.Open(BATFILE, FileMode.Create);
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(Script);
                sw.Flush();
                sw.Close();
                //generate script and write to folder

            }
            catch (Exception e)
            {
            }
        }
        public void LoadScript()
        {
            try
            {
                if (AutomaticScriptGeneration)
                {
                    GenerateScript();
                }
                else
                {
                    FileStream stream = File.Open(BATFILE, FileMode.Open);
                    StreamReader sr = new StreamReader(stream);
                    Script = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception e)
            {
            }
        }



        private const string SCRIPT1 =
@"setx GPU_FORCE_64BIT_PTR 0
setx GPU_MAX_HEAP_SIZE 100
setx GPU_USE_SYNC_OBJECTS 1
setx GPU_MAX_ALLOC_PERCENT 100
setx GPU_SINGLE_ALLOC_PERCENT 100
";



        /// <summary>
        /// reads data for claymore miner
        /// </summary>
        class ClayMoreReader:IOutputReader
        {
            private const int MAX_QUEUESIZE = 5;

            private object s_accesssynch = new object();
            private object s_resultSynch = new object();
            public string StatsLink { get; set; }
            private string m_Lastlog = "";
            //if true, next time we parse outputs, we will try to read the gpu names again. will reset when new object is made and miner is started
            private bool ReREadGpuNames { get; set; }
            public Queue<string> m_AllLogs = new Queue<string>();
            MinerDataResult m_Result = new MinerDataResult();
            public MinerDataResult MinerResult
            {
                get
                {
                    lock (s_resultSynch)
                    {
                        try
                        {
                            return m_Result;
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                            return null;
                        }
                    }
                }
                set
                {
                    lock (s_resultSynch)
                    {
                        try
                        {
                            m_Result = value;
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                            m_Lastlog = null;
                        }
                    }
                }
            }
            public string LastLog
            {
                get
                {
                    lock (s_accesssynch)
                    {
                        try
                        {
                            return m_Lastlog;
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                            return "";
                        }
                    }
                }            
                set
                {
                    lock (s_accesssynch)
                    {
                        try
                        {
                            m_Lastlog=value;
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                            m_Lastlog = "";
                        }
                    }
                }
            }
            public string NextLog
            {
                get
                {
                    lock (s_accesssynch)
                    {
                        try
                        {
                            return m_AllLogs.Dequeue();
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                            return "";
                        }
                    }
                }
                set
                {
                    lock (s_accesssynch)
                    {
                        try
                        {
                            if (value != null && value != "")
                            {
                                LastLog = value;
                                m_AllLogs.Enqueue(value);
                                if (m_AllLogs.Count >= MAX_QUEUESIZE)//if consumer is slower than producer, then we need to remove old vals
                                    m_AllLogs.Dequeue();
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Instance.LogError(e.ToString());
                        }
                    }
                }
            }

            public ClayMoreReader(string link)
            {
                StatsLink = link;
                m_reReadGpunames = true;
            }
            public void Read()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StatsLink);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
                request.Accept = "/";
                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //doc.Save(request.GetRequestStream());
                HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string s = sr.ReadToEnd();
                NextLog = s;
            }
    
            public void AlarmRaised()
            {
                try
                {
                    Read();
                    Parse();
                }
                catch (Exception e)
                {
                }
              
            }
            MinerDataResult GetResultsSection(string innerText)
            {
                try
                {
                    //string patternf = @"\{([a-z]|[^a-z])*\}";
                    string pattern = @"\{([^()]|())*\}";
                    Match resultmatch = Regex.Match(innerText, pattern);
                    if(resultmatch.Success)
                    {
                        MinerDataResult minerResult = (MinerDataResult)new JavaScriptSerializer().Deserialize(resultmatch.Value, typeof(MinerDataResult));
                        return minerResult;
                    }
                }
                catch (Exception e)
                {
                }
                return null;
            }
            public void Parse()
            {
                MinerDataResult minerResult =GetResultsSection(LastLog);
                if (minerResult.Parse(new EtherClaymoreResultParser(LastLog)))
                    MinerResult = minerResult;
            }

            public class EtherClaymoreResultParser : IMinerResultParser
            {
                MinerDataResult m_MinerResult = null;
                public bool Succeeded { get; set; }//if parsing succeeded without errors
                Hashtable m_Gpus = new Hashtable();
                bool m_identified = false;
                string m_fullLog = "";
                public EtherClaymoreResultParser(string fullLog)
                {
                    m_fullLog = fullLog;
                }

                public bool Parse(MinerDataResult obj)
                {
                    Succeeded = false;
                    
                    m_MinerResult = obj;
                    try
                    {
                        if (obj == null)
                            return false;
                        if (!m_identified)
                            IdentifyGPUs();
                        if (m_MinerResult.result != null && m_MinerResult.result.Count >= 7)
                        {
                            ComputeRunningTime();
                            ComputeHashnShares();
                            ComputeGPUData();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        Succeeded = false;
                    }
                    return false;
                    
                }
                public void ComputeRunningTime()
                {
                    try
                    {
                        m_MinerResult.RunningTime = Int32.Parse(m_MinerResult.result[1]);
                    }
                    catch (Exception )
                    {
                        m_MinerResult.RunningTime = 0;
                        Succeeded = false;
                        throw;
                    }
                }
                public void ComputeHashnShares()
                {
                    try
                    {
                        string combined = m_MinerResult.result[2];
                        string []data=combined.Split(';');
                        if(data!=null && data.Length==3)
                        {
                            m_MinerResult.TotalHashrate = Int32.Parse(data[0]);//this is in H/s not MH/s UI will have to do conversion
                            m_MinerResult.TotalShares = Int32.Parse(data[1]);
                            m_MinerResult.Rejected = Int32.Parse(data[2]);

                        }
                    }
                    catch (Exception)
                    {
                        m_MinerResult.TotalHashrate = 0;
                        m_MinerResult.TotalShares = 0;
                        m_MinerResult.Rejected = 0;
                        Succeeded = false;
                        throw;
                    }
                }
                public void ComputeGPUData()
                {
                    try
                    {
                        m_MinerResult.GPUs = new List<GpuData>();
                        string hashCombined = m_MinerResult.result[3];
                        string[] hashrates = hashCombined.Split(';');

                        string fanTemp = m_MinerResult.result[6];
                        string[] fanTempArr = fanTemp.Split(';');
                        if (hashrates != null && hashrates.Length > 0)
                        {
                            int j = 0;
                            int gpu_id = 0;
                            foreach (string item in hashrates)
                            {
                                GpuData gpu=null;
                                string gpu_idstr=gpu_id.ToString();
                                gpu = m_Gpus[gpu_idstr] as GpuData;
                                if(gpu==null)
                                    gpu = new GpuData("GPU " + gpu_idstr);

                                gpu.Hashrate = item;
                                gpu.Temperature = fanTempArr[j] + "C";
                                gpu.FanSpeed = fanTempArr[j + 1] + "%";
                                j += 2;
                                gpu_id++;
                                m_MinerResult.GPUs.Add(gpu);
                            }
                        }

                    }
                    catch (Exception)
                    {
                        Succeeded = false;
                        throw;
                    }
                }
                public void IdentifyGPUs()
                {
                    try
                    {
                        //splot onto many lines
                        string[] result = Regex.Split(m_fullLog, "\r\n|\r|\n");
                        string pattern = @"(GPU)(.){2,12}(recognized as)(.)*";

                        foreach (string item in result)
                        {
                            Match r = Regex.Match(item, pattern);
                            string gpu_id = "";
                            string gpu_name = "";
                            if (r.Success)
                            {
                                m_identified = true;

                                string value = r.Value;
                                //ideally i would have used this to find and then separate the gpu number
                                //string pattern_gpuid = @"(#).";

                                //but the following site explains a way to get string affter the match using "positive lookbehind assertion
                                //https://stackoverflow.com/questions/5006716/getting-the-text-that-follows-after-the-regex-match

                                string pattern_gpuid = @"(?<=#).";
                                Match r_gpu_id = Regex.Match(value, pattern_gpuid);
                                if (r_gpu_id.Success)
                                {
                                    gpu_id = r_gpu_id.Value;
                                }

                                string pattern_gpuname = @"(?<=recognized as).*";
                                Match r_gpu_name = Regex.Match(value, pattern_gpuname);
                                if (r_gpu_name.Success)
                                {
                                    gpu_name = r_gpu_name.Value;
                                }
                                if(!string.IsNullOrEmpty(gpu_id) && !string.IsNullOrEmpty(gpu_name))
                                {
                                    //check if there is an item alredy
                                    object oldItem = m_Gpus[gpu_id];
                                    if(oldItem==null)
                                    {
                                        GpuData gpu = new GpuData(gpu_name);
                                        gpu.Make = Make(gpu_name);
                                        gpu.GPUName = gpu_name;
                                        m_Gpus[gpu_id] = gpu_name;
                                    }
                                }

                            }

                        } 


                    }
                    catch (Exception)
                    {
                        Succeeded = false;
                        throw;
                    }
                }
                private CardMake Make(string name)
                {
                    try
                    {
                        string pattern = "(N|n)(V|v)(I|i)(D|d)(I|i)(A|a)";
                        Match r_gpu_id = Regex.Match(name, pattern);
                        if (r_gpu_id.Success)
                            return CardMake.Nvidia;
                        else
                            return CardMake.Amd;
                    }
                    catch (Exception)
                    {
                    }
                    return CardMake.END;
                }

            }
        }
    }

}
