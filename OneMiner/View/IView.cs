using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.View
{
    interface IView
    {
        void InitializeView();
        void StartView();
        void UpdateMinerList();
    }
}
