using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core.Interfaces
{
    public interface  IMinerProgram
    {
        bool ProgramPresent();
        void DownloadProgram();
        void StartMining();
        /// <summary>
        /// to stop the miner
        /// </summary>
        void KillMiner();

    }
    enum MinerProgramState
    {
        Downloading=0,
        Running,
        Stopped,
        END
    }
}
