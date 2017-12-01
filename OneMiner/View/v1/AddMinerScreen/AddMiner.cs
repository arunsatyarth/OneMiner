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
        public string Minername { get; set; }

        public AddMiner(AddMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
        }
        private bool AlgorithmSelected()
        {
            if ((lbAlgoSelect.SelectedIndex >= 0 && lbAlgoSelect.SelectedIndex <= (lbAlgoSelect.Items.Count - 1))
               && (lbCoinSelect.SelectedIndices[0] >= 0 && lbCoinSelect.SelectedIndices[0] <= (lbCoinSelect.Items.Count - 1)))
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
            Minername = txtMinername.Text.Trim();
            if (Minername.Length > 0 && UniqueMinerName(Minername))
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
                pbSelectedMiner.Image = m_defaultCoin.Logo;
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
            ImageList Imagelist = new ImageList();
            Imagelist.ImageSize = new Size(25, 25);
            foreach (ICoin item in algo.SupportedCoins)
            {
                Imagelist.Images.Add(item.Logo);
            }
            lbCoinSelect.LargeImageList = Imagelist;
            lbCoinSelect.SmallImageList = Imagelist;
            int i = 0;
            foreach (ICoin item in algo.SupportedCoins)
            {
                lbCoinSelect.Items.Add(new ListViewItem { ImageIndex = i, Text = item.Name });


                //lbCoinSelect.Items.Add(item.Name);
                if (item == m_defaultCoin)
                    m_currentCoinIndex = i;
                i++;
            }

            lbCoinSelect.Items[m_currentCoinIndex].Selected = true;
            //lbCoinSelect.SelectedIndex = m_currentCoinIndex;


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
                    if (item.Name == m_defaultAlgorithm.Name)
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
                int index = lbCoinSelect.SelectedIndices[0];

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
            Minername = txtMinername.Text.Trim();
            SetNextButtonState();

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
