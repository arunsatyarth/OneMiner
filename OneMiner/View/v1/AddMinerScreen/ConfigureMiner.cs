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
    public partial class ConfigureMiner : Form, ICoinConfigurer
    {
        private AddMinerContainer m_parent = null;
        private ICoin m_selected_coin = null;


        public ConfigureMiner()
        {

            InitializeComponent();
        }
        public void AssignParent(object parent)
        {
            m_parent = parent as AddMinerContainer;
        }
        public void AssignCoin(ICoin coin)
        {
            m_selected_coin = coin;
        }

        private void ConfigureMiner_Load(object sender, EventArgs e)
        {
            lblCoinName.Text = m_selected_coin.Name;
            txtPool.Text = Pool;
            txtWallet.Text = Wallet;
        }

        private void btnAddDualMiner_Click(object sender, EventArgs e)
        {

        }
        public string Pool { get; set; }

        public string Wallet { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Pool = txtPool.Text.Trim();

        }

        private void txtWallet_TextChanged(object sender, EventArgs e)
        {
            Wallet = txtWallet.Text.Trim();

        }
    }
}
