using OneMiner.Core;
using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Coins.EthHash
{
    class EtherClassic : BaseCoin,ICoin
    {
        public string Name
        {
            get { return "Ethereum Classic"; }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }

    }
}
