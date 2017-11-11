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
        private int m_currentCoinIndex = 0;

        public AddDualMiner(AddMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
        }

        private void AddDualMiner_Load(object sender, EventArgs e)
        {
            try
            {
                /*
                List<IHashAlgorithm> algos = Factory.Instance.Algorithms;
                IHashAlgorithm defaultAlgo = Factory.Instance.DefaultAlgorithm;
                int i = 0;
                foreach (IHashAlgorithm item in algos)
                {
                    lbAlgoSelect.Items.Add(item.Name);
                    if (item == defaultAlgo)
                        m_currentAlgoIndex = i;
                    i++;

                }

                SelectFirstAlgo(m_currentAlgoIndex, defaultAlgo);
                lbAlgoSelect.SelectedIndexChanged += lstAlgoSelect_SelectedIndexChanged;
                EnableNextButton();
                 * */
            }
            catch (Exception ex)
            {
            }
        }
    }
}
