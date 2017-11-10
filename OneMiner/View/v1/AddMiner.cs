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
        public AddMiner()
        {
            InitializeComponent();
        }
        private void SelectFirstAlgo(IHashAlgorithm algo)
        {
            lstAlgoSelect.Items[0].Selected = true;
            DisplayCoinsinList(algo);

        }
        private void DisplayCoinsinList(IHashAlgorithm algo)
        {
            foreach (ICoin item in algo.SupportedCoins)
            {
                lstCoinSelect.Items.Add(item.Name);
                lstCoinSelect.Items.Add(item.Name);

            }

        }

        private void AddMiner_Load(object sender, EventArgs e)
        {
            List<IHashAlgorithm> algos = Factory.Instance.Algorithms;

            foreach (IHashAlgorithm item in algos)
	        {
                lstAlgoSelect.Items.Add(item.Name);
                lstAlgoSelect.Items.Add(item.Name);
		 
	        }
            lstAlgoSelect.SelectedIndexChanged += lstAlgoSelect_SelectedIndexChanged;
            SelectFirstAlgo(algos[0]);
        }

        void lstAlgoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<IHashAlgorithm> algos = Factory.Instance.Algorithms;
                int index = lstAlgoSelect.SelectedIndices[0];
                IHashAlgorithm algo = algos[index];
                DisplayCoinsinList(algo);
               
            }
            catch (Exception )
            {

            }
         
        }
    }
}
