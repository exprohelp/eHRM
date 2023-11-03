namespace eHRM.Employee
{
    partial class NewJoingReport
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
            this.rgv_data = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdp_date = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtn_excel = new Telerik.WinControls.UI.RadButton();
            this.rbtnSubmit = new Telerik.WinControls.UI.RadButton();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_data
            // 
            this.rgv_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_data.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgv_data.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_data.ForeColor = System.Drawing.Color.Black;
            this.rgv_data.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_data.Location = new System.Drawing.Point(0, 46);
            // 
            // 
            // 
            this.rgv_data.MasterTemplate.AllowAddNewRow = false;
            this.rgv_data.MasterTemplate.EnableFiltering = true;
            this.rgv_data.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_data.Name = "rgv_data";
            this.rgv_data.ReadOnly = true;
            this.rgv_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_data.Size = new System.Drawing.Size(1148, 492);
            this.rgv_data.TabIndex = 5;
            this.rgv_data.Text = "radGridView1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.cmbCompany);
            this.radGroupBox1.Controls.Add(this.rdp_date);
            this.radGroupBox1.Controls.Add(this.rbtn_excel);
            this.radGroupBox1.Controls.Add(this.rbtnSubmit);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1148, 46);
            this.radGroupBox1.TabIndex = 4;
            // 
            // rdp_date
            // 
            this.rdp_date.CustomFormat = "MM-yyyy";
            this.rdp_date.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.rdp_date.Location = new System.Drawing.Point(288, 14);
            this.rdp_date.Name = "rdp_date";
            this.rdp_date.Size = new System.Drawing.Size(95, 27);
            this.rdp_date.TabIndex = 2;
            this.rdp_date.TabStop = false;
            this.rdp_date.Text = "06-2017";
            this.rdp_date.Value = new System.DateTime(2017, 6, 30, 13, 24, 55, 407);
            // 
            // rbtn_excel
            // 
            this.rbtn_excel.Image = global::eHRM.Properties.Resources.export_excel;
            this.rbtn_excel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_excel.Location = new System.Drawing.Point(1098, 7);
            this.rbtn_excel.Name = "rbtn_excel";
            this.rbtn_excel.Size = new System.Drawing.Size(38, 34);
            this.rbtn_excel.TabIndex = 1;
            this.rbtn_excel.Click += new System.EventHandler(this.rbtn_excel_Click);
            // 
            // rbtnSubmit
            // 
            this.rbtnSubmit.Image = global::eHRM.Properties.Resources.click_32;
            this.rbtnSubmit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnSubmit.Location = new System.Drawing.Point(400, 7);
            this.rbtnSubmit.Name = "rbtnSubmit";
            this.rbtnSubmit.Size = new System.Drawing.Size(40, 34);
            this.rbtnSubmit.TabIndex = 0;
            this.rbtnSubmit.Click += new System.EventHandler(this.rbtnSubmit_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "CHL",
            "CHCL",
            "IDC",
            "ALL"});
            this.cmbCompany.Location = new System.Drawing.Point(82, 14);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(84, 25);
            this.cmbCompany.TabIndex = 3;
            this.cmbCompany.Text = "ALL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Company";
            // 
            // NewJoingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 538);
            this.Controls.Add(this.rgv_data);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewJoingReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Joining Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewJoingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_data;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_date;
        private Telerik.WinControls.UI.RadButton rbtn_excel;
        private Telerik.WinControls.UI.RadButton rbtnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompany;
    }
}