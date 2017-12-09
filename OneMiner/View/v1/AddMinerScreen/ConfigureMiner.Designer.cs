namespace OneMiner.View.v1
{
    partial class ConfigureMiner
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPool = new System.Windows.Forms.TextBox();
            this.txtWallet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCoinName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pool";
            // 
            // txtPool
            // 
            this.txtPool.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPool.Location = new System.Drawing.Point(197, 91);
            this.txtPool.Name = "txtPool";
            this.txtPool.Size = new System.Drawing.Size(285, 23);
            this.txtPool.TabIndex = 1;
            this.txtPool.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtWallet
            // 
            this.txtWallet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWallet.Location = new System.Drawing.Point(197, 128);
            this.txtWallet.Name = "txtWallet";
            this.txtWallet.Size = new System.Drawing.Size(285, 23);
            this.txtWallet.TabIndex = 3;
            this.txtWallet.TextChanged += new System.EventHandler(this.txtWallet_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wallet Address";
            // 
            // lblCoinName
            // 
            this.lblCoinName.AutoSize = true;
            this.lblCoinName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinName.Location = new System.Drawing.Point(84, 24);
            this.lblCoinName.Name = "lblCoinName";
            this.lblCoinName.Size = new System.Drawing.Size(81, 20);
            this.lblCoinName.TabIndex = 4;
            this.lblCoinName.Text = "CoinName";
            // 
            // ConfigureMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(708, 394);
            this.Controls.Add(this.lblCoinName);
            this.Controls.Add(this.txtWallet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPool);
            this.Controls.Add(this.label1);
            this.Name = "ConfigureMiner";
            this.Text = "ConfigureMiner";
            this.Load += new System.EventHandler(this.ConfigureMiner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPool;
        private System.Windows.Forms.TextBox txtWallet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoinName;
    }
}