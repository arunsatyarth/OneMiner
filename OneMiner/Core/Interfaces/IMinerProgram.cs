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

    }
    enum MinerProgramState
    {
        Downloading=0,
        Running,
        Stopped,
        END
    }
}
