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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public void StartView()
        {

            m_MainForm = new MainForm();
            UpdateMinerList();

            Application.Run(m_MainForm);
        }
        public void UpdateMinerList()
        {
            m_MainForm.UpdateMinerList();
        }
    }
}
