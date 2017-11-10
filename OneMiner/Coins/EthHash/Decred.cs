using OneMiner.Core;
using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    class Decred : BaseCoin,ICoin
    {
        public  string Name
        {
             get  { return "Ethereum"; }
        }

        public  string Logo
        {
            get { throw new NotImplementedException(); }
        }

    }
}
