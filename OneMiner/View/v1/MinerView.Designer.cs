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
            this.pbTemplate = new System.Windows.Forms.PictureBox();
            this.lblMinername = new System.Windows.Forms.Label();
            this.lblCoinType = new System.Windows.Forms.Label();
            this.pnlTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.Controls.Add(this.lblCoinType);
            this.pnlTemplate.Controls.Add(this.lblMinername);
            this.pnlTemplate.Controls.Add(this.pbTemplate);
            this.pnlTemplate.Location = new System.Drawing.Point(12, 12);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(385, 58);
            this.pnlTemplate.TabIndex = 3;
            this.pnlTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTemplate_Paint);
            // 
            // pbTemplate
            // 
            this.pbTemplate.Location = new System.Drawing.Point(3, 3);
            this.pbTemplate.Name = "pbTemplate";
            this.pbTemplate.Size = new System.Drawing.Size(63, 50);
            this.pbTemplate.TabIndex = 0;
            this.pbTemplate.TabStop = false;
            // 
            // lblMinername
            // 
            this.lblMinername.AutoSize = true;
            this.lblMinername.Location = new System.Drawing.Point(83, 3);
            this.lblMinername.Name = "lblMinername";
            this.lblMinername.Size = new System.Drawing.Size(56, 13);
            this.lblMinername.TabIndex = 1;
            this.lblMinername.Text = "CoinName";
            // 
            // lblCoinType
            // 
            this.lblCoinType.AutoSize = true;
            this.lblCoinType.Location = new System.Drawing.Point(83, 28);
            this.lblCoinType.Name = "lblCoinType";
            this.lblCoinType.Size = new System.Drawing.Size(52, 13);
            this.lblCoinType.TabIndex = 2;
            this.lblCoinType.Text = "CoinType";
            // 
            // MinerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 98);
            this.Controls.Add(this.pnlTemplate);
            this.Name = "MinerView";
            this.Text = "MinerView";
            this.Load += new System.EventHandler(this.MinerView_Load);
            this.pnlTemplate.ResumeLayout(false);
            this.pnlTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.PictureBox pbTemplate;
        private System.Windows.Forms.Label lblCoinType;
        private System.Windows.Forms.Label lblMinername;
    }
}