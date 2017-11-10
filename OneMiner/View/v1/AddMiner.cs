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

        public AddMiner()
        {
            InitializeComponent();
        }
        private void SelectFirstAlgo(int index,IHashAlgorithm algo)
        {
            lbAlgoSelect.SelectedIndex = index;
            DisplayCoinsinList(algo);

        }
        private void DisplayCoinsinList(IHashAlgorithm algo)
        {

            ICoin defaultCoin = algo.DefaultCoin;
            int i = 0;
            foreach (ICoin item in algo.SupportedCoins)
            {
                lbCoinSelect.Items.Add(item.Name);
                if (item == defaultCoin)
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
                IHashAlgorithm defaultAlgo = Factory.Instance.DefaultAlgorithm;
                int i=0;
                foreach (IHashAlgorithm item in algos)
                {
                    lbAlgoSelect.Items.Add(item.Name);
                    if (item == defaultAlgo)
                        m_currentAlgoIndex = i;
                    i++;

                }

                SelectFirstAlgo(m_currentAlgoIndex,defaultAlgo);
                lbAlgoSelect.SelectedIndexChanged += lstAlgoSelect_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
            }
            
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

                IHashAlgorithm algo = algos[index];
                m_currentAlgoIndex = index;

                DisplayCoinsinList(algo);
               
            }
            catch (Exception )
            {

            }
         
        }
    }
}
