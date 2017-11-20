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
            this.tabMinerInfo = new System.Windows.Forms.TabControl();
            this.tbPageGeneralInfo = new System.Windows.Forms.TabPage();
            this.tbPageScript = new System.Windows.Forms.TabPage();
            this.tbPageLog = new System.Windows.Forms.TabPage();
            this.pnlMiner = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCarousal = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnlMinerInfo.SuspendLayout();
            this.tabMinerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miningToolStripMenuItem,
            this.profitabilityToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.donateToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1141, 24);
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
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
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
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.donateToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
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
            this.btnAddMiner.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddMiner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddMiner.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMiner.Location = new System.Drawing.Point(15, 27);
            this.btnAddMiner.Name = "btnAddMiner";
            this.btnAddMiner.Size = new System.Drawing.Size(75, 23);
            this.btnAddMiner.TabIndex = 2;
            this.btnAddMiner.Text = "Add Miner";
            this.btnAddMiner.UseVisualStyleBackColor = false;
            this.btnAddMiner.Click += new System.EventHandler(this.btnAddMiner_Click);
            // 
            // pnlMinerInfo
            // 
            this.pnlMinerInfo.BackColor = System.Drawing.Color.White;
            this.pnlMinerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMinerInfo.Controls.Add(this.tabMinerInfo);
            this.pnlMinerInfo.Location = new System.Drawing.Point(12, 355);
            this.pnlMinerInfo.Name = "pnlMinerInfo";
            this.pnlMinerInfo.Size = new System.Drawing.Size(1117, 272);
            this.pnlMinerInfo.TabIndex = 2;
            this.pnlMinerInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMinerInfo_Paint);
            // 
            // tabMinerInfo
            // 
            this.tabMinerInfo.Controls.Add(this.tbPageGeneralInfo);
            this.tabMinerInfo.Controls.Add(this.tbPageScript);
            this.tabMinerInfo.Controls.Add(this.tbPageLog);
            this.tabMinerInfo.Location = new System.Drawing.Point(1000, 23);
            this.tabMinerInfo.Name = "tabMinerInfo";
            this.tabMinerInfo.SelectedIndex = 0;
            this.tabMinerInfo.Size = new System.Drawing.Size(97, 95);
            this.tabMinerInfo.TabIndex = 4;
            // 
            // tbPageGeneralInfo
            // 
            this.tbPageGeneralInfo.Location = new System.Drawing.Point(4, 22);
            this.tbPageGeneralInfo.Name = "tbPageGeneralInfo";
            this.tbPageGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGeneralInfo.Size = new System.Drawing.Size(89, 69);
            this.tbPageGeneralInfo.TabIndex = 0;
            this.tbPageGeneralInfo.Text = "Info";
            this.tbPageGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // tbPageScript
            // 
            this.tbPageScript.Location = new System.Drawing.Point(4, 22);
            this.tbPageScript.Name = "tbPageScript";
            this.tbPageScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageScript.Size = new System.Drawing.Size(89, 69);
            this.tbPageScript.TabIndex = 1;
            this.tbPageScript.Text = "Scripts";
            this.tbPageScript.UseVisualStyleBackColor = true;
            // 
            // tbPageLog
            // 
            this.tbPageLog.Location = new System.Drawing.Point(4, 22);
            this.tbPageLog.Name = "tbPageLog";
            this.tbPageLog.Size = new System.Drawing.Size(89, 69);
            this.tbPageLog.TabIndex = 2;
            this.tbPageLog.Text = "Logs";
            this.tbPageLog.UseVisualStyleBackColor = true;
            // 
            // pnlMiner
            // 
            this.pnlMiner.AutoScroll = true;
            this.pnlMiner.BackColor = System.Drawing.Color.Transparent;
            this.pnlMiner.Location = new System.Drawing.Point(15, 56);
            this.pnlMiner.Name = "pnlMiner";
            this.pnlMiner.Size = new System.Drawing.Size(808, 284);
            this.pnlMiner.TabIndex = 3;
            // 
            // pnlCarousal
            // 
            this.pnlCarousal.BackColor = System.Drawing.Color.White;
            this.pnlCarousal.Location = new System.Drawing.Point(839, 56);
            this.pnlCarousal.Name = "pnlCarousal";
            this.pnlCarousal.Size = new System.Drawing.Size(290, 284);
            this.pnlCarousal.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OneMiner.Properties.Resources.ethereum_bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 653);
            this.Controls.Add(this.pnlCarousal);
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
            this.pnlMinerInfo.ResumeLayout(false);
            this.tabMinerInfo.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlCarousal;
        private System.Windows.Forms.TabControl tabMinerInfo;
        private System.Windows.Forms.TabPage tbPageGeneralInfo;
        private System.Windows.Forms.TabPage tbPageScript;
        private System.Windows.Forms.TabPage tbPageLog;
    }
}

