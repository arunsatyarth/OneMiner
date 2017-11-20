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
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.btnStartMining = new System.Windows.Forms.Button();
            this.lblCoinType = new System.Windows.Forms.Label();
            this.lblMinername = new System.Windows.Forms.Label();
            this.pbTemplate = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.BackColor = System.Drawing.Color.White;
            this.pnlTemplate.Controls.Add(this.btnStartMining);
            this.pnlTemplate.Controls.Add(this.lblCoinType);
            this.pnlTemplate.Controls.Add(this.lblMinername);
            this.pnlTemplate.Controls.Add(this.pbTemplate);
            this.pnlTemplate.Location = new System.Drawing.Point(4, 5);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(385, 58);
            this.pnlTemplate.TabIndex = 3;
            this.pnlTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTemplate_Paint);
            // 
            // btnStartMining
            // 
            this.btnStartMining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMining.Location = new System.Drawing.Point(278, 18);
            this.btnStartMining.Name = "btnStartMining";
            this.btnStartMining.Size = new System.Drawing.Size(75, 23);
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
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Location = new System.Drawing.Point(332, 5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(25, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MinerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(388, 64);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pnlTemplate);
            this.Name = "MinerView";
            this.Text = "MinerView";
            this.Load += new System.EventHandler(this.MinerView_Load);
            this.pnlTemplate.ResumeLayout(false);
            this.pnlTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.PictureBox pbTemplate;
        private System.Windows.Forms.Label lblCoinType;
        private System.Windows.Forms.Label lblMinername;
        private System.Windows.Forms.Button btnStartMining;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}