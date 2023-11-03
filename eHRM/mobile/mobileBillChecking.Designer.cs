namespace eHRM.mobile
{
    partial class mobileBillChecking
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mobileBillChecking));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.rt_filename = new Telerik.WinControls.UI.RadTextBox();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.rbtn_excel = new Telerik.WinControls.UI.RadButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radPdfViewer1 = new Telerik.WinControls.UI.RadPdfViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.radDateTimePicker1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnDel = new Telerik.WinControls.UI.RadButton();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rt_filename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.Color.Black;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(1, 28);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "mobile_no";
            gridViewTextBoxColumn1.HeaderText = "Mobile No.";
            gridViewTextBoxColumn1.Name = "mobile_no";
            gridViewTextBoxColumn1.Width = 108;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "worker_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Staff";
            gridViewTextBoxColumn2.Name = "worker_name";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 389;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "branch";
            gridViewTextBoxColumn3.HeaderText = "Branch";
            gridViewTextBoxColumn3.Name = "branch";
            gridViewTextBoxColumn3.Width = 181;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "status";
            gridViewTextBoxColumn4.HeaderText = "Status";
            gridViewTextBoxColumn4.Name = "status";
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "total";
            gridViewDecimalColumn1.FormatString = "{0:N0}";
            gridViewDecimalColumn1.HeaderText = "Total";
            gridViewDecimalColumn1.Name = "Total";
            gridViewDecimalColumn1.Width = 61;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "Payable";
            gridViewDecimalColumn2.FormatString = "{0:N0}";
            gridViewDecimalColumn2.HeaderText = "Payable";
            gridViewDecimalColumn2.Name = "Payable";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 25;
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewCommandColumn1});
            this.rgv_info.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "worker_name";
            this.rgv_info.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.Size = new System.Drawing.Size(896, 197);
            this.rgv_info.TabIndex = 3;
            this.rgv_info.Text = "radGridView1";
            this.rgv_info.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_info_CommandCellClick);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(488, 1);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(22, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "...";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // rt_filename
            // 
            this.rt_filename.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rt_filename.Location = new System.Drawing.Point(32, 2);
            this.rt_filename.Name = "rt_filename";
            this.rt_filename.NullText = "Name of CSV File";
            this.rt_filename.Size = new System.Drawing.Size(453, 23);
            this.rt_filename.TabIndex = 1;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.rt_filename.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.rt_filename.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // rbtn_excel
            // 
            this.rbtn_excel.Location = new System.Drawing.Point(533, 1);
            this.rbtn_excel.Name = "rbtn_excel";
            this.rbtn_excel.Size = new System.Drawing.Size(72, 24);
            this.rbtn_excel.TabIndex = 0;
            this.rbtn_excel.Text = "Import CSV";
            this.rbtn_excel.Click += new System.EventHandler(this.rbtn_excel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radPdfViewer1
            // 
            this.radPdfViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPdfViewer1.Location = new System.Drawing.Point(0, 231);
            this.radPdfViewer1.Name = "radPdfViewer1";
            this.radPdfViewer1.Size = new System.Drawing.Size(897, 389);
            this.radPdfViewer1.TabIndex = 4;
            this.radPdfViewer1.Text = "radPdfViewer1";
            this.radPdfViewer1.ThumbnailsScaleFactor = 0.15F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(653, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bill Date";
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.radDateTimePicker1.Location = new System.Drawing.Point(722, 0);
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            this.radDateTimePicker1.Size = new System.Drawing.Size(104, 25);
            this.radDateTimePicker1.TabIndex = 6;
            this.radDateTimePicker1.TabStop = false;
            this.radDateTimePicker1.Text = "18/04/2016";
            this.radDateTimePicker1.Value = new System.DateTime(2016, 4, 18, 12, 54, 47, 908);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::eHRM.Properties.Resources.delete_16;
            this.btnDel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDel.Location = new System.Drawing.Point(1, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(25, 25);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Import CSV";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDel.GetChildAt(0))).Image = global::eHRM.Properties.Resources.delete_16;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDel.GetChildAt(0))).Text = "Import CSV";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDel.GetChildAt(0))).Shape = this.ellipseShape1;
            // 
            // mobileBillChecking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 620);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.radDateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radPdfViewer1);
            this.Controls.Add(this.rgv_info);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.rbtn_excel);
            this.Controls.Add(this.rt_filename);
            this.Name = "mobileBillChecking";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Bill Checking";
            this.Load += new System.EventHandler(this.mobileBillChecking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rt_filename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton rbtn_excel;
        private Telerik.WinControls.UI.RadGridView rgv_info;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox rt_filename;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer1;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
        private Telerik.WinControls.UI.RadButton btnDel;
        private Telerik.WinControls.EllipseShape ellipseShape1;
    }
}
