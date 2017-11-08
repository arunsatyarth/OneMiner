using OneMiner.EthHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Model.Config
{
    public class MinerData//mark as abstract class
    {
        public string Name { get; set; }
        public MinerData()
        {
            Name="Unset"
        }
    }
    public class Options
	{
        public Boolean Startup { get; set; }
        public Boolean MineOnStartup { get; set; }
        public Options()
        {
            Startup = true;
            MineOnStartup = true;
        }
	}

    public class JsonValues
    {
        public MinerData CurrentMiner { get; set; }
        public List<MinerData> Miners { get; set; }
        public Options Option{ get; set; }
        public JsonValues()
        {
            Option = new Options();
            MinerData basicMiner = new EthereumData();
            CurrentMiner = basicMiner;
            Miners.Add(basicMiner);
        }

    }
}
