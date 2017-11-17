using OneMiner.EthHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OneMiner.Model.Config
{
    /// <summary>
    /// structitr of the data is as follows
    /*
{
     defaultMiner:minerName,
     MiningAlgos:[
     {
		name:ethhash
		Programs:[
		{
			type:'nvidia'
			exefile:''
			exefolder:''
		}
		]
     },
	 {
      		name:equihash
		Programs:[
		{
			type:'nvidia'
			exefile:''
			exefolder:''
		}
		{
			type:'amd'
			exefile:''
			exefolder:''
		}
		]
      }
	  ],
	  
	  Miners:[
	  {
	  name:'',
	  batname:'',
	  maincoin:''
	  maincoinpool:''
	  maincoinwallet:''
	  dualcoin:''
	  
	  }
	  ]
}
     * 
     */
    /// </summary>
    public class MinerData//mark as abstract class
    {
        public string Name { get; set; }
        public MinerData()
        {
            Name = "Unset";
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
    public class MinerPrograms
    {
        public string ProgramType { get; set; }//eg:mvidia or AMD
        public string Exepath { get; set; }
        public string ExeFolder { get; set; }

    }
    public class MinerAlgo
    {
        public string Name { get; set; }
        public List<MinerPrograms> Miners { get; set; }

    }
    public class Miner
    {
        public string Name { get; set; }
        public string BATFileName { get; set; }
        public string Name { get; set; }
        public string Name { get; set; }
        public string Name { get; set; }
        public string Name { get; set; }

    }


    public class DB
    {
        public MinerData CurrentMiner { get; set; }
        public List<MinerData> Miners { get; set; }
        public Options Option{ get; set; }
        public DB()
        {
            Option = new Options();
            MinerData basicMiner = null;// new EthereumData();
            CurrentMiner = basicMiner;
            Miners.Add(basicMiner);
        }

    }
}
