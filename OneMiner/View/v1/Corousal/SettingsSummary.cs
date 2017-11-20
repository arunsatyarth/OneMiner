using OneMiner.Core;
using OneMiner.Core.Interfaces;
using OneMiner.Model.Config;
using OneMiner.View.v1.ExtraScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1.Corousal
{
    public partial class SettingsSummary : Form
    {
        public SettingsSummary()
        {
            InitializeComponent();
        }

        private void SettingsSummary_Load(object sender, EventArgs e)
        {
            UpdateSettingsView();
            Timer t = new Timer();
            t.Interval = 60000;
            t.Tick += t_Tick;
            t.Start();
        }
        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateTime();
            }
            catch (Exception )
            {
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
                IMiner miner = Factory.Instance.CoreObject.SelectedMiner;
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
