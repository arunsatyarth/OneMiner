using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.Core
{
    class BaseCoin : ICoin
    {
        public string Name 
        {
            get { throw new NotImplementedException(); }
        }

        public string Logo
        {
            get { throw new NotImplementedException(); }
        }

        public  ICoinConfigurer SettingsScreen
        {
            get { throw new NotImplementedException(); }
        }


        /*  Todo: remove this. Forgotwhat this was for
        public ICoin DualCoin
        {
            get
            {
                return null;
            }

        }*/

    }
}
