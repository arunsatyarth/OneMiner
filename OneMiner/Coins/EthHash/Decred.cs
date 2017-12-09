using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.EthHash
{
    class Decred : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }
        ICoinConfigurer Configurer;

        public Decred(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public string Name
        {
            get { return "Decred"; }
        }

        public Bitmap Logo
        {
            get { return OneMiner.Properties.Resources.decred; }
            
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
                Pool pool1 = new Pool("Supernova", "dcr.suprnova.cc:3252");
                pools.Add(pool1);

                return pools;
            }
            catch (Exception e)
            {
            }
            return pools;
        }

    }
}
