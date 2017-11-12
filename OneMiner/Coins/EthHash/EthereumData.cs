using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    public class EthereumData : MinerData,IMiner
    {
        public List<IMinerProgram> MinerPrograms { get; set; }
        public ICoinConfigurer Configurer { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }//not sure if needed

        public void SetupMiner()
        {

        }
        public void StartMiner()
        {

        }


        
    }
}
