using OneMiner.Core;
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
    public partial class MinerView : Form
    {
        IMiner m_miner = null;
        MainForm m_Parent = null;
        public MinerView(IMiner miner, MainForm parent)
        {
            m_miner = miner;
            m_Parent = parent;

            InitializeComponent();


            pbTemplate.Image = m_miner.MainCoin.Logo;
            pnlTemplate.Click += pnlTemplate_Click;

            lblCoinType.Text = m_miner.MainCoin.Name;
            if(miner.DualMining)
                lblCoinType.Text = lblCoinType.Text + " + " + m_miner.DualCoin.Name;
            lblMinername.Text = m_miner.Name;

        }

        private void MinerView_Load(object sender, EventArgs e)
        {
           
        }

        void pnlTemplate_Click(object sender, EventArgs e)
        {
            m_Parent.ShowBottom(m_miner);
        }

        private void pnlTemplate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartMining_Click(object sender, EventArgs e)
        {

            Factory.Instance.CoreObject.StartMining(m_miner);
        }
    }
}
