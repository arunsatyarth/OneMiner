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
        public IMiner Miner { get; set; }
        MainForm m_Parent = null;
        public MinerView(IMiner miner, MainForm parent)
        {
            Miner = miner;
            m_Parent = parent;

            InitializeComponent();


            pbTemplate.Image = Miner.MainCoin.Logo;
            pnlTemplate.Click += pnlTemplate_Click;

            lblCoinType.Text = Miner.MainCoin.Name;
            if(miner.DualMining)
                lblCoinType.Text = lblCoinType.Text + " + " + Miner.DualCoin.Name;
            lblMinername.Text = Miner.Name;

        }

        private void MinerView_Load(object sender, EventArgs e)
        {
            this.ContextMenuStrip = optionsMenu;
        }
        public void UpdateState()
        {
            UiStateUtil.UpdateState(Miner,lblMinerState, btnStartMining, optionsMenu);
        }

        public void ActivateView()
        {
            pbSelected.Visible = true;
        }
        public void DeActivateView()
        {
            pbSelected.Visible = false;
            //pbSelected.Image = Properties.Resources.selected;
        }       
        public void SelectView()
        {
            this.BackColor = Color.SteelBlue;

        }
        public void DeSelectView()
        {
            this.BackColor = Color.White;

        }
        void pnlTemplate_Click(object sender, EventArgs e)
        {
            m_Parent.ChangeMiningView(this);
        }

        private void pnlTemplate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartMining_Click(object sender, EventArgs e)
        {
            UiStateUtil.MiningStartAction(Miner);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MinerView view = sender as MinerView;
            var menuItem = sender as ToolStripMenuItem;
            var contextMenu = menuItem.GetCurrentParent() as ContextMenuStrip;
            MinerView view = contextMenu.SourceControl as MinerView;
            if (view != null)
            {
                Factory.Instance.CoreObject.SelectMiner(view.Miner);
            }


        }

        private void startMiningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStartMining_Click(sender, e);
        }
    }
}
