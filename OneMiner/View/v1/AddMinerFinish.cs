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

        public AddMinerFinish(AddMinerContainer parent)
        {
            m_parent = parent;
            InitializeComponent();
        }

        private void AddMinerFinish_Load(object sender, EventArgs e)
        {

        }
    }
}
