namespace OneMiner.View.v1
{
    partial class MinerInfo
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
            this.lblMinername = new System.Windows.Forms.Label();
            this.btntabScript = new System.Windows.Forms.Button();
            this.btntabLogs = new System.Windows.Forms.Button();
            this.btntabInfo = new System.Windows.Forms.Button();
            this.lblMinerType = new System.Windows.Forms.Label();
            this.pbTemplate = new System.Windows.Forms.PictureBox();
            this.lblMinerState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMinername
            // 
            this.lblMinername.AutoSize = true;
            this.lblMinername.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinername.Location = new System.Drawing.Point(82, 24);
            this.lblMinername.Name = "lblMinername";
            this.lblMinername.Size = new System.Drawing.Size(97, 20);
            this.lblMinername.TabIndex = 0;
            this.lblMinername.Text = "Defaultname";
            // 
            // btntabScript
            // 
            this.btntabScript.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btntabScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntabScript.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntabScript.Location = new System.Drawing.Point(310, 12);
            this.btntabScript.Name = "btntabScript";
            this.btntabScript.Size = new System.Drawing.Size(75, 23);
            this.btntabScript.TabIndex = 10;
            this.btntabScript.Text = "Script";
            this.btntabScript.UseVisualStyleBackColor = false;
            // 
            // btntabLogs
            // 
            this.btntabLogs.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btntabLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntabLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntabLogs.Location = new System.Drawing.Point(381, 12);
            this.btntabLogs.Name = "btntabLogs";
            this.btntabLogs.Size = new System.Drawing.Size(75, 23);
            this.btntabLogs.TabIndex = 9;
            this.btntabLogs.Text = "Log";
            this.btntabLogs.UseVisualStyleBackColor = false;
            // 
            // btntabInfo
            // 
            this.btntabInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.btntabInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntabInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntabInfo.ForeColor = System.Drawing.Color.White;
            this.btntabInfo.Location = new System.Drawing.Point(238, 12);
            this.btntabInfo.Name = "btntabInfo";
            this.btntabInfo.Size = new System.Drawing.Size(75, 23);
            this.btntabInfo.TabIndex = 8;
            this.btntabInfo.Text = "Info";
            this.btntabInfo.UseVisualStyleBackColor = false;
            this.btntabInfo.Click += new System.EventHandler(this.btntabInfo_Click);
            // 
            // lblMinerType
            // 
            this.lblMinerType.AutoSize = true;
            this.lblMinerType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinerType.Location = new System.Drawing.Point(83, 50);
            this.lblMinerType.Name = "lblMinerType";
            this.lblMinerType.Size = new System.Drawing.Size(68, 13);
            this.lblMinerType.TabIndex = 11;
            this.lblMinerType.Text = "DefaultType";
            // 
            // pbTemplate
            // 
            this.pbTemplate.Image = global::OneMiner.Properties.Resources.ethereum;
            this.pbTemplate.Location = new System.Drawing.Point(0, 24);
            this.pbTemplate.Name = "pbTemplate";
            this.pbTemplate.Size = new System.Drawing.Size(77, 63);
            this.pbTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTemplate.TabIndex = 12;
            this.pbTemplate.TabStop = false;
            // 
            // lblMinerState
            // 
            this.lblMinerState.AutoSize = true;
            this.lblMinerState.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinerState.Location = new System.Drawing.Point(83, 74);
            this.lblMinerState.Name = "lblMinerState";
            this.lblMinerState.Size = new System.Drawing.Size(70, 13);
            this.lblMinerState.TabIndex = 13;
            this.lblMinerState.Text = "Defaultstate";
            // 
            // MinerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 499);
            this.Controls.Add(this.lblMinerState);
            this.Controls.Add(this.pbTemplate);
            this.Controls.Add(this.lblMinerType);
            this.Controls.Add(this.btntabScript);
            this.Controls.Add(this.btntabLogs);
            this.Controls.Add(this.btntabInfo);
            this.Controls.Add(this.lblMinername);
            this.Name = "MinerInfo";
            this.Text = "MinerInfo";
            this.Load += new System.EventHandler(this.MinerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMinername;
        private System.Windows.Forms.Button btntabScript;
        private System.Windows.Forms.Button btntabLogs;
        private System.Windows.Forms.Button btntabInfo;
        private System.Windows.Forms.Label lblMinerType;
        private System.Windows.Forms.PictureBox pbTemplate;
        private System.Windows.Forms.Label lblMinerState;
    }
}