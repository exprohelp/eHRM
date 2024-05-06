namespace eHRM.Doc
{
    partial class ucDocView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDocView));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.radpdfViewer = new Telerik.WinControls.UI.RadPdfViewer();
            this.rgv_search = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radpdfViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_search.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(1131, 578);
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.rgv_search);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel1.Size = new System.Drawing.Size(404, 578);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1414097F, 0F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-161, 0);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.radpdfViewer);
            this.splitPanel2.Location = new System.Drawing.Point(408, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel2.Size = new System.Drawing.Size(723, 578);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1414097F, 0F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(161, 0);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // radpdfViewer
            // 
            this.radpdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radpdfViewer.Location = new System.Drawing.Point(0, 0);
            this.radpdfViewer.Name = "radpdfViewer";
            this.radpdfViewer.Size = new System.Drawing.Size(723, 578);
            this.radpdfViewer.TabIndex = 110;
            this.radpdfViewer.Text = "radPdfViewer1";
            this.radpdfViewer.ThumbnailsScaleFactor = 0.15F;
            // 
            // rgv_search
            // 
            this.rgv_search.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_search.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rgv_search.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_search.ForeColor = System.Drawing.Color.Black;
            this.rgv_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_search.Location = new System.Drawing.Point(0, 3);
            // 
            // 
            // 
            this.rgv_search.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "autoid";
            gridViewTextBoxColumn1.HeaderText = "autoID";
            gridViewTextBoxColumn1.Name = "autoid";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "docname";
            gridViewTextBoxColumn2.HeaderText = "Name of Document";
            gridViewTextBoxColumn2.Name = "docname";
            gridViewTextBoxColumn2.Width = 301;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 25;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DocPath";
            gridViewTextBoxColumn3.HeaderText = "DocPath";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "DocPath";
            this.rgv_search.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewTextBoxColumn3});
            this.rgv_search.MasterTemplate.EnableFiltering = true;
            this.rgv_search.MasterTemplate.EnableGrouping = false;
            this.rgv_search.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_search.Name = "rgv_search";
            this.rgv_search.ReadOnly = true;
            this.rgv_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_search.Size = new System.Drawing.Size(404, 575);
            this.rgv_search.TabIndex = 1;
            this.rgv_search.Text = "radGridView1";
            this.rgv_search.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_search_CommandCellClick);
            // 
            // ucDocView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 578);
            this.Controls.Add(this.radSplitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucDocView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ucDocView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radpdfViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_search.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadPdfViewer radpdfViewer;
        private Telerik.WinControls.UI.RadGridView rgv_search;
    }
}
