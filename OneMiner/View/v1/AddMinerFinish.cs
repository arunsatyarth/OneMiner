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
    public partial class AddMinerFinish : Form
    {
        private AddMinerContainer m_parent = null;
        //public ICoin SelectedCoin { get; set; }
        //public ICoin SelectedDualCoin { get; set; }


        public AddMinerFinish(AddMinerContainer parent)
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
                string minername = m_parent.AddMiner.Minername;
                string selection="";
                if (selectedDualCoin == null)
                    selection = selectedCoin.Name;
                else
                    selection = selectedCoin.Name + " + " + selectedDualCoin.Name;

                string commandline = "";

                rchFinish.Text = minername;
                rchFinish.Text += "\n";
                rchFinish.Text += selection;




            }
        }


    }
}
