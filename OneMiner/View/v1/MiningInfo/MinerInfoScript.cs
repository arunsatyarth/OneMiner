using OneMiner.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1.MiningInfo
{
    public partial class MinerInfoScript : Form
    {
        public IMiner Miner { get; set; }
        MinerInfo m_Parent = null;
        Hashtable m_ButtonToMiner = new Hashtable();
        Button m_currentButton = null;

        public MinerInfoScript(IMiner miner, MinerInfo parent)
        {
            Miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }

        private void MinerInfoScript_Load(object sender, EventArgs e)
        {
            List<IMinerProgram> programs = Miner.MinerPrograms;
            Button leftbutton = btnTemplate;
            int i=0;
            foreach (IMinerProgram item in programs)
            {
                Button btn = new Button();
                btn.Top = 10;
                btn.Name = "button"+i.ToString();
                btn.Click += btn_Click;
                btn.Text = item.Type;
                btn.Left = leftbutton.Left + btnTemplate.Width;
                btn.FlatStyle = FlatStyle.Popup;
                btn.BackColor = Color.LightSteelBlue;
                btn.ForeColor = Color.Black;
                if (m_currentButton == null)
                    m_currentButton = btn;

                leftbutton = btn;
                this.Controls.Add(btn);
                i++;
                m_ButtonToMiner.Add(btn.Name, item);
            }
            m_currentButton.BackColor = Color.SteelBlue;
            m_currentButton.ForeColor = Color.White;
            showScript(m_currentButton);


        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            m_currentButton = btn;
            showScript(btn);

        }
        void showScript(Button btn)
        {
            if (btn != null)
            {
                IMinerProgram prog = m_ButtonToMiner[btn.Name] as IMinerProgram;
                string script = prog.GenerateScript();
                txtScriptArea.Text = script;
                DisableEdit();

            }
        }
        private void DisableEdit()
        {
            txtScriptArea.ReadOnly = true;
            lnkEdit.Enabled = true;
            btnSave.Enabled = false;
        }
        private void Enabledit()
        {
            txtScriptArea.ReadOnly = false;
            lnkEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Enabledit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DisableEdit();
            if (m_currentButton != null)
            {
                IMinerProgram prog = m_ButtonToMiner[m_currentButton.Name] as IMinerProgram;
                prog.ModifyScript(txtScriptArea.Text);

            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (m_currentButton != null)
            {
                IMinerProgram prog = m_ButtonToMiner[m_currentButton.Name] as IMinerProgram;
                string script = prog.GenerateScript();
                txtScriptArea.Text = script;
                DisableEdit();

            }
        }
    }
}
