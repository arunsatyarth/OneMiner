using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.Core
{
    class BaseCoin:ICoin
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Forms.Form SettingsScreen
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsDualMining
        {
            get { return false; }
        }

        public ICoin DualCoin
        {
            get
            {
                return null;
            }
           
        }
    }
}
