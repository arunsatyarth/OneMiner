using OneMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneMiner.View.v1.MiningInfo
{
    public partial class MinerInfoLogs : Form
    {
        public IMiner Miner { get; set; }
        MinerInfo m_Parent = null;

        public MinerInfoLogs(IMiner miner, MinerInfo parent)
        {
            Miner = miner;
            m_Parent = parent;
            InitializeComponent();
        }

        private void MinerInfoLogs_Load(object sender, EventArgs e)
        {

        }
    }
}
