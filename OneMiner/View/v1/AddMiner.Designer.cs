namespace OneMiner.View.v1
{
    partial class AddMiner
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
            this.txtMinername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAlgoSelect = new System.Windows.Forms.ListBox();
            this.lbCoinSelect = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectedCoin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Miner Name";
            // 
            // txtMinername
            // 
            this.txtMinername.Location = new System.Drawing.Point(322, 28);
            this.txtMinername.Name = "txtMinername";
            this.txtMinername.Size = new System.Drawing.Size(121, 20);
            this.txtMinername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Coin";
            // 
            // lbAlgoSelect
            // 
            this.lbAlgoSelect.FormattingEnabled = true;
            this.lbAlgoSelect.Location = new System.Drawing.Point(163, 111);
            this.lbAlgoSelect.Name = "lbAlgoSelect";
            this.lbAlgoSelect.Size = new System.Drawing.Size(162, 160);
            this.lbAlgoSelect.TabIndex = 6;
            // 
            // lbCoinSelect
            // 
            this.lbCoinSelect.FormattingEnabled = true;
            this.lbCoinSelect.Location = new System.Drawing.Point(348, 111);
            this.lbCoinSelect.Name = "lbCoinSelect";
            this.lbCoinSelect.Size = new System.Drawing.Size(162, 160);
            this.lbCoinSelect.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Selected Coin";
            // 
            // lblSelectedCoin
            // 
            this.lblSelectedCoin.AutoSize = true;
            this.lblSelectedCoin.Location = new System.Drawing.Point(319, 297);
            this.lblSelectedCoin.Name = "lblSelectedCoin";
            this.lblSelectedCoin.Size = new System.Drawing.Size(88, 13);
            this.lblSelectedCoin.TabIndex = 9;
            this.lblSelectedCoin.Text = "Default Selection";
            // 
            // AddMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 531);
            this.Controls.Add(this.lblSelectedCoin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCoinSelect);
            this.Controls.Add(this.lbAlgoSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinername);
            this.Controls.Add(this.label1);
            this.Name = "AddMiner";
            this.Text = "AddMiner";
            this.Load += new System.EventHandler(this.AddMiner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAlgoSelect;
        private System.Windows.Forms.ListBox lbCoinSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelectedCoin;
    }
}