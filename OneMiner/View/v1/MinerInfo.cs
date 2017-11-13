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
    public partial class MinerInfo : Form
    {

        IMiner m_miner = null;
        MainForm m_Parent = null;
        public MinerInfo(IMiner miner, MainForm parent)
        {
            m_miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }

        private void MinerInfo_Load(object sender, EventArgs e)
        {
            lblMinername.Text = m_miner.Name;
        }
    }
}
