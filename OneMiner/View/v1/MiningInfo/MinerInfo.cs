using OneMiner.Core.Interfaces;
using OneMiner.View.v1.MiningInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1
{
    public partial class MinerInfo : Form
    {

        public IMiner Miner { get; set; }
        
        MainForm m_Parent = null;
        List<Button> m_tabButtons = new List<Button>();

        Form m_Summary = new MinerInfoSummary();
        Form m_Script = new MinerInfoSummary();
        Form m_Logs = new MinerInfoSummary();
        public MinerInfo(IMiner miner, MainForm parent)
        {
            Miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }
        public void SelectView(Button btn)
        {
            foreach (Button item in m_tabButtons)
            {
                if(btn==item)
                {
                    item.BackColor = Color.SteelBlue;
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.BackColor = Color.LightSteelBlue;
                    item.ForeColor = Color.Black;
                }
            }


        }


        private void MinerInfo_Load(object sender, EventArgs e)
        {
            pbTemplate.Image = Miner.MainCoin.Logo;

            lblMinerType.Text = Miner.MainCoin.Name;
            if (Miner.DualMining)
                lblMinerType.Text = lblMinerType.Text + " + " + Miner.DualCoin.Name;
            lblMinername.Text = Miner.Name;

            m_tabButtons.Add(btntabInfo);
            m_tabButtons.Add(btntabLogs);
            m_tabButtons.Add(btntabScript);
            //btntabInfo.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
        }
        public void ShowTabInfo(Form form)
        {
            form.TopLevel = false;
            pnlMinerInfo.Controls.Clear();
            pnlMinerInfo.Controls.Add(form);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void btntabInfo_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button) ;
            //ShowTabInfo(m_Summary);
        }

        private void btntabScript_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button);
            //ShowTabInfo(m_Script);


        }

        private void btntabLogs_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button);
            //ShowTabInfo(m_Logs);


        }
    }
}
