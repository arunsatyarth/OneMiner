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
            this.lstAlgoSelect = new System.Windows.Forms.ListView();
            this.lstCoinSelect = new System.Windows.Forms.ListView();
            this.btnNext = new System.Windows.Forms.Button();
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
            // lstAlgoSelect
            // 
            this.lstAlgoSelect.Location = new System.Drawing.Point(163, 106);
            this.lstAlgoSelect.Name = "lstAlgoSelect";
            this.lstAlgoSelect.Size = new System.Drawing.Size(162, 153);
            this.lstAlgoSelect.TabIndex = 3;
            this.lstAlgoSelect.UseCompatibleStateImageBehavior = false;
            // 
            // lstCoinSelect
            // 
            this.lstCoinSelect.Location = new System.Drawing.Point(432, 106);
            this.lstCoinSelect.Name = "lstCoinSelect";
            this.lstCoinSelect.Size = new System.Drawing.Size(162, 153);
            this.lstCoinSelect.TabIndex = 4;
            this.lstCoinSelect.UseCompatibleStateImageBehavior = false;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(486, 355);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // AddMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 433);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lstCoinSelect);
            this.Controls.Add(this.lstAlgoSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinername);
            this.Controls.Add(this.label1);
            this.Name = "AddMiner";
            this.Text = "AddMiner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstAlgoSelect;
        private System.Windows.Forms.ListView lstCoinSelect;
        private System.Windows.Forms.Button btnNext;
    }
}