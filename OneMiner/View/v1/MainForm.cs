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
        DateTime m_LastCarousalTurn = DateTime.Now;
        private const int CAROUSAL_WAIT=60000;

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
            this.FormClosing += MainForm_FormClosing;
            oneMinerNotifyIcon.ContextMenuStrip = taskbarMenu;

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
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

            Factory.Instance.ViewObject.RegisterForTimer(t_Tick);
            Factory.Instance.ViewObject.RegisterForTimer(UpDateMinerState);
        }
        public void UpDateMinerState()
        {
            try
            {
                if(this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(UpDateMinerState),
                                          new object[] {  });
                }
                else
                {
                    foreach (Control item in pnlMiner.Controls)
                    {
                        MinerView form = item as MinerView;
                        if (form != null)
                        {
                            form.UpdateState();
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Logger.Instance.LogError("Error while updating minerstate" + e.Message);
            }
         
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
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 3000)
            {
                showToolStripMenuItem_Click(null, new EventArgs());
            }

            base.WndProc(ref m);
        }
        void t_Tick()
        {
            TimeSpan elapsedTime = DateTime.Now - m_LastCarousalTurn;
            if (elapsedTime.Seconds < CAROUSAL_WAIT)
                return;
            m_LastCarousalTurn = DateTime.Now;
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
        public void ActivateMiningView(MinerView view)
        {
            foreach (MinerView item in pnlMiner.Controls)
            {
                if (item == view)
                    item.ActivateView();
                else
                    item.DeActivateView();
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
                view.UpdateState();
                //view.Dock = DockStyle.Fill;
                view.Show();
                if (Factory.Instance.CoreObject.SelectedMiner == item)
                {
                    view.SelectView();
                    view.ActivateView();
                    ShowMiningView(item);
                }
            }
            ShowSettingsCarausal();
        }


        public void ShowMiningView(IMiner miner)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factory.Instance.CoreObject.CloseApp();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }



    }
}
