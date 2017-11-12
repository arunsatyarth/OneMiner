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
    public partial class AddMiner : Form
    {
        private int m_currentAlgoIndex = 0;
        private int m_currentCoinIndex = 0;
        private AddMinerContainer m_parent = null;
        private IHashAlgorithm m_defaultAlgorithm = null;
        private ICoin m_defaultCoin = null;

        public AddMiner(AddMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
        }
        private bool AlgorithmSelected()
        {
            if ((lbAlgoSelect.SelectedIndex >= 0 && lbAlgoSelect.SelectedIndex <= (lbAlgoSelect.Items.Count - 1))
               && (lbCoinSelect.SelectedIndex >= 0 && lbCoinSelect.SelectedIndex <= (lbCoinSelect.Items.Count - 1)))
            {
                return true;
            }
            return false;
        }
        //Todo: check in core if no miners with this name exists
        private bool UniqueMinerName(string name)
        {
            return true;
        }
        private bool NameAdded()
        {
            string minername=txtMinername.Text.Trim();
            if (minername.Length > 0 && UniqueMinerName(minername))
            {
                return true;
            }
            return false;
        }
        public void SetNextButtonState()
        {
            if (AlgorithmSelected() && NameAdded())
                m_parent.EnableNextButton();
            else
                m_parent.DisableNextButton();
        }
        public void MakeSelectedCoin()
        {
            if (m_defaultCoin!=null)
            {
                m_parent.MakeSelectedCoin(m_defaultCoin);
                lblSelectedCoin.Text = m_defaultCoin.Name;
            }
            else
                lblSelectedCoin.Text = "No Coin Selected";

        }
        private void SelectFirstAlgo(int index,IHashAlgorithm algo)
        {
            lbAlgoSelect.SelectedIndex = index;
            DisplayCoinsinList(algo);

        }
        private void DisplayCoinsinList(IHashAlgorithm algo)
        {

            m_defaultCoin = algo.DefaultCoin;
            int i = 0;
            foreach (ICoin item in algo.SupportedCoins)
            {
                lbCoinSelect.Items.Add(item.Name);
                if (item == m_defaultCoin)
                    m_currentCoinIndex = i;
                i++;
            }
            lbCoinSelect.SelectedIndex = m_currentCoinIndex;


        }

        private void AddMiner_Load(object sender, EventArgs e)
        {
            try
            {
                List<IHashAlgorithm> algos = Factory.Instance.Algorithms;
                m_defaultAlgorithm = Factory.Instance.DefaultAlgorithm;
                int i=0;
                foreach (IHashAlgorithm item in algos)
                {
                    lbAlgoSelect.Items.Add(item.Name);
                    if (item == m_defaultAlgorithm)
                        m_currentAlgoIndex = i;
                    i++;

                }
                //by default select the first algo
                SelectFirstAlgo(m_currentAlgoIndex, m_defaultAlgorithm);
                lbAlgoSelect.SelectedIndexChanged += lstAlgoSelect_SelectedIndexChanged;
                lbCoinSelect.SelectedIndexChanged += lbCoinSelect_SelectedIndexChanged;
                //check and eneble next button
                SetNextButtonState();
                //Tell parent which coin is currently seelcted
                MakeSelectedCoin();
            }
            catch (Exception ex)
            {
            }
            
        }

        void lbCoinSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lbCoinSelect.SelectedIndex;

                if (m_currentCoinIndex == index)
                    return;
                List<ICoin> coins = m_defaultAlgorithm.SupportedCoins;

                m_defaultCoin = coins[index];
                m_currentCoinIndex = index;

                SetNextButtonState();
                //Tell parent which coin is currently seelcted
                MakeSelectedCoin();

            }
            catch (Exception)
            {

            }
        }

        void txtMinername_TextChanged(object sender, EventArgs e)
        {
            SetNextButtonState();
            m_parent.Minername = txtMinername.Text;
        }

        void lstAlgoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lbAlgoSelect.SelectedIndex;

                if (m_currentAlgoIndex == index)
                    return;
                lbCoinSelect.Items.Clear();
                List<IHashAlgorithm> algos = Factory.Instance.Algorithms;

                m_defaultAlgorithm = algos[index];
                m_currentAlgoIndex = index;

                DisplayCoinsinList(m_defaultAlgorithm);
                SetNextButtonState();
                //Tell parent which coin is currently seelcted
                MakeSelectedCoin();
               
            }
            catch (Exception )
            {

            }
         
        }





    }
}
