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
    }
}
