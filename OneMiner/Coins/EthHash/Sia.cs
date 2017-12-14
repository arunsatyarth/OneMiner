using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.Coins.EthHash
{
    class Sia: ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }
        ICoinConfigurer Configurer;

        public Sia(IHashAlgorithm algo)
        {
            Algorithm = algo;

        }
        public string Name
        {
            get { return "SiaCoin"; }
        }

        public Bitmap Logo
        {
            get { return OneMiner.Properties.Resources.siacoin; }
            
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
                Pool pool2 = new Nanopool("Nanopool", "sia-us-west1.nanopool.org:7777");
                pools.Add(pool2);

                return pools;
            }
            catch (Exception e)
            {
            }
            return pools;
        }
        public string GetScript(string script)
        {
            string scr = script;
            scr += " -dcoin sia ";
            return scr;
        }

        class Nanopool : Pool
        {
            public Nanopool(string name, string url)
                : base(name, url)
            {
            }
            public override string GetAccountLink(string wallet)
            {
                string acc = "";
                try
                {
                    acc = "https://sia.nanopool.org/account/" + wallet;
                }
                catch (Exception)
                {
                }
                return acc;
            }
        }
    }
}
