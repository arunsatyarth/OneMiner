namespace OneMiner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddMiner = new System.Windows.Forms.Button();
            this.pnlMinerInfo = new System.Windows.Forms.Panel();
            this.pnlMiner = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miningToolStripMenuItem,
            this.profitabilityToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.donateToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miningToolStripMenuItem
            // 
            this.miningToolStripMenuItem.Name = "miningToolStripMenuItem";
            this.miningToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.miningToolStripMenuItem.Text = "Mining";
            // 
            // profitabilityToolStripMenuItem
            // 
            this.profitabilityToolStripMenuItem.Name = "profitabilityToolStripMenuItem";
            this.profitabilityToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.profitabilityToolStripMenuItem.Text = "Profitability";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.advancedToolStripMenuItem.Text = "Settings";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.donateToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // donateToolStripMenuItem1
            // 
            this.donateToolStripMenuItem1.Name = "donateToolStripMenuItem1";
            this.donateToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem1.Text = "Donate";
            this.donateToolStripMenuItem1.Click += new System.EventHandler(this.donateToolStripMenuItem1_Click);
            // 
            // btnAddMiner
            // 
            this.btnAddMiner.Location = new System.Drawing.Point(12, 27);
            this.btnAddMiner.Name = "btnAddMiner";
            this.btnAddMiner.Size = new System.Drawing.Size(75, 23);
            this.btnAddMiner.TabIndex = 2;
            this.btnAddMiner.Text = "Add Miner";
            this.btnAddMiner.UseVisualStyleBackColor = true;
            this.btnAddMiner.Click += new System.EventHandler(this.btnAddMiner_Click);
            // 
            // pnlMinerInfo
            // 
            this.pnlMinerInfo.Location = new System.Drawing.Point(12, 355);
            this.pnlMinerInfo.Name = "pnlMinerInfo";
            this.pnlMinerInfo.Size = new System.Drawing.Size(1061, 272);
            this.pnlMinerInfo.TabIndex = 2;
            // 
            // pnlMiner
            // 
            this.pnlMiner.AutoScroll = true;
            this.pnlMiner.BackColor = System.Drawing.Color.Transparent;
            this.pnlMiner.Location = new System.Drawing.Point(15, 56);
            this.pnlMiner.Name = "pnlMiner";
            this.pnlMiner.Size = new System.Drawing.Size(1058, 284);
            this.pnlMiner.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OneMiner.Properties.Resources.ethereum_bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 653);
            this.Controls.Add(this.pnlMiner);
            this.Controls.Add(this.pnlMinerInfo);
            this.Controls.Add(this.btnAddMiner);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OneMiner - 1 Click Miner for Ethereum, ZCash";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profitabilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miningToolStripMenuItem;
        private System.Windows.Forms.Button btnAddMiner;
        private System.Windows.Forms.Panel pnlMinerInfo;
        private System.Windows.Forms.FlowLayoutPanel pnlMiner;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem1;
    }
}

