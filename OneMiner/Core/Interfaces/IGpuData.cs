using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core.Interfaces
{
    public enum CardMake
    {
        Nvidia=0,
        Amd,
        CPU,
        END
    }
    public class GpuData 
    {
        public string Hashrate { get; set; }
        public string FanSpeed { get; set; }
        public string Temperature { get; set; }
        public string GPUName { get; set; }//eg GPU0
        public CardMake Make { get; set; }
        public GpuData(string name)
        {
            Make = CardMake.END;
            GPUName = name;
        }


    }
    public class MinerDataResult
    {
        public List<string> result { get; set; }
        public int TotalHashrate { get; set; }
        public int TotalShares { get; set; }
        public int Rejected { get; set; }
        public int RunningTime { get; set; }
        public List<GpuData> GPUs { get; set; }
        //this class does not know how to parse the results as different miners have data in different formats
        //So it accepts a visitor which can do it
        public bool Parse(IMinerResultParser parser)
        {
            return parser.Parse(this);
        }
    }
    /// <summary>
    /// different miners can implement different logic for parsing and filling the data
    /// </summary>
    public interface IMinerResultParser
    {
        bool Parse(MinerDataResult obj);
    }
}
