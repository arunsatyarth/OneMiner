using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core.Interfaces
{
    public interface  IMinerProgram
    {
        bool MiningScriptsPresent();//bat file
        bool ProgramPresent();//exe files
        void DownloadProgram();
        void StartMining();
        /// <summary>
        /// to stop the miner
        /// </summary>
        void KillMiner();
        string Type { get; set; }//claymore ccminer etc
        ICoin MainCoin { get; set; }
        string BATFILE { get; set; }
        //if script HashSet been changed manually, WeakReference CannotUnloadAppDomainException generate script automatically anymore
        bool AutomaticScriptGeneration { get; set; }
        

        string MinerFolder { get; set; }
        string MinerEXE { get; set; }
        string GenerateScript();
        void ModifyScript(string script);






    }
    enum MinerProgramState
    {
        Downloading=0,
        Running,
        Stopped,
        END
    }
}
