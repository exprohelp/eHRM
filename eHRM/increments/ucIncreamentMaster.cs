using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinForms.Documents.FormatProviders.Html;
using Telerik.WinForms.Documents.Model;
using Telerik.WinForms.Documents.FormatProviders.OpenXml.Docx;
using System.IO;
using Telerik.WinForms.Documents.Model.Styles;
using Telerik.WinForms.Documents.Layout;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinForms.Documents.DocumentStructure;
using Telerik.WinForms.Documents.FormatProviders.Xaml;
using Telerik.WinForms.Documents.FormatProviders.Pdf;
using System.Data.SqlClient;
namespace eHRM.increments
{
    public partial class ucIncreamentMaster : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _qry = string.Empty; DataSet _ds = new DataSet();
        string _empcode = string.Empty; string _emailSendBy = string.Empty;
        string fin_year = string.Empty; string _staffType = string.Empty;
        private Telerik.WinControls.UI.RadRichTextEditor ReportEditor;
        public ucIncreamentMaster()
        {
            InitializeComponent();
        }

        private void uc_Letters_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 160);//Initialize Investigation

            btnMail.Enabled = false; 
            dtp_Date.Value = DateTime.Today.AddMonths(1);
            //dtp_Date.MinDate = DateTime.Today.AddMonths(-2);
        }
        private void GetIncreamentLetterDocument(string emp_code)
        {
            try
            {
                txtCode.Text = emp_code;
                pnlControl.Controls.Clear();
                ReportEditor = new Telerik.WinControls.UI.RadRichTextEditor();
                ReportEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                ReportEditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
                ReportEditor.LayoutMode = Telerik.WinForms.Documents.Model.DocumentLayoutMode.Paged;
                ReportEditor.Name = "ReportEditor";
                ReportEditor.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
                ReportEditor.Dock = System.Windows.Forms.DockStyle.Fill;
                //Page Setup
                ReportEditor.Document.SectionDefaultPageSize = PaperTypeConverter.ToSize(PaperTypes.A4);
                ReportEditor.LayoutMode = DocumentLayoutMode.Paged;
                ReportEditor.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(25, 15, 25, 20);

                ReportEditor.TabIndex = 1;
                ReportEditor.Document = new RadDocument();
                pnlControl.Controls.Add(ReportEditor);

                string qry = "execute pIncreatmentLetter '" +rgv_info.CurrentRow.Cells["Emp Id"].Value.ToString() + "','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "'";
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                _empcode = emp_code;
                if (_ds.Tables[0].Rows[0]["status"].ToString().ToUpper().Contains("PROFESSIONAL"))
                {
                    _staffType = "Professional";
                    ReportEditor.Document = IncreamentLetterProfessional(_ds);
                }
                else if (_ds.Tables[0].Rows[0]["status"].ToString().ToUpper().Contains("SPCA"))
                {
                    _staffType = "SPCA";
                    ReportEditor.Document = ContractLetterToSPCA(_ds);
                }
                else
                {
                    _staffType = "Normal";
                    ReportEditor.Document = IncreamentLetterGeneral(_ds);
                }
                int pagesCount = DocumentStructureCollection.GetChildrenCount(ReportEditor.Document.DocumentLayoutBox);
                
                ReportEditor.Document.SectionDefaultPageSize = PaperTypeConverter.ToSize(PaperTypes.Letter);
                ReportEditor.LayoutMode = DocumentLayoutMode.Paged;
                ReportEditor.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(20, 10, 30, 10);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private RadDocument IncreamentLetterGeneral(DataSet ds)
        {
            RadDocument document = ReportEditor.Document;
            DataRow dr = ds.Tables[0].Rows[0];
            DataRow d1 = ds.Tables[1].Rows[0];
            Section section = new Section();
           
            Table tableblock = new Table();
            tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            tableblock.Tag = "Block";
            section.Blocks.Add(tableblock);

            string path = Application.StartupPath + "\\ChandanLogo.jpg";
            TableRow rowblock = new TableRow();
            byte[] logo = System.IO.File.ReadAllBytes(path);
            TableCell logoCell =GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo,120, 50);
            logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(logoCell);

            TableCell tcaddress =GetAddressCell(d1["comp_name"].ToString(),"Corp. Office : "+ d1["corp_office_add"].ToString(), "Reg. Office : "+d1["reg_office"].ToString(), d1["Phone_No"].ToString(),"CIN NO : "+ d1["CIN_no"].ToString() ,80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black,12, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(tcaddress);
            tableblock.Rows.Add(rowblock);

            Table table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            TableRow tr = new TableRow();
            tr = new TableRow();
            tr.Height = 40;
            var Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + dr["letter_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Printing Date : " +System.DateTime.Now.ToString("dd-MM-yyyy"), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To, ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Code            : ", dr["emp_code"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Name           : ", dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Designation   : ", dr["designation"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Dear ", dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 35;
            Cell = GetMiddleTextBold("This is to inform you that your remuneration will be as below w.e.f. ", dr["app_date"].ToString(), " . You are also subject to deduction as per Govt.rules. ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            //Cell = GetCell("This is to inform you that your remuneration will be as below w.e.f. "+dr["app_date"].ToString()+"", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #region Increament Block

            table = new Table();
            table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            table.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("SALARY (BASIC+DA)", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bp"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["hr"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("HRA", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["hr"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["pb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PERFORMANCE BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["ecb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ELITE CLUB BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["ecb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["bo"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bo"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY GROSS SALARY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gross_salary"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("BENEFITS :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" ", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ESI CONTRIBUTION (Insurance benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["esi"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("PF CONTRIBUTION (Retiral benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pf"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 20;
            //Cell = GetCell("GRATUITY (Retiral benefit)* :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //Cell = GetCell("Rs. " + Convert.ToDecimal(dr["Gratuity"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY COST TO COMPANY: :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["mth_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
                    
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ANNUAL COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["yearly_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            Cell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black),new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            string str = "In the year ahead,you are expected to perform with a greater zeal and enthusiasm to acheive";
            str = str + "organizational goals. We are sure that you will prove yourself worthy of the trust and expectation";
            str = str + "that the management has bestowed on you. ";
            str = str + "Wishing you all the best for the upcoming assignments and responsibilities.";
            str = str + "All other terms & conditions as contained in your appointment letter and services rule book will remain applicable.";
            section.Blocks.Add(getParagraphText(str, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12));


            #endregion

            #region Signature Block

            DataTable dtSignature = ds.Tables[1];

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 80;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dtSignature.Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dtSignature.Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

           
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 16, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion
            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }
        private RadDocument ContractLetterToSPCA(DataSet ds)
        {
            RadDocument document = ReportEditor.Document;
            DataRow dr = ds.Tables[0].Rows[0];
            DataRow d1 = ds.Tables[1].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            tableblock.Tag = "Block";
            section.Blocks.Add(tableblock);
            string path = Application.StartupPath + "\\ChandanLogo.jpg";
            TableRow rowblock = new TableRow();
            byte[] logo = System.IO.File.ReadAllBytes(path);
            TableCell logoCell = GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo, 120, 50);
            logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));

            rowblock.Cells.Add(logoCell);
            TableCell tcaddress = GetAddressCell(d1["comp_name"].ToString(), "Corp. Office : " + d1["corp_office_add"].ToString(), "Reg. Office : " + d1["reg_office"].ToString(), d1["Phone_No"].ToString(), "CIN NO : " + d1["CIN_no"].ToString(), 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(tcaddress);
            tableblock.Rows.Add(rowblock);

            Table table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            TableRow tr = new TableRow();
            tr = new TableRow();
            tr.Height = 40;
            var Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + dr["letter_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " + System.DateTime.Now.ToString("dd-MM-yyyy"), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To, ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Code            : ", dr["emp_code"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Name           : ", dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("Dear Sir/Madam ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            string lineText = "With reference to your expression of interest as SPCA, we have the pleasure in hiring your services in our Company as";
            lineText += "“SPCA”(hereinafter referred the “Commission agent” ) on the following terms and conditions   :";

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(lineText, 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "Agreement made on this " + Convert.ToDateTime(dr["app_date"]).Day.ToString() + " day of " + Convert.ToDateTime(dr["app_date"]).ToString("MMMM") + ", " + Convert.ToDateTime(dr["app_date"]).Year.ToString() + " between " + d1["comp_name"].ToString() + " having registered office at "+d1["reg_office"].ToString()+", as one part and ";
            lineText += "Opposite Party named " + dr["emp_name"].ToString() + " son of " + dr["fathername"].ToString() + " resident:of " + dr["address"].ToString() + " (hereinafter called the “Commission agent” ) ";
            lineText += "of the other part.";

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(lineText, 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" Whereas", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "The Company is desirous of appointing you as Commission agent for the services rendered by the Commission agent in accordance with the timely directions and requirement of the company.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "The Commission agent has approached the Company for his appointment as such Commission agent and has consented to act as such Commission agent.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "That the Commission agent shall canvas for, secure orders and push the sale to the best of his ability and experience within the said area and hereafter guarantee to secure directly or indirectly orders for the sale.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "That the Commission agent shall not employ sub-Commission agents, servants, canvassers, clerks and other Commission Agents. The Company shall, however advertise at its own cost in the said territory and at its discretion, whether in newspapers, magazines, cinema slides, or by any other means and shall indicate where feasible the name of the Commission agent as its sole selling Commission agent in the territory indicate above.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            double amt = Convert.ToDouble(dr["BP"]);
            ExPro.Client.CurrencyTowords conv = new ExPro.Client.CurrencyTowords();

            lineText = "a) Commission :  For the services rendered by you, you will be paid Commission Of Rs. " + dr["BP"].ToString() + "/- (Rupees " + conv.changeCurrencyToWords(amt) + ") ( Subject to applicable taxes ).Commission shall be ";
            lineText += "calculated on Pro-rata basis for services rendered less than full month days. The out of pocket expense incurred by the Commission Agent ";
            lineText += "will be reimbursed subject to remaining of Rs " + dr["ca"].ToString() + ".";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "b) You shall be required to start working as Commission Agent on or before " + dr["app_date"].ToString() + ".";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("   ", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "This contract/Agreement of hiring as Commission Agent shall be done as per decision of Company from the date of your reporting, subject to change of contract or termination on such terms and conditions as the Company shall deem fit and proper.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "Duties and Obligations  :";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("  i)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" You shall be responsible, for all activities as decided by Company from time to time basis.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" ii)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" During the tenure of your hiring, you shall be available for work. You shall diligently promote and safeguard the interests of the Company and comply with such instructions as you may from time to time receive from the Company or the representatives of the Company. This Agreement does not create and any employer-Employee relationship between the Commission Agent (SPCA) and the Company. Services rendered shall strictly be on Principal to Principal basis, this agreement does not create any kind of right equivalent to that of a Employee of Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("iii)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" During the subsistence of your hiring, you shall not directly or indirectly, whether in your name or in the name of your Commission agent, servant, assign or relatives or otherwise howsoever, engage yourself in any other profession or vocation, either part-time or full-time, which competes with and /or is adverse to the business interests of the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" iv)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" You shall hold in trust the Company’s money, property, other valuables as and when the same are entrusted to you and duly account for the same to the Company’s credit.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("   v)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" You shall maintain complete confidentiality of the terms of the present hiring.  You shall also maintain complete secrecy and confidentiality of the business affairs of the Company.  Its business policies, data bases and all such information divulgence of which would promote businesses in competition to the business of the Company and which would otherwise be detrimental to the interests of the Company.  Such obligation will survive even after the termination of the instant hiring.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "Termination:  This hiring is terminable by either party by giving a month’s notice.  Notice from your end is necessary to enable the ";
            lineText += "Company to identify and hire a suitable replacement in your place.  Neither party is bound to assign any reason for such termination. ";
            lineText += "That at the termination of the agreement whether by efflux of time or otherwise,the Company shall not be liable to pay any commission on ";
            lineText += " orders received thereafter. In case termination without one month prior notice a gross sum equal to one month Commission shall be levied as ";
            lineText += "penalty in lieu of notice. However Company may terminate this agreement without any prior notice on such grounds/reasons company deem fit and necessary.  ";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = " You shall hand over charge of the Company’s medical equipment, money, property, goods, stores, books of accounts, cheque books, seals, authorizations/power of attorneys executed in your favour and other documents in your possession, custody whereof was entrusted to you during the tenure of this hiring.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("  a)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = " You will vacate quarter / accommodation, if provided to you, immediately from the date of cessation of your employment entitling you to settle your dues with the Company, if any, failing which the management will reserve the right to withhold your dues and take appropriate action.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("  b)", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);



            lineText = " Non-Competition:  You shall not during the subsistence of this hiring indulge in any activity, directly or indirectly, whether in your name or in the name of your Commission agent, servant, ";
            lineText += "assign, or relatives or otherwise howsoever, indulge in any activity which is in competition or detrimental to the business of the Company.  Any attempt to lure or entice any Commission Agent of ";
            lineText += "the Company to severe its employment with the Company would be deemed to be an activity which is in competition or detrimental to the business of the Company.  You shall also not enter into any ";
            lineText += "understanding / agreement or any strategic tie up with any entity during the subsistence of this hiring which carries on any business which is of similar nature and in competition to the business carried on by the Company.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            lineText = "Remedy for certain breaches  :  The parties agree that liquidated damages as described in this Agreement are a genuine estimate of Company foreseeable damages and are Company’s sole remedy for such breach of Agreement. Breach caused by Force Majeure events or by actions of Company shall not constitute a breach resulting in the payment of liquidated damages. The Company shall recover full damages caused by Commission Agent or anyone associated directly or indirectly with the Commission Agent.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            lineText = "Waiver  :  Failure by the Company at any time to enforce any provision of this Contract of Hiring or to require performance by you of any provision hereof shall in no way affect the validity of this Contract of Hiring or any part hereof or the right of the Company at any time thereafter to enforce its rights hereunder, nor shall it be taken to constitute a condensation or waiver by the Company of that default or any other or subsequent default or breach.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("11 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "Modification / Alteration:  The Company reserves the right to add, to alter or amend the terms and conditions of the instant Contract of Hiring as presently recorded herein.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("12 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = " Commission Agent shall keep Company duly informed of any change or modification of your residential address, Adhaar Card Details, PAN –Card , other government approved Identity cards.The Commission Agent acknowledges and agrees that if, during the term of employment, a criminal case is filed against the Commission Agent, or if it comes to the Company’s attention that a criminal case may be filed against the Commission Agent in the future, the Company reserves the right to terminate this agreement immediately without prior notice. The Commission Agent further agrees to inform the Company promptly in writing if the Commission Agent becomes aware of any potential or actual criminal investigation or charges that may be filed against the Commission Agent. In the event of termination under this clause, the Commission Agent shall not be entitled to any Commission, compensation, severance pay, or other benefits and the Company shall be fully released from any obligations under this agreement. The provisions of this clause shall survive the termination of this agreement.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("13 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = " Notwithstanding anything hereinbefore contained, this Contract/Agreement of Hiring is liable to be terminated without notice in the event it is found that you have committed a breach of any of the terms hereof. The Company’s decision in this regard shall be final and binding on you.  Such termination shall be without prejudice to any other rights the Company may be entitled to in law.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("14 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            lineText = " Forum:  All disputes arising out of and / or touching and / or concerning these presents shall be subject to the exclusive jurisdiction of the Courts of Lucknow.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("15 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);




            lineText = "Indemnification Clause:Commission Agent shall indemnify and hold harmless Company and its directors, officers, Commission Agents, Commission agents, stockholders, affiliates, subcontractors and customers from and against all allegations, claims, actions, suits, demands, damages, liabilities, obligations, losses, settlements, judgments, costs and expenses (including without limitation attorney fees and costs) which arise out of, relate to, or result from any act or omission of Commission Agent concerning the subject matter of this Agreement.";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("16 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            lineText = "Please countersign a copy of this Agreement/Contract of Hiring as a token of your acceptance of the terms and conditions hereof.";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("16 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("    ", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "Yours faithfully";
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("    ", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);






            #region Signature Block

            DataTable dtSignature = ds.Tables[1];

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 80;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dtSignature.Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(100, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dtSignature.Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(100, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 16, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion
            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }
        private RadDocument IncreamentLetterProfessional(DataSet ds)
        {
            RadDocument document = ReportEditor.Document;
            DataRow dr = ds.Tables[0].Rows[0];
            DataRow d1 = ds.Tables[1].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            tableblock.Tag = "Block";
            section.Blocks.Add(tableblock);
            string path = Application.StartupPath + "\\ChandanLogo.jpg";
            TableRow rowblock = new TableRow();
            byte[] logo = System.IO.File.ReadAllBytes(path);
            TableCell logoCell = GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo, 120, 50);
            logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));

            rowblock.Cells.Add(logoCell);
            TableCell tcaddress = GetAddressCell(d1["comp_name"].ToString(), "Corp. Office : " + d1["corp_office_add"].ToString(), "Reg. Office : " + d1["reg_office"].ToString(), d1["Phone_No"].ToString(), "CIN NO : " + d1["CIN_no"].ToString(), 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(tcaddress);
            tableblock.Rows.Add(rowblock);

            Table table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            TableRow tr = new TableRow();
            tr = new TableRow();
            tr.Height = 40;
            var Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + dr["letter_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " +System.DateTime.Now.ToString("dd-MM-yyyy"), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To, ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Code            : ", dr["emp_code"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Name           : ", dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("Dear Sir/Madam ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetMiddleTextBold("The Company hereby appoints you as ", dr["designation"].ToString(), " to render your Professional Services and you hereby accept the same upon the terms and conditions hereinafter set forth. ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black,10,1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The services will be rendered by the Professional to the Company in accordance with the directions and requirements of the Company ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black,10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetMiddleTextBold("The services to be provided under this Agreement shall commence with effect from ", ds.Tables[0].Rows[0]["app_date"].ToString(), " and shall continue unless a one month prior written notice of termination is given by the professional.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Not with standing anything contained in above clause, the Company shall have the right to terminate this Agreement at any time without assigning any reason whatsoever", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("In case of termination without one month prior notice a gross sum equal to one month fees shall be levied as penalty in lieu of notice to professional.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetMiddleTextBold("In consideration of the services to be rendered, you shall receive professional fees of Rs. ",Convert.ToDecimal(dr["gross_salary"]).ToString("0"), " per month. (Fees will be calculated on pro-rata basis for services less than full month days).", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The payment shall be subject to taxes as applicable.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional agrees that all Services rendered will be on Principal to Principal basis and that this Agreement does not create an employer-employee relationship between the Professional and the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("During the term of this Agreement, Professional will engage in no business or other activities which are, directly or indirectly, competitive with the business activities of the Company without obtaining the prior written consent of the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional shall keep confidential all confidential information provided to him by the Company excepting only such information as is already generally known to the public.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("This Agreement and any services rendered hereunder are subject to all the applicable laws and regulations of India and any dispute arising will be subject matter of local law in force (place of agreement execution).  ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

           


            #region Signature Block

            DataTable dtSignature = ds.Tables[1];

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 80;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 12, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dtSignature.Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dtSignature.Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 16, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion
            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }
        TableCell GetAddressCell(string unit_name, string corp_office, string reg_office, string phone, string CIN, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph para = new Paragraph();
            Span span = new Span();
            ReadOnlyRangeStart rs = new ReadOnlyRangeStart();
            ReadOnlyRangeEnd re = new ReadOnlyRangeEnd();
            re.PairWithStart(rs);
            cell.ColumnSpan = colspan;

            Span span_unitname = new Span();
            span_unitname.Text = unit_name;
            span_unitname.ForeColor = color;
            span_unitname.FontWeight = fontweight;
            span_unitname.FontSize = Unit.PointToDip(fontsize);
            span_unitname.FontFamily = fontfamily;

            Span span_corp_office = new Span();
            span_corp_office.Text = corp_office;
            span_corp_office.ForeColor = color;
            span_corp_office.FontSize = Unit.PointToDip(8);
            span_corp_office.FontFamily = fontfamily;

            Span span_reg_office = new Span();
            span_reg_office.Text = reg_office;
            span_reg_office.ForeColor = color;
            span_reg_office.FontSize = Unit.PointToDip(8);
            span_reg_office.FontFamily = fontfamily;

            Span span_contact = new Span();
            span_contact.Text = "Phone: " + phone;
            span_contact.ForeColor = color;
            span_contact.FontSize = Unit.PointToDip(8);
            span_contact.FontFamily = fontfamily;

            Span span_CIN = new Span();
            span_CIN.Text = CIN;
            span_CIN.ForeColor = color;
            span_CIN.FontSize = Unit.PointToDip(8);
            span_CIN.FontFamily = fontfamily;

            para.Inlines.Add(rs);
            para.Inlines.Add(span_unitname);
            para.Inlines.Add(new Break(BreakType.PageBreak));
            para.Inlines.Add(span_corp_office);
            para.Inlines.Add(new Break(BreakType.PageBreak));
            para.Inlines.Add(span_reg_office);
            para.Inlines.Add(new Break(BreakType.PageBreak));
            para.Inlines.Add(span_contact);
            para.Inlines.Add(new Break(BreakType.PageBreak));
            para.Inlines.Add(span_CIN);
            para.Inlines.Add(re);


            Span emptySpan = new Span();
            emptySpan.Text = " ";
            para.Inlines.Add(emptySpan);
            ///////////////////////////////////////

            cell.Blocks.Add(para);

            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }
        TableCell GetMiddleTextBold(string prm1, string prm2, string prm3, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph paragraph = new Paragraph();
            Span span = new Span();
            ReadOnlyRangeStart rs = new ReadOnlyRangeStart();
            ReadOnlyRangeEnd re = new ReadOnlyRangeEnd();
            re.PairWithStart(rs);
            cell.ColumnSpan = colspan;

            Span span1 = new Span(prm1);
            span1.ForeColor = color;
            span1.FontWeight = FontWeights.Normal;
            span1.FontSize = Unit.PointToDip(fontsize);
            span1.FontFamily = fontfamily;

            Span span2 = new Span(prm2);
            span2.ForeColor = color;
            span2.FontWeight = FontWeights.Bold;
            span2.FontSize = Unit.PointToDip(fontsize);
            span2.FontFamily = fontfamily;

            Span span4 = new Span(prm3);
            span4.ForeColor = color;
            span4.FontWeight = FontWeights.Normal; ;
            span4.FontSize = Unit.PointToDip(fontsize);
            span4.FontFamily = fontfamily;

            paragraph.Inlines.Add(rs);
            paragraph.Inlines.Add(span1);
            paragraph.Inlines.Add(span2);

            paragraph.Inlines.Add(span4);
            paragraph.Inlines.Add(re);

            ///////////////////////////////////////
            Span emptySpan = new Span();
            emptySpan.Text = " ";
            paragraph.Inlines.Add(emptySpan);
            ///////////////////////////////////////

            cell.Blocks.Add(paragraph);
            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }
        TableCell GetLastTextBold(string prm1, string prm2, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph paragraph = new Paragraph();
            Span span = new Span();
            ReadOnlyRangeStart rs = new ReadOnlyRangeStart();
            ReadOnlyRangeEnd re = new ReadOnlyRangeEnd();
            re.PairWithStart(rs);
            cell.ColumnSpan = colspan;

            Span span1 = new Span(prm1);
            span1.ForeColor = color;
            span1.FontWeight = FontWeights.Normal;
            span1.FontSize = Unit.PointToDip(fontsize);
            span1.FontFamily = fontfamily;

            Span span2 = new Span(prm2);
            span2.ForeColor = color;
            span2.FontWeight = FontWeights.Bold;
            span2.FontSize = Unit.PointToDip(fontsize);
            span2.FontFamily = fontfamily;

            paragraph.Inlines.Add(rs);
            paragraph.Inlines.Add(span1);
            paragraph.Inlines.Add(span2);
            paragraph.Inlines.Add(re);

            ///////////////////////////////////////
            Span emptySpan = new Span();
            emptySpan.Text = " ";
            paragraph.Inlines.Add(emptySpan);
            ///////////////////////////////////////

            cell.Blocks.Add(paragraph);
            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }

        TableCell GetCell(string text, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph para = new Paragraph();
            Span span = new Span();
            ReadOnlyRangeStart rs = new ReadOnlyRangeStart();
            ReadOnlyRangeEnd re = new ReadOnlyRangeEnd();
            re.PairWithStart(rs);
            cell.ColumnSpan = colspan;
            if (!text.Contains("@"))
            {
                span = new Span();
                if (text != "")
                    span.Text = text;
                else
                    span.Text = " ";
                span.ForeColor = color;
                span.FontWeight = fontweight;
                span.FontSize = Unit.PointToDip(fontsize);
                span.FontFamily = fontfamily;

                //span.Text = text;
                para.Inlines.Add(rs);
                para.Inlines.Add(span);
                para.Inlines.Add(re);
            }
            else
            {
                Span span1 = new Span();
                if (text.Split('@')[0] != "")
                    span1.Text = text.Split('@')[0];
                else
                    span1.Text = " ";
                span1.ForeColor = color;
                span1.FontWeight = fontweight;
                span1.FontSize = Unit.PointToDip(fontsize);
                span1.FontFamily = fontfamily;

                if (text.Split('@')[1] != "")
                    span.Text = text.Split('@')[1];
                else
                    span.Text = " ";
                span.ForeColor = color;
                span.FontWeight = FontWeights.Normal;
                span.FontSize = Unit.PointToDip(7);
                span.FontFamily = fontfamily;

                para.Inlines.Add(rs);
                para.Inlines.Add(span1);
                para.Inlines.Add(new Break(BreakType.PageBreak));
                para.Inlines.Add(span);
                para.Inlines.Add(re);
            }
            ///////////////////////////////////////
            Span emptySpan = new Span();
            emptySpan.Text = " ";
            para.Inlines.Add(emptySpan);
            ///////////////////////////////////////

            cell.Blocks.Add(para);

            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }
        TableCell GetEditableCell(string text, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph para = new Paragraph();
            Span span = new Span();
            cell.ColumnSpan = colspan;
            if (!text.Contains("@"))
            {
                span = new Span();
                if (text != "")
                    span.Text = text;
                else
                    span.Text = " ";
                span.ForeColor = color;
                span.FontWeight = fontweight;
                span.FontSize = Unit.PointToDip(fontsize);
                span.FontFamily = fontfamily;
                //span.Text = text;
                para.Inlines.Add(span);
            }
            else
            {
                Span span1 = new Span();
                if (text.Split('@')[0] != "")
                    span1.Text = text.Split('@')[0];
                else
                    span1.Text = " ";
                span1.ForeColor = color;
                span1.FontWeight = fontweight;
                span1.FontSize = Unit.PointToDip(fontsize);
                span1.FontFamily = fontfamily;

                if (text.Split('@')[1] != "")
                    span.Text = text.Split('@')[1];
                else
                    span.Text = " ";
                span.ForeColor = color;
                span.FontWeight = FontWeights.Normal;
                span.FontSize = Unit.PointToDip(7);
                span.FontFamily = fontfamily;

                para.Inlines.Add(span1);
                para.Inlines.Add(new Break(BreakType.PageBreak));
                para.Inlines.Add(span);
            }
            ///////////////////////////////////////
            Span emptySpan = new Span();
            emptySpan.Text = " ";
            para.Inlines.Add(emptySpan);
            ///////////////////////////////////////

            cell.Blocks.Add(para);
            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }
        private Paragraph getParagraphText(string text, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize)
        {
            Span span = new Span(text);
            span.ForeColor = color;

            span.FontWeight = fontweight;
            span.FontSize = Unit.PointToDip(fontsize);
            span.FontFamily = fontfamily;

            Paragraph paragraph = new Paragraph();
            paragraph.LineSpacing = 1;
            paragraph.Inlines.Add(span);

            return paragraph;
        }
        TableCell GetImageCell(int width, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign, byte[] image_sign, int image_with, int image_hight)
        {
            TableCell cell = new TableCell();
            cell.VerticalAlignment = VertAlign;
            cell.TextAlignment = HorzAlign;
            Paragraph para = new Paragraph();
            Span span = new Span();
            ReadOnlyRangeStart rs = new ReadOnlyRangeStart();
            ReadOnlyRangeEnd re = new ReadOnlyRangeEnd();
            re.PairWithStart(rs);
            if (image_sign != null)
            {
                MemoryStream ms = new MemoryStream(image_sign);
                ImageInline img_sign = new ImageInline(ms);
                img_sign.Width = image_with;
                img_sign.Height = image_hight;
                para.Inlines.Add(rs);
                para.Inlines.Add(img_sign);
                para.Inlines.Add(re);
            }
            ///////////////////////////////////////
            Span emptySpan = new Span();
            emptySpan.Text = " ";
            para.Inlines.Add(emptySpan);
            ///////////////////////////////////////
            cell.Blocks.Add(para);
            if (cell.ColumnSpan == 1)
            {
                cell.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, width); //Suggested by telerik
            }
            return cell;
        }
        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (rgv_info.CurrentRow.Cells["email_flag"].Value.ToString() == "Y")
            {
                btnPrint.Enabled = true;
                btnMail.Enabled = true;
                btnVerify.Enabled = false;
            }
            else
            {
                btnPrint.Enabled = false;
                btnMail.Enabled = false;
                btnVerify.Enabled = true;
            }
            _emailSendBy = e.Row.Cells["emailby"].Value.ToString();
            GetIncreamentLetterDocument(rgv_info.CurrentRow.Cells["Emp Id"].Value.ToString());
            Cursor.Current = Cursors.Default;
        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _qry = "execute pSelectQueries '" + GlobalUsage.Login_id + "','IncrLetter'," + dtp_Date.Value.Month.ToString() + "," + dtp_Date.Value.Year.ToString() + ";";
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                rgv_info.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Length > 0 && txtCode.Text!="Select")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    
                    string subject = string.Empty;
                    if (_staffType.ToUpper() == "PROFESSIONAL" || _staffType.ToUpper() == "SPCA")
                        subject = "Contarct Document " + fin_year;
                    else
                        subject = "Salary Structure " + fin_year;

                    string FileName = "SS_" + _empcode.Replace("-", "") + "" + dtp_Date.Value.ToString("MMyyyy") + ".pdf";
                    try
                    {
                        
                        PdfFormatProvider provider = new PdfFormatProvider();
                        byte[] data = provider.Export(ReportEditor.Document);
                        string msg = GlobalUsage.accounts_proxy.Insert_ConversationByDesktopApp("Post", _emailSendBy, txtCode.Text, "", subject, "Kindly download salary structure.", 0, "Normal", data, FileName);
                        MessageBox.Show(msg);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    Cursor.Current = Cursors.Default;
                }
                else
                { MessageBox.Show("Please select employee"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public byte[] ExportDocx(RadDocument document)
        {
            DocxFormatProvider provider = new DocxFormatProvider();
            return provider.Export(document);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                qry = @"select emp_code,emp_name=emp_name+' ['+designation+' ]' from empdetail where injob='Yes' and emp_name like '" + txtsearch.Text + "%' order by emp_name";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "ExHrd");
                ddlPerson.Items.AddRange(GlobalUsage.FillTelrikCombo(ds.Tables[0]));
                ddlPerson.SelectedIndex = 0;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ddlPerson_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtCode.Text = ddlPerson.SelectedValue.ToString();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                string qry = "update incr_detail set email_flag='N',email_by='" + GlobalUsage.Login_id + "' where emp_code='" + _empcode + "' and  month(app_date)=" + dtp_Date.Value.Month.ToString() + " and year(app_date)=" + dtp_Date.Value.Year.ToString() + "";
                msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
                if (msg.Contains("Success"))
                {
                    rgv_info.CurrentRow.Cells["email_flag"].Value = "N";
                    btnMail.Enabled = false;
                    btnPrint.Enabled = false;
                    btnVerify.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If Print(Yes) if PrintPreview(No)", "Confirmation", MessageBoxButtons.YesNo).ToString() == "Yes")
                ReportEditor.Print(true);
            else
                ReportEditor.PrintPreview();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                string qry = "update incr_detail set email_flag='Y',email_by='" + GlobalUsage.Login_id + "' where emp_code='" + _empcode + "' and  month(app_date)=" + dtp_Date.Value.Month.ToString() + " and year(app_date)=" + dtp_Date.Value.Year.ToString() + "";
                msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
                if (msg.Contains("Success"))
                {
                    rgv_info.CurrentRow.Cells["email_flag"].Value = "Y";
                    btnPrint.Enabled = true;
                    btnMail.Enabled = true;
                    btnVerify.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void rgv_info_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["email_flag"].Value.ToString() == "Y")
                e.RowElement.ForeColor =System.Drawing.Color.Green;
            else
                e.RowElement.ForeColor = System.Drawing.Color.Black;
        }
    }
}
