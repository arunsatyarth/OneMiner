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
    public partial class AddDualMiner : Form
    {
        private AddMinerContainer m_parent = null;
        private ICoin m_selectedDualCoin = null;
        private int m_currentCoinIndex = 0;
        public ICoin SelectedCoin { get; set; }

        public AddDualMiner(AddMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
        }
        private bool AlgorithmSelected()
        {
            if (lbCoinSelect.SelectedIndex >= 0 && lbCoinSelect.SelectedIndex <= (lbCoinSelect.Items.Count - 1))
            {
                return true;
            }
            return false;
        }
        public void SetNextButtonState()
        {
            if (AlgorithmSelected() )
                m_parent.EnableNextButton();
            else
                m_parent.DisableNextButton();

        }
        private void AddDualMiner_Load(object sender, EventArgs e)
        {
            try
            {
                
                int i = 0;
                IHashAlgorithm algo= SelectedCoin.Algorithm;
                m_selectedDualCoin = algo.DefaultDualCoin;

                foreach (ICoin item in algo.SupportedDualCoins)
                {
                    lbCoinSelect.Items.Add(item.Name);
                    if (item == m_selectedDualCoin)
                        m_currentCoinIndex = i;
                    i++;

                }
                lbCoinSelect.SelectedIndex = m_currentCoinIndex;

                lbCoinSelect.SelectedIndex = m_currentCoinIndex;
                lbCoinSelect.SelectedIndexChanged+=lbCoinSelect_SelectedIndexChanged;
                SetNextButtonState();
                
            }
            catch (Exception ex)
            {
            }
        }
        public void SelectedDualCoin()
        {
            if (m_selectedDualCoin != null)
            {
                m_parent.SelectedCoin(m_selectedDualCoin);
            }
        }
        void lbCoinSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lbCoinSelect.SelectedIndex;

                if (m_currentCoinIndex == index)
                    return;
                List<ICoin> coins = SelectedCoin.Algorithm.SupportedDualCoins;

                m_selectedDualCoin = coins[index];
                m_currentCoinIndex = index;

                SetNextButtonState();
                //Tell parent which coin is currently seelcted
                SelectedDualCoin();

            }
            catch (Exception)
            {

            }
        }
    }
}
