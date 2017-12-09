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
    class Zcash : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }

        ICoinConfigurer Configurer;


        public Zcash(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public  string Name
        {
            get { return "Zcash"; }
        }

        public Bitmap Logo
        {
            get { return OneMiner.Properties.Resources.zcash; }
            
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
                Pool pool1 = new Pool("Flypool", "ssl://eu1-zcash.flypool.org:3443");
                Pool pool2 = new Pool("Nanopool", "zec-us-east1.nanopool.org:6666");
                pools.Add(pool1);
                pools.Add(pool2);

                return pools;
            }
            catch (Exception e)
            {
            }
            return pools;
        }

  
    }
}
