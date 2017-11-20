using OneMiner.Core.Interfaces;
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
        public MinerInfo(IMiner miner, MainForm parent)
        {
            Miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }
        public void SelectView(Button btn)
        {
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = Color.White;

        }
        public void DeSelectView(Button btn)
        {
            btn.BackColor = Color.LightSteelBlue;
            btn.ForeColor = Color.Black;

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

        private void btntabInfo_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button) ;
        }
    }
}
