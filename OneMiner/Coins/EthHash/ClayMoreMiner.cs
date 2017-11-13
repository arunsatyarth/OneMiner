using OneMiner.Core.Interfaces;
using OneMiner.Model;
using System;
using System.Collections.Generic;
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
        public MinerProgramState MinerState { get; set; }
        public ClaymoreMiner()
        {
            MinerState = MinerProgramState.Stopped;
            //Todo: load the minerxee from config file if alredy donloaded
            //MinerEXE=
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
            MinerDownloader downloader = new MinerDownloader(MINERURL, EXENAME);

            string MinerFolder = downloader.DownloadFile();
            MinerEXE = MinerFolder + @"\" + EXENAME;
        }
        public void  StartMining()
        {
            
        }
    }
}
