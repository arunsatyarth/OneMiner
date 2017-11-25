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
            string labelName = "";
            string buttontext = "";

            switch(Miner.MinerState)
            {
                case MinerProgramState.Starting:
                    lblMinerState.ForeColor = SystemColors.Info;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.PartiallyRunning:
                    lblMinerState.ForeColor = SystemColors.Info;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.Downloading:
                    lblMinerState.ForeColor = SystemColors.HotTrack;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";
                    break;
                case MinerProgramState.Running:
                    lblMinerState.ForeColor = Color.MediumSeaGreen;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Stop";

                    break;
                case MinerProgramState.Stopping:
                       lblMinerState.ForeColor = Color.Tomato;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Start";
                    break;
                case MinerProgramState.Stopped:
                    lblMinerState.ForeColor = Color.Tomato;
                    labelName = Miner.MinerState.ToString();
                    buttontext = "Start";
                    break;
                default:
                    lblMinerState.ForeColor = SystemColors.Info;
                    labelName = "unknown state";
                    buttontext = "unknown";
                    break;

            }
            lblMinerState.Text = labelName;
            btnStartMining.Text = buttontext;
            optionsMenu.Items[1].Text = buttontext;

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
            m_Parent.SelectMiningView(this);

            m_Parent.ShowMiningView(Miner);
        }

        private void pnlTemplate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartMining_Click(object sender, EventArgs e)
        {
            switch (Miner.MinerState)
            {
                case MinerProgramState.Starting:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.PartiallyRunning:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Downloading:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Running:
                    Factory.Instance.CoreObject.StopMining();
                    break;
                case MinerProgramState.Stopping:
                    Factory.Instance.CoreObject.StartMining(Miner);
                    break;
                case MinerProgramState.Stopped:
                    Factory.Instance.CoreObject.StartMining(Miner);
                    break;
                default:
                    break;
            }
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
