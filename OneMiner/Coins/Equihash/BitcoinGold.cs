using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OneMiner.EthHash
{
    /// <summary>
    /// These classes dont store user data. They are to drive the UI
    /// </summary>
    class BitcoinGold : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }

        ICoinConfigurer Configurer;


        public BitcoinGold(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public string Name
        {
            get { return "Bitcoin Gold"; }
        }

        public Bitmap Logo
        {
            get { return OneMiner.Properties.Resources.bitcoin_gold; }

        }

        public ICoinConfigurer SettingsScreen
        {
            get
            {
                if (Configurer == null)
                {
                    Configurer = new ConfigureMiner();
                    Configurer.AssignCoin(this);
                }
                return Configurer;
            }
        }
        public List<Pool> GetPools()
        {
            List<Pool> pools = new List<Pool>();
            try
            {
                Pool pool1 = new Pool("Pool Gold", "eu.pool.gold:3044");
                pools.Add(pool1);

                return pools;
            }
            catch (Exception e)
            {
            }
            return pools;
        }
        public string GetScript(string script)
        {
            return script;
        }


    }
}
