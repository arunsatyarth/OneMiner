using OneMiner.Core;
using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    /// <summary>
    /// These classes dont store user data. They are to drive the UI
    /// </summary>
    class Ethereum : BaseCoin,ICoin
    {

        public  string Name
        {
            get { return "Ethereum"; }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }


  
    }
}
