namespace OneMiner.View.v1.MiningInfo
{
    partial class MinerInfoLogs
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
            this.btnTemplate = new System.Windows.Forms.Button();
            this.logBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTemplate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplate.ForeColor = System.Drawing.Color.White;
            this.btnTemplate.Location = new System.Drawing.Point(-50, 12);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(67, 23);
            this.btnTemplate.TabIndex = 12;
            this.btnTemplate.Text = "Default";
            this.btnTemplate.UseVisualStyleBackColor = false;
            this.btnTemplate.Visible = false;
            // 
            // logBrowser
            // 
            this.logBrowser.IsWebBrowserContextMenuEnabled = false;
            this.logBrowser.Location = new System.Drawing.Point(9, 41);
            this.logBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.logBrowser.Name = "logBrowser";
            this.logBrowser.ScriptErrorsSuppressed = true;
            this.logBrowser.Size = new System.Drawing.Size(828, 213);
            this.logBrowser.TabIndex = 13;
            // 
            // MinerInfoLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1017, 523);
            this.Controls.Add(this.logBrowser);
            this.Controls.Add(this.btnTemplate);
            this.Name = "MinerInfoLogs";
            this.Text = "MinerInfoLogs";
            this.Load += new System.EventHandler(this.MinerInfoLogs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.WebBrowser logBrowser;
    }
}