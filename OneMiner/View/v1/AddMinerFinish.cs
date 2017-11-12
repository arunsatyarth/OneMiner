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
        }

        private void AddMinerFinish_Load(object sender, EventArgs e)
        {

            if (SelectedCoin == null)
            {
                //disable finish button in last screen
                m_parent.DisableFinishButton();
            }
            else
            {
                string minername = m_parent.m_;
                string selection="";
                if (SelectedDualCoin==null)
                    selection = SelectedCoin.Name ;
                else
                    selection = SelectedCoin.Name +" + " + SelectedDualCoin.Name;

                string commandline = "";

                rchFinish.Text = minername;



            }
        }


    }
}
