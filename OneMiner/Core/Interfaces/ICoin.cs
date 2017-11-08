using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.Core.Interfaces
{
    interface ICoin
    {
        string Name { get;  }
        string Logo { get;  }
        Form SettingsScreen { get;  }


    }
}
