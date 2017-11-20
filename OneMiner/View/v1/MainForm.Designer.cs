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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lblActiveMiner = new System.Windows.Forms.Label();
            this.lblMineOnStartup = new System.Windows.Forms.Label();
            this.lblRunningTime = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlMinerInfo.Location = new System.Drawing.Point(12, 355);
            this.pnlMinerInfo.Name = "pnlMinerInfo";
            this.pnlMinerInfo.Size = new System.Drawing.Size(1117, 272);
            this.pnlMinerInfo.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblRunningTime);
            this.panel1.Controls.Add(this.lblMineOnStartup);
            this.panel1.Controls.Add(this.lblActiveMiner);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(839, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 284);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(149, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(149, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(149, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Running Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Active Miner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mine on Startup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel2.Location = new System.Drawing.Point(204, 24);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(25, 13);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Edit";
            // 
            // lblActiveMiner
            // 
            this.lblActiveMiner.AutoSize = true;
            this.lblActiveMiner.BackColor = System.Drawing.Color.White;
            this.lblActiveMiner.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveMiner.Location = new System.Drawing.Point(168, 57);
            this.lblActiveMiner.Name = "lblActiveMiner";
            this.lblActiveMiner.Size = new System.Drawing.Size(100, 20);
            this.lblActiveMiner.TabIndex = 11;
            this.lblActiveMiner.Text = "DefaultMiner";
            // 
            // lblMineOnStartup
            // 
            this.lblMineOnStartup.AutoSize = true;
            this.lblMineOnStartup.BackColor = System.Drawing.Color.White;
            this.lblMineOnStartup.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMineOnStartup.Location = new System.Drawing.Point(168, 92);
            this.lblMineOnStartup.Name = "lblMineOnStartup";
            this.lblMineOnStartup.Size = new System.Drawing.Size(30, 20);
            this.lblMineOnStartup.TabIndex = 12;
            this.lblMineOnStartup.Text = "No";
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.AutoSize = true;
            this.lblRunningTime.BackColor = System.Drawing.Color.White;
            this.lblRunningTime.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningTime.Location = new System.Drawing.Point(168, 127);
            this.lblRunningTime.Name = "lblRunningTime";
            this.lblRunningTime.Size = new System.Drawing.Size(57, 20);
            this.lblRunningTime.TabIndex = 13;
            this.lblRunningTime.Text = "Infinity";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OneMiner.Properties.Resources.ethereum_bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 653);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label lblActiveMiner;
        private System.Windows.Forms.Label lblRunningTime;
        private System.Windows.Forms.Label lblMineOnStartup;
    }
}

