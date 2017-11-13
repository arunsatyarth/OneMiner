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
        public void InitializeView()
        {
        }

        public void StartView()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_MainForm = new MainForm(); 

            Application.Run(m_MainForm);
        }
        public void UpdateMinerList()
        {
            m_MainForm.UpdateMinerList();
        }
    }
}
