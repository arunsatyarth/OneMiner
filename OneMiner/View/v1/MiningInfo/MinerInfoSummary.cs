using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1.MiningInfo
{
    public partial class MinerInfoSummary : Form,IMinerInfoTab
    {
        public IMiner Miner { get; set; }
        MinerInfo m_Parent = null;
        public MinerInfoSummary(IMiner miner, MinerInfo parent)
        {
            Miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }

        private void MinerInfoSummary_Load(object sender, EventArgs e)
        {

        }

        public void UpdateUI()
        {
            try
            {
                //We cant get proper wallet or pool if the script is edited manually
                /*
                string linktext="Launch";
                lblWalletname.Text = Miner.MainCoin.SettingsScreen.Wallet;
                lnklblPool.Text = Miner.MainCoin.SettingsScreen.Pool+" "+linktext;
                lnklblPool.LinkArea = new LinkArea(lnklblPool.Text.Length - linktext.Length, linktext.Length);
                 */


                
            }
            catch (Exception e)
            {
            }
        }
    }
}
