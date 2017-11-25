namespace OneMiner.View.v1
{
    partial class MinerView
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
            this.components = new System.ComponentModel.Container();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.pbSelected = new System.Windows.Forms.PictureBox();
            this.btnStartMining = new System.Windows.Forms.Button();
            this.lblCoinType = new System.Windows.Forms.Label();
            this.lblMinername = new System.Windows.Forms.Label();
            this.pbTemplate = new System.Windows.Forms.PictureBox();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMiningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMinerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMinerState = new System.Windows.Forms.Label();
            this.pnlTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).BeginInit();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.BackColor = System.Drawing.Color.White;
            this.pnlTemplate.Controls.Add(this.lblMinerState);
            this.pnlTemplate.Controls.Add(this.pbSelected);
            this.pnlTemplate.Controls.Add(this.btnStartMining);
            this.pnlTemplate.Controls.Add(this.lblCoinType);
            this.pnlTemplate.Controls.Add(this.lblMinername);
            this.pnlTemplate.Controls.Add(this.pbTemplate);
            this.pnlTemplate.Location = new System.Drawing.Point(4, 5);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(366, 58);
            this.pnlTemplate.TabIndex = 3;
            this.pnlTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTemplate_Paint);
            // 
            // pbSelected
            // 
            this.pbSelected.Image = global::OneMiner.Properties.Resources.selected;
            this.pbSelected.Location = new System.Drawing.Point(0, 3);
            this.pbSelected.Name = "pbSelected";
            this.pbSelected.Size = new System.Drawing.Size(25, 24);
            this.pbSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelected.TabIndex = 4;
            this.pbSelected.TabStop = false;
            this.pbSelected.Visible = false;
            // 
            // btnStartMining
            // 
            this.btnStartMining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMining.Location = new System.Drawing.Point(287, 23);
            this.btnStartMining.Name = "btnStartMining";
            this.btnStartMining.Size = new System.Drawing.Size(53, 25);
            this.btnStartMining.TabIndex = 3;
            this.btnStartMining.Text = "Start";
            this.btnStartMining.UseVisualStyleBackColor = true;
            this.btnStartMining.Click += new System.EventHandler(this.btnStartMining_Click);
            // 
            // lblCoinType
            // 
            this.lblCoinType.AutoSize = true;
            this.lblCoinType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinType.Location = new System.Drawing.Point(83, 28);
            this.lblCoinType.Name = "lblCoinType";
            this.lblCoinType.Size = new System.Drawing.Size(58, 15);
            this.lblCoinType.TabIndex = 2;
            this.lblCoinType.Text = "CoinType";
            // 
            // lblMinername
            // 
            this.lblMinername.AutoSize = true;
            this.lblMinername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinername.Location = new System.Drawing.Point(83, 3);
            this.lblMinername.Name = "lblMinername";
            this.lblMinername.Size = new System.Drawing.Size(64, 15);
            this.lblMinername.TabIndex = 1;
            this.lblMinername.Text = "CoinName";
            // 
            // pbTemplate
            // 
            this.pbTemplate.Image = global::OneMiner.Properties.Resources.ethereum;
            this.pbTemplate.Location = new System.Drawing.Point(3, 3);
            this.pbTemplate.Name = "pbTemplate";
            this.pbTemplate.Size = new System.Drawing.Size(63, 50);
            this.pbTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTemplate.TabIndex = 0;
            this.pbTemplate.TabStop = false;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.startMiningToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteMinerToolStripMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(142, 92);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.selectToolStripMenuItem.Text = "Activate";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // startMiningToolStripMenuItem
            // 
            this.startMiningToolStripMenuItem.Name = "startMiningToolStripMenuItem";
            this.startMiningToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startMiningToolStripMenuItem.Text = "Start";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editToolStripMenuItem.Text = "Edit Miner";
            // 
            // deleteMinerToolStripMenuItem
            // 
            this.deleteMinerToolStripMenuItem.Name = "deleteMinerToolStripMenuItem";
            this.deleteMinerToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteMinerToolStripMenuItem.Text = "Delete Miner";
            // 
            // lblMinerState
            // 
            this.lblMinerState.AutoSize = true;
            this.lblMinerState.Location = new System.Drawing.Point(182, 30);
            this.lblMinerState.Name = "lblMinerState";
            this.lblMinerState.Size = new System.Drawing.Size(47, 13);
            this.lblMinerState.TabIndex = 5;
            this.lblMinerState.Text = "Stopped";
            // 
            // MinerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 67);
            this.Controls.Add(this.pnlTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MinerView";
            this.Text = "MinerView";
            this.Load += new System.EventHandler(this.MinerView_Load);
            this.pnlTemplate.ResumeLayout(false);
            this.pnlTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).EndInit();
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.PictureBox pbTemplate;
        private System.Windows.Forms.Label lblCoinType;
        private System.Windows.Forms.Label lblMinername;
        private System.Windows.Forms.Button btnStartMining;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMiningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMinerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbSelected;
        private System.Windows.Forms.Label lblMinerState;
    }
}