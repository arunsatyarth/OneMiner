namespace OneMiner.View.v1.MiningInfo
{
    partial class MinerInfoSummary
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblWalletname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnklblPool = new System.Windows.Forms.LinkLabel();
            this.pnlGpus = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Wallet ";
            // 
            // lblWalletname
            // 
            this.lblWalletname.AutoSize = true;
            this.lblWalletname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalletname.Location = new System.Drawing.Point(154, 28);
            this.lblWalletname.Name = "lblWalletname";
            this.lblWalletname.Size = new System.Drawing.Size(40, 13);
            this.lblWalletname.TabIndex = 13;
            this.lblWalletname.Text = "Wallet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Pool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = ":";
            // 
            // lnklblPool
            // 
            this.lnklblPool.AutoSize = true;
            this.lnklblPool.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblPool.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnklblPool.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnklblPool.Location = new System.Drawing.Point(154, 60);
            this.lnklblPool.Name = "lnklblPool";
            this.lnklblPool.Size = new System.Drawing.Size(30, 13);
            this.lnklblPool.TabIndex = 18;
            this.lnklblPool.TabStop = true;
            this.lnklblPool.Text = "Pool";
            // 
            // pnlGpus
            // 
            this.pnlGpus.Location = new System.Drawing.Point(12, 0);
            this.pnlGpus.Name = "pnlGpus";
            this.pnlGpus.Size = new System.Drawing.Size(825, 302);
            this.pnlGpus.TabIndex = 19;
            // 
            // MinerInfoSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 314);
            this.Controls.Add(this.pnlGpus);
            this.Controls.Add(this.lnklblPool);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWalletname);
            this.Controls.Add(this.label6);
            this.Name = "MinerInfoSummary";
            this.Text = "MinerInfoSummary";
            this.Load += new System.EventHandler(this.MinerInfoSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWalletname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnklblPool;
        private System.Windows.Forms.FlowLayoutPanel pnlGpus;
    }
}