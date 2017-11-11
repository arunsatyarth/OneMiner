using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Coins.EthHash
{
    class EtherClassic : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }
        public EtherClassic(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public string Name
        {
            get { return "Ethereum Classic"; }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }
        public ICoinConfigurer SettingsScreen
        {
            get
            {
                ICoinConfigurer form = new ConfigureMiner();
                form.AssignCoin(this);
                return form;
            }
        }

    }
}
