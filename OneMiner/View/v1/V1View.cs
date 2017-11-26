using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1
{
    class V1View: IView
    {
        MainForm m_MainForm = null;
        System.Windows.Forms.Timer m_Timer;
        event OneMinerTimerEvent m_UIEvents;
        public void InitializeView()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_Timer = new System.Windows.Forms.Timer();
            m_Timer.Interval = 3000;
#if DEBUG
            m_Timer.Interval = 10000;
#endif
            m_Timer.Tick += t_Tick;
        }

        public void RegisterForTimer(OneMinerTimerEvent fun)
        {
            m_UIEvents += fun;
        }
        public void StartView()
        {

            m_MainForm = new MainForm();
            UpdateMinerList();
            m_Timer.Start();
            Application.Run(m_MainForm);
        }
        void t_Tick(object sender, EventArgs e)
        {
            m_UIEvents.Invoke();
        }
        public void UpdateMinerList()
        {
            m_MainForm.UpdateMinerList();
        }
        public void UpDateMinerState()
        {
            m_MainForm.UpDateMinerState();
        }
    }
}
