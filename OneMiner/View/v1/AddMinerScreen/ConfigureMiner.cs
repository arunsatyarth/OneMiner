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



            if(m_selected_coin!=null)
            {
                lblCoinName.Text = m_selected_coin.Name;
                txtPool.Text = Pool;
                txtWallet.Text = Wallet;

                cmbPoolList.SelectedIndexChanged += cmbPoolList_SelectedIndexChanged;
                foreach(Pool item in m_selected_coin.GetPools())
                {
                    cmbPoolList.Items.Add(item.Name);

                }

            }
        }

        void cmbPoolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Pool> pools=m_selected_coin.GetPools();
                int index = cmbPoolList.SelectedIndex;
                Pool pool = pools[index];
                if(pool!=null)
                {
                    txtPool.Text = pool.Link;
                }
            }
            catch (Exception de)
            {
            }
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
