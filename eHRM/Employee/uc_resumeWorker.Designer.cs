namespace eHRM.Employee
{
    partial class uc_resumeWorker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_resumeWorker));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgEmpList = new Telerik.WinControls.UI.RadGridView();
            this.btnLoad = new Telerik.WinControls.UI.RadButton();
            this.btn_resume = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_resume)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEmpList
            // 
            this.dgEmpList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgEmpList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgEmpList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgEmpList.ForeColor = System.Drawing.Color.Black;
            this.dgEmpList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgEmpList.Location = new System.Drawing.Point(3, 34);
            // 
            // 
            // 
            this.dgEmpList.MasterTemplate.AllowAddNewRow = false;
            this.dgEmpList.MasterTemplate.AllowDeleteRow = false;
            this.dgEmpList.MasterTemplate.AllowEditRow = false;
            this.dgEmpList.MasterTemplate.AutoExpandGroups = true;
            this.dgEmpList.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 72;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 286;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "-";
            gridViewCommandColumn1.Width = 25;
            this.dgEmpList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.dgEmpList.MasterTemplate.EnableFiltering = true;
            this.dgEmpList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgEmpList.Name = "dgEmpList";
            this.dgEmpList.ReadOnly = true;
            this.dgEmpList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgEmpList.ShowGroupPanel = false;
            this.dgEmpList.Size = new System.Drawing.Size(421, 509);
            this.dgEmpList.TabIndex = 60;
            this.dgEmpList.Text = "radGridView1";
            this.dgEmpList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgEmpList_CommandCellClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = global::eHRM.Properties.Resources.Refresh;
            this.btnLoad.Location = new System.Drawing.Point(3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(173, 28);
            this.btnLoad.TabIndex = 59;
            this.btnLoad.Text = "Click To Load Employee";
            this.btnLoad.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resume.Location = new System.Drawing.Point(739, 504);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(90, 28);
            this.btn_resume.TabIndex = 61;
            this.btn_resume.Text = "Resume";
            this.btn_resume.Click += new System.EventHandler(this.btn_resume_Click);
            // 
            // uc_resumeWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_resume);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgEmpList);
            this.Name = "uc_resumeWorker";
            this.Size = new System.Drawing.Size(832, 546);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_resume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnLoad;
        private Telerik.WinControls.UI.RadGridView dgEmpList;
        private Telerik.WinControls.UI.RadButton btn_resume;
    }
}
