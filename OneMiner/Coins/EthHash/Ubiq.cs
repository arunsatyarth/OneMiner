using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OneMiner.Coins.EthHash
{
    class Ubiq : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }

        ICoinConfigurer Configurer;


        public Ubiq(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public string Name
        {
            get { return "Ubiq"; }
        }

        public Bitmap Logo
        {
            get { return OneMiner.Properties.Resources.ubiq; }

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
                Pool pool1 = new Pool("Ubiqpool.io", "http://us.ubiqpool.io:8888");
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
