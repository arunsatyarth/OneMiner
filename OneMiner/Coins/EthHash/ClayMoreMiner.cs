using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Coins.EthHash
{
    class ClaymoreMiner:IMinerProgram
    {
        private const string MINERURL = "https://github.com/nanopool/Claymore-Dual-Miner/releases/download/v10.0/Claymore.s.Dual.Ethereum.Decred_Siacoin_Lbry_Pascal.AMD.NVIDIA.GPU.Miner.v10.0.zip";
        public  string Script { get; set; }
        public IOutputReader Reader { get; set; }
        public bool ProgramPresent()
        {
            return false;
        }
        private void DownloadProgram()
        {
            //Todo: 
            //use the downloader to download
            //unzip the files
            //tell where the exe is
        }
        public void  StartMining()
        {
            
        }
    }
}
