namespace eHRM
{
    partial class AdvanceCSVImport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnprocess = new Telerik.WinControls.UI.RadButton();
            this.rd_app_date = new Telerik.WinControls.UI.RadDateTimePicker();
            this.gvr_data = new Telerik.WinControls.UI.RadGridView();
            this.btn_browse = new Telerik.WinControls.UI.RadButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFileName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.gvr_procc_data = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_browsecount = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_processedcount = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnprocess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rd_app_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_data.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_browse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_procc_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_procc_data.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_browsecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_processedcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnprocess
            // 
            this.btnprocess.Location = new System.Drawing.Point(746, 14);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(91, 24);
            this.btnprocess.TabIndex = 0;
            this.btnprocess.Text = "Process";
            this.btnprocess.Click += new System.EventHandler(this.btnprocess_Click);
            // 
            // rd_app_date
            // 
            this.rd_app_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rd_app_date.Location = new System.Drawing.Point(53, 12);
            this.rd_app_date.Name = "rd_app_date";
            this.rd_app_date.Size = new System.Drawing.Size(86, 20);
            this.rd_app_date.TabIndex = 0;
            this.rd_app_date.TabStop = false;
            this.rd_app_date.Text = "05/01/2017";
            this.rd_app_date.Value = new System.DateTime(2017, 1, 5, 12, 44, 2, 49);
            // 
            // gvr_data
            // 
            this.gvr_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gvr_data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvr_data.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gvr_data.ForeColor = System.Drawing.Color.Black;
            this.gvr_data.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvr_data.Location = new System.Drawing.Point(2, 44);
            // 
            // 
            // 
            this.gvr_data.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 97;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "emp_name";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 181;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "amount";
            gridViewTextBoxColumn3.HeaderText = "amount";
            gridViewTextBoxColumn3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Name = "amount";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 65;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "reason";
            gridViewTextBoxColumn4.HeaderText = "reason";
            gridViewTextBoxColumn4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn4.Name = "reason";
            gridViewTextBoxColumn4.Width = 282;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "adjDate";
            gridViewTextBoxColumn5.HeaderText = "adjDate";
            gridViewTextBoxColumn5.Name = "adjDate";
            gridViewTextBoxColumn5.Width = 79;
            this.gvr_data.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvr_data.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "app_date";
            this.gvr_data.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.gvr_data.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvr_data.Name = "gvr_data";
            this.gvr_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvr_data.Size = new System.Drawing.Size(738, 421);
            this.gvr_data.TabIndex = 1;
            this.gvr_data.Text = "radGridView1";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(359, 10);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(53, 24);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "Browse";
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(157, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(196, 20);
            this.txtFileName.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 11);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(35, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Date";
            // 
            // gvr_procc_data
            // 
            this.gvr_procc_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gvr_procc_data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvr_procc_data.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gvr_procc_data.ForeColor = System.Drawing.Color.Black;
            this.gvr_procc_data.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvr_procc_data.Location = new System.Drawing.Point(746, 44);
            // 
            // 
            // 
            this.gvr_procc_data.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "emp_code";
            gridViewTextBoxColumn6.HeaderText = "Emp Code";
            gridViewTextBoxColumn6.Name = "emp_code";
            gridViewTextBoxColumn6.Width = 90;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "emp_name";
            gridViewTextBoxColumn7.HeaderText = "Name";
            gridViewTextBoxColumn7.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn7.Name = "emp_name";
            gridViewTextBoxColumn7.Width = 172;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "adv_amount";
            gridViewTextBoxColumn8.HeaderText = "Amount";
            gridViewTextBoxColumn8.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Name = "amount";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 65;
            this.gvr_procc_data.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.gvr_procc_data.MasterTemplate.EnableGrouping = false;
            this.gvr_procc_data.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvr_procc_data.Name = "gvr_procc_data";
            this.gvr_procc_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvr_procc_data.Size = new System.Drawing.Size(360, 421);
            this.gvr_procc_data.TabIndex = 4;
            this.gvr_procc_data.Text = "radGridView1";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(608, 20);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 18);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Raw Data";
            // 
            // lbl_browsecount
            // 
            this.lbl_browsecount.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_browsecount.Location = new System.Drawing.Point(680, 20);
            this.lbl_browsecount.Name = "lbl_browsecount";
            this.lbl_browsecount.Size = new System.Drawing.Size(39, 18);
            this.lbl_browsecount.TabIndex = 6;
            this.lbl_browsecount.Text = "Count";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(963, 20);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(89, 18);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Processed Data";
            // 
            // lbl_processedcount
            // 
            this.lbl_processedcount.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_processedcount.Location = new System.Drawing.Point(1058, 20);
            this.lbl_processedcount.Name = "lbl_processedcount";
            this.lbl_processedcount.Size = new System.Drawing.Size(39, 18);
            this.lbl_processedcount.TabIndex = 6;
            this.lbl_processedcount.Text = "Count";
            // 
            // AdvanceCSVImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 469);
            this.Controls.Add(this.lbl_processedcount);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lbl_browsecount);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.gvr_procc_data);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.gvr_data);
            this.Controls.Add(this.rd_app_date);
            this.Controls.Add(this.btnprocess);
            this.Name = "AdvanceCSVImport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance Bulk Import by CSV";
            this.Load += new System.EventHandler(this.AdvanceCSVImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnprocess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rd_app_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_data.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_browse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_procc_data.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr_procc_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_browsecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_processedcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnprocess;
        private Telerik.WinControls.UI.RadDateTimePicker rd_app_date;
        private Telerik.WinControls.UI.RadGridView gvr_data;
        private Telerik.WinControls.UI.RadButton btn_browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadTextBox txtFileName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGridView gvr_procc_data;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lbl_browsecount;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel lbl_processedcount;

    }
}
