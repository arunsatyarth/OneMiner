using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneMiner.View
{
    public delegate void OneMinerTimerEvent();

    interface IView
    {
        void InitializeView();
        void StartView();
        void UpdateMinerList();
        void RegisterForTimer(OneMinerTimerEvent fun);

    }
}
