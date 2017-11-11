using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.EthHash
{
    class Decred : ICoin
    {
        public string Name
        {
            get { return "Ethereum"; }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }
        public ICoinConfigurer SettingsScreen
        {
            get
            {
                ICoinConfigurer form = new ConfigureMiner();
                form.AssignCoin(this);
                return form;
            }
        }

    }
}
