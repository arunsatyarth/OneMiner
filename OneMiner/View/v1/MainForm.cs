using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.View;
using OneMiner.View.v1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddMiner_Click(object sender, EventArgs e)
        {
            //Todo permission from core to add miner
            AddMinerContainer addMiner = new AddMinerContainer();
            addMiner.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }
        private Panel ClonePanel(Panel p)
        {
            return null;
        }
        public void UpdateMinerList()
        {
            List<IMiner> miners = Factory.Instance.CoreObject.Miners;
            pnlMiner.Controls.Clear();

            foreach (IMiner item in miners)
            {
                MinerView view = new MinerView(item,this);
                view.TopLevel = false;
                pnlMiner.Controls.Add(view);
                view.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //view.Dock = DockStyle.Fill;
                view.Show();
            }
        }
        public void ShowBottom(IMiner miner)
        {
            MinerInfo view = new MinerInfo(miner, this);
            view.TopLevel = false;
            pnlMinerInfo.Controls.Clear();
            pnlMinerInfo.Controls.Add(view);
            view.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            view.Dock = DockStyle.Fill;
            view.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }

        private void donateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }



    }
}
