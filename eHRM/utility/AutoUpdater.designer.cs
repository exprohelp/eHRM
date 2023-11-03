namespace eHRM
{
    partial class AutoUpdater
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDownload = new Telerik.WinControls.UI.RadButton();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmdDownload);
            this.GroupBox1.Controls.Add(this.pbDownload);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(403, 130);
            this.GroupBox1.TabIndex = 47;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Downloading";
            // 
            // cmdDownload
            // 
            this.cmdDownload.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDownload.ForeColor = System.Drawing.Color.Red;
            this.cmdDownload.Location = new System.Drawing.Point(134, 61);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 41);
            this.cmdDownload.TabIndex = 53;
            this.cmdDownload.Text = "Update Software";
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.cmdDownload.GetChildAt(0))).Text = "Update Software";
            // 
            // pbDownload
            // 
            this.pbDownload.Enabled = false;
            this.pbDownload.Location = new System.Drawing.Point(7, 22);
            this.pbDownload.MarqueeAnimationSpeed = 35;
            this.pbDownload.Maximum = 50;
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(390, 23);
            this.pbDownload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbDownload.TabIndex = 52;
            this.pbDownload.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.HotPink;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 48;
            // 
            // AutoUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 130);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AutoUpdater";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUTO UPDATION OF SOFTWARE";
            this.Load += new System.EventHandler(this.AutoUpdater_Load);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton cmdDownload;


    }
}