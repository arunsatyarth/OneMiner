using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    class EthHash : IHashAlgorithm
    {
        public string Name
        {
            get
            {
                return "Ethhash";
            }
           
        }
        public List<ICoin> SupportedCoins 
        { 
            get 
            {
                List<ICoin> coins = new List<ICoin>();
                coins.Add(new Ethereum());
                return coins;
            } 
        }

    }
}
