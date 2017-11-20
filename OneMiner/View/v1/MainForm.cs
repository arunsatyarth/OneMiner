using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
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
            UpdateSettingsView();
            Timer t = new Timer();
            t.Interval = 60000;
            t.Interval = 5000;
            t.Tick += t_Tick;
            t.Start();

        }

        void t_Tick(object sender, EventArgs e)
        {
            UpdateTime();
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
                MinerView view = new MinerView(item, this);
                view.TopLevel = false;
                pnlMiner.Controls.Add(view);
                view.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //view.Dock = DockStyle.Fill;
                view.Show();
            }
        }
        public void UpdateTime()
        {
            TimeSpan time = DateTime.Now - Factory.Instance.StartTime;
            //lblRunningTime.Text = time.ToString(@"dd\:hh\:mm");
            string timeStr;
            if (time.Days > 0)
                timeStr = string.Format("{0:00} Day: {0:00} :{1:00}", time.Days, time.TotalHours, time.Minutes);
            else
                timeStr = string.Format("{0:00}:{1:00}", time.TotalHours, time.Minutes);
            lblRunningTime.Text = timeStr;
        }
        public void UpdateSettingsView()
        {
            try
            {
                Config model = Factory.Instance.Model;
                IMiner miner = Factory.Instance.CoreObject.ActiveMiner;
                if (miner != null)
                {
                    lblActiveMiner.Text = miner.Name;
                }
                string mineonStartup = "No";
                if (model.Data.Option.MineOnStartup)
                    mineonStartup = "Yes";
                lblMineOnStartup.Text = mineonStartup;
                
                
                UpdateTime();
            }
            catch (Exception e)
            {
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
