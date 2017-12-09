using OneMiner.Core.Interfaces;
using OneMiner.View.v1.AddMinerScreen;
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
    public partial class AddMinerFinish : Form
    {
        private IMinerContainer m_parent = null;
        //public ICoin SelectedCoin { get; set; }
        //public ICoin SelectedDualCoin { get; set; }


        public AddMinerFinish(IMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
            //this.Activated
        }

        private void AddMinerFinish_Load(object sender, EventArgs e)
        {

            ICoin selectedCoin = m_parent.SelectedCoin;
            ICoin selectedDualCoin = m_parent.SelectedDualCoin;
            if (selectedCoin == null)
            {
                //disable finish button in last screen
                m_parent.DisableFinishButton();
            }
            else
            {
                string minername = m_parent.GetMinername();
                string selection="";
                if (selectedDualCoin == null)
                    selection = selectedCoin.Name;
                else
                    selection = selectedCoin.Name + " + " + selectedDualCoin.Name;

                lblMinername.Text = minername;
                lblMinerType.Text = selection;
                pbSelectedMiner.Image = selectedCoin.Logo;
                lblSelectedCoin.Text = selectedCoin.Name;
                lblMaincoinPool.Text = selectedCoin.SettingsScreen.Pool;
                lblMainCoinWallet.Text = selectedCoin.SettingsScreen.Wallet;

                if (selectedDualCoin != null)
                {
                    pbDualCoin.Image = selectedDualCoin.Logo;
                    lblSelectedDualCoin.Text = selectedDualCoin.Name;
                    lblDualCoinPool.Text = selectedDualCoin.SettingsScreen.Pool;
                    lblDualCoinWallet.Text = selectedDualCoin.SettingsScreen.Wallet;
                }


            }
        }


    }
}
