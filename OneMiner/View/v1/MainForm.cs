using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
using OneMiner.View;
using OneMiner.View.v1;
using OneMiner.View.v1.Corousal;
using OneMiner.View.v1.ExtraScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OneMiner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        List<Form> m_Corousals = new List<Form>();
        int m_CurrentCarousal = 0;

        private void btnAddMiner_Click(object sender, EventArgs e)
        {
            //Todo permission from core to add miner
            AddMinerContainer addMiner = new AddMinerContainer();
            addMiner.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            RunCarousal();
        }
        SettingsSummary m_SettingsSummary = new SettingsSummary();
        ProfitabilitySummary m_ProfitabilitySummary = new ProfitabilitySummary();
        public void ShowSettingsCarausal()
        {
            m_SettingsSummary.UpdateSettingsView();
            BringToView(m_SettingsSummary);
        }

        public void RunCarousal()
        {
            m_Corousals.Add(m_SettingsSummary);
            m_Corousals.Add(m_ProfitabilitySummary);

            Form next = m_Corousals.ElementAt<Form>(m_CurrentCarousal);
            BringToView(next);
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 60000;
            t.Tick += t_Tick;
            t.Start();
        }
        public void RemoveFromView(Form previous)
        {
            /*
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(600);
                previous.Opacity -= .1;
                previous.Refresh();

            }
             */
        }
        public void BringToView(Form next)
        {
            next.TopLevel = false;
            pnlCarousal.Controls.Clear();
            pnlCarousal.Controls.Add(next);
            next.Dock = DockStyle.Fill;
            //next.Opacity = .5;//opacity doesnt work for embedded forms
            next.Show();
            /*
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(600);
                next.Opacity += .1;
                next.Refresh();
            }
             */
        }

        void t_Tick(object sender, EventArgs e)
        {

            Form previous = m_Corousals.ElementAt<Form>(m_CurrentCarousal);
            m_CurrentCarousal++;
            if (m_CurrentCarousal >= m_Corousals.Count)
                m_CurrentCarousal = 0;

            Form next = m_Corousals.ElementAt<Form>(m_CurrentCarousal);

            RemoveFromView(previous);
            BringToView(next);
        }

        private Panel ClonePanel(Panel p)
        {
            return null;
        }
        public void SelectMiningView(MinerView view)
        {
            foreach (MinerView item in pnlMiner.Controls)
            {
                if(item==view)
                    item.SelectView();
                else
                    item.DeSelectView();
            }
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
                if (Factory.Instance.CoreObject.SelectedMiner == item)
                    view.SelectView();
            }
            ShowSettingsCarausal();
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

        private void pnlMinerInfo_Paint(object sender, PaintEventArgs e)
        {
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }



    }
}
