using OneMiner.Core.Interfaces;
using OneMiner.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMiner.Coins.EthHash
{
    class ClaymoreMiner:IMinerProgram
    {

        private const string MINERURL = "https://github.com/nanopool/Claymore-Dual-Miner/releases/download/v10.0/Claymore.s.Dual.Ethereum.Decred_Siacoin_Lbry_Pascal.AMD.NVIDIA.GPU.Miner.v10.0.zip";
        private const string EXENAME = "EthDcrMiner64.exe";
        public  string Script { get; set; }
        public IOutputReader Reader { get; set; }

        public string MinerFolder { get; set; }
        public string MinerEXE { get; set; }
        private string BATFILE  { get; set; }

        public MinerProgramState MinerState { get; set; }

        public ICoin MainCoin { get; set; }
        public ICoin DualCoin { get; set; }

        public ICoinConfigurer MainCoinConfigurer { get; set; }
        public ICoinConfigurer DualCoinConfigurer { get; set; }
        public bool DualMining { get; set; }
        public string Name { get; set; }

        public ClaymoreMiner(ICoin mainCoin, ICoinConfigurer mainCoinConfigurer, bool dualMining, ICoin dualCoin,
            ICoinConfigurer dualCoinConfigurer, string minerName)
        {

            MinerState = MinerProgramState.Stopped;
            //Todo: load the minerxee from config file if alredy donloaded


            MainCoin = mainCoin;
            MainCoinConfigurer = mainCoinConfigurer;
            DualCoin = dualCoin;
            DualCoinConfigurer = dualCoinConfigurer;
            DualMining = dualMining;
            Name = minerName;

        }

        public bool ProgramPresent()
        {
            if (MinerEXE != "")
                return false;
            FileInfo miner = new FileInfo(MinerEXE);
            if (miner.Exists)
                return true;
            return false;
        }
        public  void DownloadProgram()
        {
            MinerState = MinerProgramState.Downloading;
            MinerDownloader downloader = new MinerDownloader(MINERURL, EXENAME);

            string MinerFolder = downloader.DownloadFile();
            MinerEXE = MinerFolder + @"\" + EXENAME;
            BATFILE = MinerFolder + @"\" + Name+".bat";

            ConfigureMiner();
            MinerState = MinerProgramState.Stopped;

        }

        public void  StartMining()
        {
            MinerState = MinerProgramState.Running;
            ProcessStartInfo info = new ProcessStartInfo();
            info.UseShellExecute = false;
            info.FileName = BATFILE;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            //objStartInfo.WorkingDirectory = WorkingDirectory + "\\";

            Process objProcess = new Process();
            objProcess.StartInfo = info;
            objProcess.Start();
            objProcess.WaitForExit();


            MinerState = MinerProgramState.Stopped;

        }

        private void GenerateScript()
        {
            try
            {
                //generate script and write to folder
                string command = EXENAME + " -epool " + MainCoinConfigurer.Pool;
                command += " -ewal " + MainCoinConfigurer.Wallet;
                command += " -epsw x ";
                if(DualCoin!=null)
                {
                    command += " -dpool " + DualCoinConfigurer.Pool;
                    command += " -dwal " + MainCoinConfigurer.Wallet;
                    command += " -ftime 10 ";

                }

                Script = SCRIPT1+command;
            }
            catch (Exception e)
            {
            }
        }
        private void ConfigureMiner()
        {
            try
            {
                GenerateScript();
                FileStream stream=File.Open(BATFILE,FileMode.Create);
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



        private const string SCRIPT1 = @"setx GPU_FORCE_64BIT_PTR 0\n
                setx GPU_MAX_HEAP_SIZE 100\n
                setx GPU_USE_SYNC_OBJECTS 1\n
                setx GPU_MAX_ALLOC_PERCENT 100\n
                setx GPU_SINGLE_ALLOC_PERCENT 100\n";

    }
}
