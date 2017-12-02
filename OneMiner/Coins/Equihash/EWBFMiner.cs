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

namespace OneMiner.Coins.Equihash
{
    /// <summary>
    /// this class does not represent a miner program. coz this contains specif info like batfilepath etc
    /// this represents a miner program inside a configured miner. there could be many miners of the same type. eg ethereum, ethereum_sia
    /// for the real representation fo a miner program, look at JsonData.MinerProgram
    /// </summary>
    class ClaymoreMiner : MinerProgramBase
    {

        public override string MINERURL
        {
            get
            {
                return "https://github.com/nanopool/Claymore-Dual-Miner/releases/download/v10.0/Claymore.s.Dual.Ethereum.Decred_Siacoin_Lbry_Pascal.AMD.NVIDIA.GPU.Miner.v10.0.zip";
            }
        }
        public override string EXENAME
        {
            get
            {
                return "EthDcrMiner64.exe";
            }
        }
        public override string PROCESSNAME
        {
            get
            {
                return "EthDcrMiner64";
            }
        }
        public override string STATS_LINK
        {
            get
            {
                return "http://127.0.0.1:3333/";
            }
        }


        public override string Script { get; set; }


        public override string Type { get; set; }//claymore ccminer etc

        public override IOutputReader OutputReader { get; set; }


        public ClaymoreMiner(ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName, IMiner miner) :
            base(mainCoin, dualMining, dualCoin, minerName, miner)
        {
            Type = "Claymore";
            OutputReader = new ClayMoreReader(STATS_LINK);
        }



        public override string GenerateScript()
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
                command += " -allpools 1";


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
        class ClayMoreReader : IOutputReader
        {
            private const int MAX_QUEUESIZE = 5;

            private object s_accesssynch = new object();
            private object s_resultSynch = new object();
            public string StatsLink { get; set; }
            private string m_Lastlog = "";
            //if true, next time we parse outputs, we will try to read the gpu names again. will reset when new object is made and miner is started
            public bool ReReadGpuNames { get; set; }
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
                            m_Lastlog = value;
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
                ReReadGpuNames = true;
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
                    if (resultmatch.Success)
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
                MinerDataResult minerResult = GetResultsSection(LastLog);
                if (minerResult.Parse(new EtherClaymoreResultParser(LastLog, ReReadGpuNames)))
                {
                    MinerResult = minerResult;
                }
                ReReadGpuNames = false;
            }

            public class EtherClaymoreResultParser : IMinerResultParser
            {
                MinerDataResult m_MinerResult = null;
                public bool Succeeded { get; set; }//if parsing succeeded without errors
                static Hashtable m_Gpus = new Hashtable();// we only need t read gpu info once as it dosent change with more logs comining in
                static bool m_identified = false;
                bool m_reReadGpunames = false;

                string m_fullLog = "";
                public EtherClaymoreResultParser(string fullLog, bool reReadGpunames)
                {
                    m_fullLog = fullLog;
                    m_reReadGpunames = reReadGpunames;
                }

                public bool Parse(MinerDataResult obj)
                {
                    Succeeded = false;

                    m_MinerResult = obj;
                    try
                    {
                        if (obj == null)
                            return false;

                        if (!m_identified || m_reReadGpunames)
                        {
                            m_identified = false;
                            m_Gpus.Clear();
                            IdentifyGPUs();
                        }
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
                    catch (Exception)
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
                        string[] data = combined.Split(';');
                        if (data != null && data.Length == 3)
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
                                GpuData gpu = null;
                                string gpu_idstr = gpu_id.ToString();
                                gpu = m_Gpus[gpu_idstr] as GpuData;
                                if (gpu == null)
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
                                m_reReadGpunames = false;//we dont need to read until told 

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
                                if (!string.IsNullOrEmpty(gpu_id) && !string.IsNullOrEmpty(gpu_name))
                                {
                                    //check if there is an item alredy
                                    object oldItem = m_Gpus[gpu_id];
                                    if (oldItem == null)
                                    {
                                        GpuData gpu = new GpuData(gpu_name);
                                        gpu.IdentifyMake();
                                        m_Gpus[gpu_id] = gpu;
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
