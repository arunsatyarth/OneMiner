using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneMiner.Core
{
    public class Alarm
    {
        static event OneMinerTimerEvent m_Events;
        static Timer m_timer = null;
        static Alarm()
        {
            m_timer = new Timer(CheckStatus, null, 5000, 10000);
        }
        static private void CheckStatus(Object stateInfo)
        {
            try
            {
                if (m_Events != null)
                {
                    Delegate[] delegates = m_Events.GetInvocationList();
                    if (delegates.Length > 0)
                        m_Events.Invoke();
                }
            }
            catch (Exception e)
            {
                Factory.Instance.Logger.LogError(e.ToString());
            }
        }
        public static void RegisterForTimer(OneMinerTimerEvent fun)
        {
            m_Events += fun;
        }
        public static void Clear()
        {
            m_Events = null;
        }
    }
}
