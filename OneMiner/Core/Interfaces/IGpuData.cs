using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OneMiner.Core.Interfaces
{
    public enum CardMake
    {
        Nvidia=0,
        Amd,
        CPU,
        COMMON,//this means the gpu or the gpuminer is independend of type
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
            Hashrate = "0";
            FanSpeed = "0";
            Temperature = "0";
        }
        public bool IdentifyMake()
        {
            try
            {
                string pattern = "(N|n)(V|v)(I|i)(D|d)(I|i)(A|a)";
                Match r_gpu_id = Regex.Match(GPUName, pattern);
                if (r_gpu_id.Success)
                    Make= CardMake.Nvidia;
                else
                    Make= CardMake.Amd;
                return true;
            }
            catch (Exception)
            {
            }
            return false;
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
