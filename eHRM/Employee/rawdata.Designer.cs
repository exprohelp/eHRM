namespace eHRM.Employee
{
    partial class rawdata
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rclb_data = new Telerik.WinControls.UI.RadCheckedListBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbInJob = new System.Windows.Forms.CheckBox();
            this.rbtn_excel = new Telerik.WinControls.UI.RadButton();
            this.rbtnSubmit = new Telerik.WinControls.UI.RadButton();
            this.rgv_data = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rclb_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rclb_data
            // 
            this.rclb_data.ItemSpacing = -1;
            this.rclb_data.Location = new System.Drawing.Point(3, 3);
            this.rclb_data.Name = "rclb_data";
            this.rclb_data.Size = new System.Drawing.Size(211, 510);
            this.rclb_data.TabIndex = 1;
            this.rclb_data.Text = "radCheckedListBox1";
            this.rclb_data.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cbInJob);
            this.radGroupBox1.Controls.Add(this.rbtn_excel);
            this.radGroupBox1.Controls.Add(this.rbtnSubmit);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(217, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1024, 46);
            this.radGroupBox1.TabIndex = 2;
            // 
            // cbInJob
            // 
            this.cbInJob.AutoSize = true;
            this.cbInJob.Checked = true;
            this.cbInJob.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInJob.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInJob.Location = new System.Drawing.Point(8, 11);
            this.cbInJob.Name = "cbInJob";
            this.cbInJob.Size = new System.Drawing.Size(73, 25);
            this.cbInJob.TabIndex = 2;
            this.cbInJob.Text = "In Job";
            this.cbInJob.UseVisualStyleBackColor = true;
            this.cbInJob.CheckedChanged += new System.EventHandler(this.cbInJob_CheckedChanged);
            // 
            // rbtn_excel
            // 
            this.rbtn_excel.Image = global::eHRM.Properties.Resources.export_excel;
            this.rbtn_excel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_excel.Location = new System.Drawing.Point(981, 7);
            this.rbtn_excel.Name = "rbtn_excel";
            this.rbtn_excel.Size = new System.Drawing.Size(38, 34);
            this.rbtn_excel.TabIndex = 1;
            this.rbtn_excel.Click += new System.EventHandler(this.rbtn_excel_Click);
            // 
            // rbtnSubmit
            // 
            this.rbtnSubmit.Image = global::eHRM.Properties.Resources.click_32;
            this.rbtnSubmit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnSubmit.Location = new System.Drawing.Point(123, 7);
            this.rbtnSubmit.Name = "rbtnSubmit";
            this.rbtnSubmit.Size = new System.Drawing.Size(40, 34);
            this.rbtnSubmit.TabIndex = 0;
            this.rbtnSubmit.Click += new System.EventHandler(this.rbtnSubmit_Click);
            // 
            // rgv_data
            // 
            this.rgv_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_data.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_data.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_data.ForeColor = System.Drawing.Color.Black;
            this.rgv_data.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_data.Location = new System.Drawing.Point(221, 56);
            // 
            // 
            // 
            this.rgv_data.MasterTemplate.AllowAddNewRow = false;
            this.rgv_data.MasterTemplate.EnableFiltering = true;
            this.rgv_data.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_data.Name = "rgv_data";
            this.rgv_data.ReadOnly = true;
            this.rgv_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_data.Size = new System.Drawing.Size(1020, 457);
            this.rgv_data.TabIndex = 3;
            this.rgv_data.Text = "radGridView1";
            // 
            // rawdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 513);
            this.Controls.Add(this.rgv_data);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.rclb_data);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "rawdata";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Raw Data of Employee Table";
            this.Load += new System.EventHandler(this.rawdata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rclb_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckedListBox rclb_data;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView rgv_data;
        private Telerik.WinControls.UI.RadButton rbtn_excel;
        private Telerik.WinControls.UI.RadButton rbtnSubmit;
        private System.Windows.Forms.CheckBox cbInJob;
    }
}
