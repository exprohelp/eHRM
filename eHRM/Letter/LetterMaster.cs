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

namespace eHRM.Letter
{
    public partial class LetterMaster : Telerik.WinControls.UI.RadForm
    {
        private Telerik.WinControls.UI.RadRichTextEditor ReportEditor;
        private Telerik.WinControls.UI.RadRichTextEditor ReportEditor2;
        DataSet _dsreport = new DataSet();
        string _result = string.Empty;
        string _emailsendby = string.Empty;
        string _letterType = string.Empty;
        string _cs_head = string.Empty;
        DataSet dsDiagnosis = new DataSet();
        string _reg_no = string.Empty;
        string _report_name = string.Empty;
        string _testcode = string.Empty;
        string _status = string.Empty;
        DataSet _ds = new DataSet();
        ImageList imageList = new ImageList();

        string _client_id = string.Empty;

        public LetterMaster()
        {
            InitializeComponent();
        }
        #region ImportAndExPortMethode
        public byte[] ExportDocx(RadDocument document)
        {
            DocxFormatProvider provider = new DocxFormatProvider();
            return provider.Export(document);
        }
        public RadDocument ImportDocx(byte[] content)
        {
            DocxFormatProvider provider = new DocxFormatProvider();
            return provider.Import(content);
        }

        public string ExportToHTML(RadDocument document)
        {
            HtmlFormatProvider provider = new HtmlFormatProvider();
            return provider.Export(document);
        }
        public RadDocument ImportHTML(string html)
        {
            HtmlFormatProvider provider = new HtmlFormatProvider();
            return provider.Import(html);
        }
        public RadDocument ImportXaml(string content)
        {
            XamlFormatProvider provider = new XamlFormatProvider();
            return provider.Import(content);
        }

        #endregion

        private void HistoReporting_Load(object sender, EventArgs e)
        {
            //ECG.ECGIntegrationSoapClient ws = new ECG.ECGIntegrationSoapClient();
            //string result = ws.GetPatientDemographic("IDC40032151819");
            GlobalUsage.hr_proxy = new eHRM.HumanResource.Staff_ManagementSoapClient();
            // dtissue_date.MinDate = System.DateTime.Now;
            dtissue_date.Value = System.DateTime.Now; ;
            try
            {
                ddlLetterName.SelectedIndex = 0;
                DateTime d = System.DateTime.Now; ;
                //dtInputDate.Value = new DateTime(d.Year, d.Month, 1).AddDays(-1);
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "ForAPPLetter", "", "");
                dgEmpList.DataSource = ds.Tables[0];
                cmbCompany.Items.Clear();
                cmbCompany.Items.AddRange(Config.FillWinCombo(ds.Tables[2]));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
            //radSplitContainer1.SplitPanels[0].Collapsed = false;
            //radSplitContainer1.SplitPanels[1].Collapsed = true;
        }


        public byte[] imageToByteArray(System.Drawing.Image image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {

        }
        #region Editor For Preview and complete
        private void GetLetter(string emp_code)
        {
            try
            {
                MasterPanel2.Controls.Clear();
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
                ReportEditor.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(10, 15, 25, 20);

                ReportEditor.TabIndex = 1;
                ReportEditor.Document = new RadDocument();
                MasterPanel2.Controls.Add(ReportEditor);

                string qry = "execute pLetter_Queries '" + emp_code + "','1900/01/01','-','-','Appointmentletter' ";
                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");

                if (_staffType.ToUpper() == "SPCA")
                    ContractLetterToSPCA(_ds);
                else if (_staffType.ToUpper() == "PROFESSIONAL") //|| _staffType.ToUpper() == "SPCA"
                    ContractLetter(_ds);
                else
                {
                    if (chkMarketing.Checked)
                        ReportEditor.Document = AppointmentLetter(_ds, "Y");
                    else
                        ReportEditor.Document = AppointmentLetter(_ds, "N");
                }
                int pagesCount = DocumentStructureCollection.GetChildrenCount(ReportEditor.Document.DocumentLayoutBox);

                HeaderFooterToAllPage();

                ReportEditor.Document.SectionDefaultPageSize = PaperTypeConverter.ToSize(PaperTypes.Letter);
                ReportEditor.LayoutMode = DocumentLayoutMode.Paged;
                ReportEditor.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(20, 10, 30, 10);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void GetOfferLetter(string logic)
        {
            try
            {

                radSplitContainer2.SplitPanels[0].Collapsed = false;
                radSplitContainer2.SplitPanels[1].Collapsed = true;

                MasterPanelOffer.Controls.Clear();
                ReportEditor2 = new Telerik.WinControls.UI.RadRichTextEditor();
                ReportEditor2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                ReportEditor2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
                ReportEditor2.LayoutMode = Telerik.WinForms.Documents.Model.DocumentLayoutMode.Paged;
                ReportEditor2.Name = "ReportEditor2";
                ReportEditor2.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
                ReportEditor2.Dock = System.Windows.Forms.DockStyle.Fill;
                //Page Setup
                ReportEditor2.Document.SectionDefaultPageSize = PaperTypeConverter.ToSize(PaperTypes.A4);
                ReportEditor2.LayoutMode = DocumentLayoutMode.Paged;
                ReportEditor2.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(25, 15, 25, 10);

                ReportEditor2.TabIndex = 1;
                ReportEditor2.Document = new RadDocument();
                MasterPanelOffer.Controls.Add(ReportEditor2);
                if (ddlOfferLetterType.SelectedItem != null)
                {
                    if (ddlOfferLetterType.SelectedItem.ToString() == "Professional")
                    {
                        string qry = "execute pLetter_Queries '-','1900/01/01','" + ddlEmployeeList.SelectedValue.ToString() + "','Offer Letter','OfferLetterDetail','"+cmbCompany.Text+"' ";
                        _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                        ReportEditor2.Document = OfferLetterProfessional(_ds);
                    }
                    else if (ddlOfferLetterType.SelectedItem.ToString() == "Employee")
                    {
                        string qry = "execute pLetter_Queries '-','1900/01/01','" + ddlEmployeeList.SelectedValue.ToString() + "','Offer Letter','OfferLetterDetail','" + cmbCompany.Text + "' ";
                        _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                        ReportEditor2.Document = OfferLetterGeneral(_ds);
                    }
                    else if (ddlOfferLetterType.SelectedItem.ToString() == "Marketing")
                    {
                        string qry = "execute pLetter_Queries '-','1900/01/01','" + ddlEmployeeList.SelectedValue.ToString() + "','Offer Letter','OfferLetterDetail','" + cmbCompany.Text + "' ";
                        _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                        ReportEditor2.Document = OfferLetterMarketing(_ds);
                    }
                  


                    int pagesCount = DocumentStructureCollection.GetChildrenCount(ReportEditor2.Document.DocumentLayoutBox);
                    HeaderFooterToAllPageOfferLetter();
                    ReportEditor2.Document.SectionDefaultPageSize = PaperTypeConverter.ToSize(PaperTypes.Letter);
                    ReportEditor2.LayoutMode = DocumentLayoutMode.Paged;
                    ReportEditor2.Document.SectionDefaultPageMargin = new Telerik.WinForms.Documents.Layout.Padding(20, 10, 30, 10);
                }
                else
                { MessageBox.Show("please select letter type"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void HeaderFooterToAllPage()
        {
            //Adding Header     
            RadDocument HeaderDoc = HeaderBlock(_ds.Tables[2]);
            Header header = new Header() { Body = HeaderDoc, IsLinkedToPrevious = false };
            //ReportEditor.UpdateHeader(ReportEditor.Document.Sections.First, HeaderFooterType.Default, header);
            ReportEditor.Document.Sections.First.Headers.Default = header;
            ReportEditor.Document.Sections.First.HeaderTopMargin =10;
            ReportEditor.Document.Sections.First.FooterBottomMargin = 10;
            //Adding footer
            RadDocument footerdoc = FooterBlock();
            Footer footer = new Footer() { Body = footerdoc, IsLinkedToPrevious = false };
            //ReportEditor.UpdateFooter(ReportEditor.Document.Sections.Last, HeaderFooterType.Default, footer);
            ReportEditor.Document.Sections.Last.Footers.Default = footer;
        }
        private void HeaderFooterToAllPageOfferLetter()
        {
            //Adding Header     
            RadDocument HeaderDoc = HeaderBlock(_ds.Tables[2]);
            Header header = new Header() { Body = HeaderDoc, IsLinkedToPrevious = false };
            //ReportEditor.UpdateHeader(ReportEditor.Document.Sections.First, HeaderFooterType.Default, header);
            ReportEditor2.Document.Sections.First.Headers.Default = header;
            ReportEditor2.Document.Sections.First.HeaderTopMargin = 1;
            ReportEditor2.Document.Sections.First.FooterBottomMargin = 10;
            //Adding footer
            RadDocument footerdoc = FooterBlock();
            Footer footer = new Footer() { Body = footerdoc, IsLinkedToPrevious = false };
            //ReportEditor.UpdateFooter(ReportEditor.Document.Sections.Last, HeaderFooterType.Default, footer);
            ReportEditor2.Document.Sections.Last.Footers.Default = footer;
        }
        string _letterNo = string.Empty;
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

        private RadDocument ContractLetterToSPCA(DataSet ds)
        {
            RadDocument document = ReportEditor.Document;
            DataRow dr = ds.Tables[0].Rows[0];
            DataRow d1 = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            //tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            //tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            //tableblock.Tag = "Block";
            //section.Blocks.Add(tableblock);
            //string path = Application.StartupPath + "\\ChandanLogo.jpg";
            //TableRow rowblock = new TableRow();
            //byte[] logo = System.IO.File.ReadAllBytes(path);
            //TableCell logoCell = GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo, 120, 50);
            //logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));

            //rowblock.Cells.Add(logoCell);
            //TableCell tcaddress = GetAddressCell(d1["comp_name"].ToString(), "Corp. Office : " + d1["corp_office_add"].ToString(), "Reg. Office : " + d1["reg_office"].ToString(), d1["Phone_No"].ToString(), "CIN NO : " + d1["CIN_no"].ToString(), 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 11, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            //rowblock.Cells.Add(tcaddress);
            //tableblock.Rows.Add(rowblock);

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

            lineText = "Agreement made on this " + Convert.ToDateTime(dr["d_o_j"]).Day.ToString() + " day of " + Convert.ToDateTime(dr["d_o_j"]).ToString("MMMM") + ", " + Convert.ToDateTime(dr["d_o_j"]).Year.ToString() + " between " + dr["unit_name"].ToString() + " having registered office at "+d1["reg_office"].ToString()+", as one part and ";
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
            lineText += "will be reimbursed subject to remaining of Rs " + dr["conveyance"].ToString() + ".";

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(lineText, 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Tahoma"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            lineText = "b) You shall be required to start working as Commission Agent on or before " + dr["d_o_j"].ToString() + ".";

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

            DataTable dtSignature = ds.Tables[3];

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
        private RadDocument ContractLetter(DataSet ds)
        {
            RadDocument document = ReportEditor.Document;



            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            Table table = new Table();
            TableRow tr; TableCell Cell;
            tr = new TableRow();


            dr = ds.Tables[0].Rows[0];
            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

         
            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + dr["letter_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " + Convert.ToDateTime(dr["issue_date"]).ToString("dd-MM-yyyy"), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To, ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 15;
            //Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Code            : ", dr["emp_code"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetLastTextBold("Name            : ", dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("Dear Sir/Madam ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell("", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetMiddleTextBold("The Company hereby appoints you as ", dr["designation"].ToString(), " to render your Professional Services and you hereby accept the same upon the terms and conditions hereinafter set forth. ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The services will be rendered by the Professional to the Company in accordance with the directions and requirements of the Company ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetMiddleTextBold("The services to be provided under this Agreement shall commence with effect from ", ds.Tables[0].Rows[0]["d_o_j"].ToString(), " and shall continue unless a one month prior written notice of termination is given by the either party.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Not with standing anything contained in above clause, the Company shall have the right to terminate this Agreement at any time without assigning any reason whatsoever", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("In case of termination without one month prior notice a gross sum equal to one month fees shall be levied as penalty in lieu of notice by either party.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetMiddleTextBold("In consideration of the services to be rendered, you shall receive professional fees of Rs. ", Convert.ToDecimal(dr["gross_salary"]).ToString("0"), " per month. (Fees will be calculated on pro-rata basis for services less than full month days).", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The payment shall be subject to taxes as applicable.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional agrees that all Services rendered will be on Principal to Principal basis and that this Agreement does not create an employer-employee relationship between the Professional and the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("During the term of this Agreement, Professional will engage in no business or other activities which are, directly or indirectly, competitive with the business activities of the Company without obtaining the prior written consent of the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional shall keep confidential all confidential information provided to him by the Company excepting only such information as is already generally known to the public.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("This Agreement and any services rendered hereunder are subject to all the applicable laws and regulations of India and any dispute arising will be subject matter of local law in force (place of agreement execution).  ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);




            #region Signature Block

            DataTable dtSignature = ds.Tables[2];

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 50;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["comp_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dtSignature.Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dtSignature.Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dtSignature.Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dtSignature.Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dtSignature.Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            //tr = new TableRow();
            //tr.Height = 20;
            //Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 16, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);
            tr = new TableRow();
            Cell = GetCell("Acknowledged by the professional", 70, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("I have read and agree to the terms and conditions as set forth above in this letter of agreement.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Signature  ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion
            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }
        private RadDocument AppointmentLetter(DataSet ds, string Marketing)
        {
            ////////////////////////////////////////////
            // Major Area of Problem if 
            // RadDocument document =new RadDocument() problems occurs
            // RadDocument document = ReportEditor.Document; problems resolved all Text report open in correct form 
            ////////////////////////////////////////////
            RadDocument document = ReportEditor.Document;


            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();
            TableRow tr; TableCell Cell;
           

            Table table = new Table();
            dr = ds.Tables[0].Rows[0];
            //section = new Section();

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);



            //tr = new TableRow();
            //tr.Height = 5;
            //Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            _letterNo = dr["letter_no"].ToString();
            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + _letterNo, 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("    Dated : " + Convert.ToDateTime(dr["issue_date"]).ToString("dd-MM-yyyy"), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Name : " + dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Address : " + dr["address"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Mobile No : " + dr["mobile_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Dear " + dr["emp_name"].ToString() + " ,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("REF: APPOINTMENT LETTER", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 35;
            Cell = GetCell("Congratulations! In reply to your application for employment with us and subsequent selection process, we are delighted to appoint you on the following terms and conditions:", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1. DATE OF APPOINTMENT ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["d_o_j"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2. EMPLOYEE CODE ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["emp_code"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3. STATUS  ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["status"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4. DESIGNATION", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["designation"].ToString() + " ", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5. POSTING ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["unit_name"].ToString() + " ", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6. REPORT TO ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["report_to"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7. EMPLOYEE TRAINING PERIOD", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": 6 months. You will be compensated as per Annexure 'A'.", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8. PERMANENT APPOINTMENT", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": After successful training you will be appointed as permanent employee in Chandan. You will be compensated as per Annexure 'B'. ", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9. GENERAL SERVICE RULE", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(": Your employment will be subject to the terms & conditions of Service Rule Book (available on Internal mailing option of the company) as amended and update time to time by the management. ", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10. CODE OF CONDUCT", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(": You are required to adhere to the company's code of conduct as mentioned in general Service Rule Book", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("11. SALARY STRUCTURE ", 28, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": ANNEXURE 'A' (DURING TRAINING PERIOD)", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            document.Sections.Clear();
            document.Sections.Add(section);

            #region Salary ANNEXTURE A

            table = new Table();
            table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            table.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("SALARY (BASIC+DA)", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bp"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["hr"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("HRA", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["hr"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["pb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PERFORMANCE BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["ecb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ELITE CLUB BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["ecb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["bo"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bo"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }




            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY GROSS SALARY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gross_salary"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["pf"]) > 0 || Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("Company Contributions (Other Than Salary):", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell(" ", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }

            if (Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ESI CONTRIBUTION (Insurance benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["esi"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }


            if (Convert.ToInt32(dr["pf"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PF CONTRIBUTION (Retiral benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pf"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            if (Convert.ToInt32(dr["gratiuty"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("GRATUITY (Retiral benefit)* :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gratiuty"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
            }

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["mth_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ANNUAL COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["yearly_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            #endregion
            #region Salary ANNEXTURE B

            dr = ds.Tables[1].Rows[0]; // Second table detail

            table = new Table();
            table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            table.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 40;
            Cell = GetCell("ANNEXURE 'B'(AFTER SUCCESSFUL COMPLETION OF TRAINING)", 28, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            Cell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("SALARY (BASIC+DA)", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bp"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["hr"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("HRA", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["hr"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["pb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PERFORMANCE BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["ecb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ELITE CLUB BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["ecb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["bo"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bo"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY GROSS SALARY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gross_salary"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["pf"]) > 0 || Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("Company Contributions (Other Than Salary):", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell(" ", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }

            if (Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ESI CONTRIBUTION (Insurance benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["esi"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }


            if (Convert.ToInt32(dr["pf"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PF CONTRIBUTION (Retiral benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pf"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            if (Convert.ToInt32(dr["gratiuty"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("GRATUITY (Retiral benefit)* :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gratiuty"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
            }


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY COST TO COMPANY: :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["mth_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ANNUAL COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["yearly_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            #endregion
            #region Text Block
            section.Blocks.Add(getParagraphText(" ", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("*  The gratuity amount set out above is an approximation. Your eligibility and the final payout of any gratuity amounts will be determined in strict accordance with the provisions of the payment of Gratuity Act, 1972.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Reimbursement of travelling expenses will be given on actual expense incurred during the month and bills should be submitted within one month of expense incurred.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("***INSURANCE will start from 1st April of the Financial Year following completion of Three Years of continuous service.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            if (Marketing == "Y")
            {

                table = new Table();
                table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
                section.Blocks.Add(table);

                tr = new TableRow();

                Cell = GetCell("Performance Bonus will be released on the basis of achievement of Target.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

                tr = new TableRow();
                Cell = GetCell("50% will be released after achieving 90 % of target or above.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

                tr = new TableRow();
                Cell = GetCell("100% will be achieved after achieving 100% of targets.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }
            section.Blocks.Add(getParagraphText("On successful completion of training period, your employment with the company will stand confirmed. ", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("We are happy to welcome you to our organization and look forward to you building a mutually beneficial long-term association with the company.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("Kindly return the copy of appointment as well as general service rule book duly signed by you as token of acceptance of the terms and conditions stipulated herein and retain a signed copy for your records.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            #endregion
            #region Signature Block

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dsLetterSign.Tables[0].Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dsLetterSign.Tables[0].Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dsLetterSign.Tables[0].Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dsLetterSign.Tables[0].Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell("Declaration by the Employee", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("I have read the contents of the service rule book of the company and appointment letter and agree to abide by the same.Any change in service rule book from time to time by the management is acceptable to me.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //Cell = GetCell("", 10, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell("If you have any observation w.r.t this appointment , kindly  mail to us within 7 days  of receiving  this letter , failing which it will be assumed as the acceptance of appointment with terms as contained in this appointment letter.", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 30;
            //Cell = GetCell("Signature of Employee ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("NON COMPETE AGREEMENT ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 13, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 10;
            //Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 13, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            #endregion

            #region Text Block

            section.Blocks.Add(getParagraphText("In consideration to employment, promotion or increment in compensation during employment, I undersigned hereby agree not to directly or indirectly compete with the business of the Company during the period of employment and for a period of two years following termination of employment regardless of the reason of the termination.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("The term 'not compete' as used herein shall mean that the Employee shall not own, manage, operate, consult or be employed in a business substantially similar to or competitive with, the present business of the Company or such other business activity in which the Company may substantially engage during the term of employment.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("I hereby acknowledge that the Company in reliance of this agreement may provide access to trade secrets, customers and other confidential data, I agree to retain said information as confidential and not to use said information on my behalf or disclose same to any third party.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            section.Blocks.Add(getParagraphText("This non-compete agreement shall extend only for a radius of 30km from the location of the Company or its operational business branch.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Further a written permission in this regard by the outgoing employee signed by two executive directors will override this clause.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);


            //tr = new TableRow();
            //tr.Height = 50;
            //Cell = GetCell("Acknowledgement", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            //tr = new TableRow();
            //Cell = GetCell(ds.Tables[0].Rows[0]["emp_name"].ToString(), 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            //Cell = GetCell("Dated: ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            Cell = GetCell("     ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion

            return document;
        }
        private RadDocument AppointmentLetter_Preserve(DataSet ds, string Marketing)
        {
            ////////////////////////////////////////////
            // Major Area of Problem if 
            // RadDocument document =new RadDocument() problems occurs
            // RadDocument document = ReportEditor.Document; problems resolved all Text report open in correct form 
            ////////////////////////////////////////////
            RadDocument document = ReportEditor.Document;

            #region Header
            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            tableblock.Tag = "Block";
            section.Blocks.Add(tableblock);

            #region Add Logo
            string path = Application.StartupPath + "\\ChandanLogo.jpg";
            TableRow rowblock = new TableRow();
            byte[] logo = System.IO.File.ReadAllBytes(path);
            TableCell logoCell = GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo, 120, 50);
            logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(logoCell);
            #endregion

            TableCell tcaddress = GetAddressCell(dr["comp_name"].ToString(), "Corp. Office : " + dr["corp_office_add"].ToString(), "Reg. Office : " + dr["reg_office"].ToString(), dr["Phone_No"].ToString(), "CIN NO : " + dr["CIN_no"].ToString(), 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(tcaddress);
            tableblock.Rows.Add(rowblock);

            Table table = new Table();
            //table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            //section.Blocks.Add(table);
            TableRow tr; TableCell Cell;
            tr = new TableRow();
            //tr.Height = 40;
            //Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            #endregion


            dr = ds.Tables[0].Rows[0];
            //section = new Section();

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);



            tr = new TableRow();
            tr.Height = 30; 
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            _letterNo = dr["letter_no"].ToString();
            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + _letterNo, 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("    Dated : " + Convert.ToDateTime(dr["issue_date"]).ToString("dd-MM-yyyy"), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Name : " + dr["emp_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Address : " + dr["address"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Mobile No : " + dr["mobile_no"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Dear " + dr["emp_name"].ToString() + " ,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("REF: APPOINTMENT LETTER", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 35;
            Cell = GetCell(" Congratulations! In reply to your application for employment with us and subsequent selection process, we are delighted to appoint you on the following terms and conditions", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 15;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1. DATE OF APPOINTMENT ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["d_o_j"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2. EMPLOYEE CODE ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["emp_code"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3. STATUS  ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["status"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4. DESIGNATION", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["designation"].ToString() + " ", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5. POSTING ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["unit_name"].ToString() + " ", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6. REPORT To ", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": " + dr["report_to"].ToString() + "", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7. EMPLOYEE TRAINING PERIOD", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(": 6 months. You will be compensated as per Annexure 'A' ", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8. PERMANENT APPOINTMENT", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(":After successful training you will be appointed as permanent employee in Chandan. You will be compensated as per Annexure 'B' ", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9. GENERAL SERVICE RULE", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(":Your employment will be subject to the terms & conditions of service rule book (available on Internal mailing Option of the company ) as amended and update time to time by the management. ", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10. CODE OF CONDUCT", 28, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(":You are required to adhere to the company's code of conduct as mentioned in general service rule book", 72, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("11. SALARY STRUCTURE ", 28, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            Cell = GetCell(":ANNEXURE 'A' (DURING TRAINING PERIOD)", 72, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            document.Sections.Clear();
            document.Sections.Add(section);

            #region Salary ANNEXTURE A

            table = new Table();
            table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            table.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("SALARY (BASIC+DA)", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bp"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["hr"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("HRA", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["hr"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["pb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PERFORMANCE BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["ecb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ELITE CLUB BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["ecb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["bo"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bo"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }




            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY GROSS SALARY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gross_salary"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["pf"]) > 0 || Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("Company Contributions ( Other Than Salary ) :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell(" ", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }

            if (Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ESI CONTRIBUTION (Insurance benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["esi"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }


            if (Convert.ToInt32(dr["pf"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PF CONTRIBUTION (Retiral benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pf"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            if (Convert.ToInt32(dr["gratiuty"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("GRATUITY (Retiral benefit)* :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gratiuty"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
            }

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY COST TO COMPANY: :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["mth_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ANNUAL COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["yearly_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            #endregion
            #region Salary ANNEXTURE B

            dr = ds.Tables[1].Rows[0]; // Second table detail

            table = new Table();
            table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            table.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 60;
            Cell = GetCell("ANNEXURE 'B'(AFTER SUCCESSFUL COMPLETION OF TRAINING)", 28, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            Cell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("SALARY (BASIC+DA)", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bp"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["hr"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("HRA", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["hr"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["pb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PERFORMANCE BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["ecb"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ELITE CLUB BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["ecb"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }
            if (Convert.ToInt32(dr["bo"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("BONUS", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["bo"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY GROSS SALARY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gross_salary"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            if (Convert.ToInt32(dr["pf"]) > 0 || Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("Company Contributions ( Other Than Salary ) :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell(" ", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }

            if (Convert.ToInt32(dr["esi"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("ESI CONTRIBUTION (Insurance benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["esi"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }


            if (Convert.ToInt32(dr["pf"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("PF CONTRIBUTION (Retiral benefit) :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["pf"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);
            }

            if (Convert.ToInt32(dr["gratiuty"]) > 0)
            {
                tr = new TableRow();
                tr.Height = 20;
                Cell = GetCell("GRATUITY (Retiral benefit)* :", 80, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
                tr.Cells.Add(Cell);
                Cell = GetCell("Rs. " + Convert.ToDecimal(dr["gratiuty"]).ToString("0") + "", 20, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
            }


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("MONTHLY COST TO COMPANY: :", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["mth_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("ANNUAL COST TO COMPANY:", 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Rs. " + Convert.ToDecimal(dr["yearly_ctc"]).ToString("0") + "", 20, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            #endregion
            #region Text Block
            section.Blocks.Add(getParagraphText(" ", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("*  The gratuity amount set out above is an approximation. Your eligibility and the final payout of any gratuity amounts will be determined in strict accordance with the provisions of the payment of Gratuity Act, 1972.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("** Reimbursement of travelling expenses will be given on actual expense incurred during the month and bills should be submitted within one month of expense incurred.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("***INSURANCE will start from 1st April of the Financial Year following completion of Three Years of continuous service.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            if (Marketing == "Y")
            {

                table = new Table();
                table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
                section.Blocks.Add(table);

                tr = new TableRow();

                Cell = GetCell(" ** Performance Bonus will be released on the basis of achievement of Target.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

                tr = new TableRow();
                Cell = GetCell(" 50% will be released after achieving 90 % of target or above.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

                tr = new TableRow();
                Cell = GetCell(" 100% will be achieved after achieving 100% of targets.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
                tr.Cells.Add(Cell);
                table.Rows.Add(tr);

            }
            section.Blocks.Add(getParagraphText("On successful completion of training period, your employment with the company will stand confirmed. ", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("We are happy to welcome you to our organization and look forward to you building a mutually beneficial long-term association with the company.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            //section.Blocks.Add(getParagraphText("Kindly return the copy of appointment as well as general service rule book duly signed by you as token of acceptance of the terms and conditions stipulated herein and retain a signed copy for your records.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            #endregion
            #region Signature Block

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (dsLetterSign.Tables[0].Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dsLetterSign.Tables[0].Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (dsLetterSign.Tables[0].Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])dsLetterSign.Tables[0].Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);

            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(dsLetterSign.Tables[0].Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell("Declaration by the Employee", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("I have read the contents of the service rule book of the company and appointment letter and agree to abide by the same.Any change in service rule book from time to time by the management is acceptable to me .", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("If you have any observation w.r.t this appointment, kindly mail to us within 7 days of receiving this letter, failing which it will be assumed as the acceptance of appointment with terms as contained in this appointment letter.", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            //tr = new TableRow();
            //tr.Height = 30;
            //Cell = GetCell("Signature of Employee ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height =60;
            Cell = GetCell("NON COMPETE AGREEMENT ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 13, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 10;
            //Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 13, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Bottom);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            #endregion

            #region Text Block

            section.Blocks.Add(getParagraphText("In consideration to employment, promotion or increment in compensation during employment, I undersigned hereby agree not to directly or indirectly compete with the business of the Company during the period of employment and for a period of two years following termination of employment regardless of the reason of the termination.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("The term 'not compete' as used herein shall mean that the Employee shall not own, manage, operate, consult or be employed in a business substantially similar to or competitive with, the present business of the Company or such other business activity in which the Company may substantially engage during the term of employment.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("I hereby acknowledge that the Company in reliance of this agreement may provide access to trade secrets, customers and other confidential data, I agree to retain said information as confidential and not to use said information on my behalf or disclose same to any third party.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            section.Blocks.Add(getParagraphText("This non-compete agreement shall extend only for a radius of 30KM from the location of the Company or its operational business branch.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Further a written permission in this regard by the outgoing employee signed by two executive directors will override this clause.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
         
            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);


            tr = new TableRow();
            tr.Height = 50;
            Cell = GetCell("Acknowledgement", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(ds.Tables[0].Rows[0]["emp_name"].ToString(), 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            tr = new TableRow();
            Cell = GetCell("Dated: ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #endregion

            return document;
        }
        private RadDocument OfferLetterProfessional(DataSet ds)
        {
            ////////////////////////////////////////////
            // Major Area of Problem if 
            // RadDocument document =new RadDocument() problems occurs
            // RadDocument document = ReportEditor2.Document; problems resolved all Text report open in correct form 
            ////////////////////////////////////////////

            RadDocument document = ReportEditor2.Document;

            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            Table table = new Table();
            TableRow tr; TableCell Cell;
            tr = new TableRow();


            dr = ds.Tables[0].Rows[0];

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            _letterNo = dr["letter_no"].ToString();

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + _letterNo, 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " + dr["cr_date"].ToString(), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell(dr["t_name"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell(dr["t_address"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell(dr["t_mobile"].ToString(), 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            //tr = new TableRow();
            //tr.Height = 10;
            //Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell("LETTER OF ENGAGEMENT", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("Dear Sir/Madam ,", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetIncludingBoldCell("The Company hereby appoints you as ", dr["t_designation"].ToString(), " to render your Professional Services and you hereby accept the same upon the terms and conditions hereinafter set forth. ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The services will be rendered by the Professional to the Company in accordance with the directions and requirements of the Company ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("2 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetIncludingBoldCell("The services to be provided under this Agreement shall commence with effect from ", ds.Tables[0].Rows[0]["issue_date"].ToString(), " and shall continue unless a one month prior written notice of termination is given by the either party.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("3 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("Not with standing anything contained in above clause, the Company shall have the right to terminate this Agreement at any time without assigning any reason whatsoever", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("4 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("In case of termination without one month prior notice a gross sum equal to one month fees shall be levied as penalty in lieu of notice by either party.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("5 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetIncludingBoldCell("In consideration of the services to be rendered, you shall receive professional fees of Rs. ", dr["t_amount"].ToString(), " per month. (Fees will be calculated on pro-rata basis for services less than full month days).", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("6 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The payment shall be subject to taxes as applicable.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("7 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional agrees that all Services rendered will be on Principal to Principal basis and that this Agreement does not create an employer-employee relationship between the Professional and the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("8 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("During the term of this Agreement, Professional will engage in no business or other activities which are, directly or indirectly, competitive with the business activities of the Company without obtaining the prior written consent of the Company.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("9 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("The Professional shall keep confidential all confidential information provided to him by the Company excepting only such information as is already generally known to the public.", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("10 .", 5, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("This Agreement and any services rendered hereunder are subject to all the applicable laws and regulations of India and any dispute arising will be subject matter of local law in force (place of agreement execution).  ", 95, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            #region Signature Block

            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(ds.Tables[1].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            tr = new TableRow();
            if (ds.Tables[1].Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            if (ds.Tables[1].Rows[0]["sign_right_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_right_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            //Cell = GetCell(ds.Tables[1].Rows[0]["sign_title_right"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell("Acknowledged by the professional", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("I have read and agree to the terms and conditions as set forth above in this letter of agreement.", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Signature  ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);




            #endregion

            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }

        private RadDocument OfferLetterGeneral(DataSet ds)
        {
            ////////////////////////////////////////////
            // Major Area of Problem if 
            // RadDocument document =new RadDocument() problems occurs
            // RadDocument document = ReportEditor2.Document; problems resolved all Text report open in correct form 
            ////////////////////////////////////////////

            RadDocument document = ReportEditor2.Document;

            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            Table table = new Table();
            TableRow tr; TableCell Cell;
            tr = new TableRow();

            dr = ds.Tables[0].Rows[0];
        
            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 110);
            section.Blocks.Add(table);
            tr = new TableRow();

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            _letterNo = dr["letter_no"].ToString();

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("Letter No : " + _letterNo, 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " + dr["cr_date"].ToString(), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell("To,", 70, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 25;
            Cell = GetCell(dr["t_name"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(dr["t_address"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell(dr["t_mobile"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 11;
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrown"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("Dear Sir/Madam ,", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 11;
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetSalaryCell("On behalf of the company, I am pleased to offer you an appointment in our organization as ", dr["t_designation"].ToString(), dr["issue_date"].ToString() + ".", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(" ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            if(dr["t_amount"].ToString().Length>3)
            { 
            tr = new TableRow();
            Cell = GetCell("Your monthly gross will be Rs." + dr["t_amount"].ToString() + ". ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);
            }

            tr = new TableRow();
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("Terms and Conditions: ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1. Leaves ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            section.Blocks.Add(BuletedParagraph("Weekly off (after six days working you are entitled for one off).", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("The permanent employee will be entitled to have 20 leaves on yearly basis,which may be taken any time during the job subject to max. of 10 leaves in a stretch.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("During the employment of temporary period, employee is entitled to have weekly off only. During temporary period, leave for any reason other than off will be considered as “leave without payment”", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("In case of hospitalization, medical leaves for max.15 days in a year.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Times New Roman"), 14));
            section.Blocks.Add(BuletedParagraph("Other than above leaves any absence or leave will be treated as unpaid leave (auto calculation by software).", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("Co-ordinate with your head/Management for availing leaves.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Times New Roman"), 14));
            section.Blocks.Add(BuletedParagraph("Un-availed offs/leaves will not be en-cashed or carry forward to next financial year.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));

            section.Blocks.Add(getParagraphText("The payment of emolument will be subjected to deduction of Income Taxes and Provident Fund as applicable.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Your services will be governed by the service rule book of the company which may be modified from time to time as required which may change time to time.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("In case the above terms and conditions are acceptable to you, please sign and return the duplicate copy in token of your acceptance of the above.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Please carry signed copy of this letter at time of Joining with original envelope.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            #region Signature Block


            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            tr = new TableRow();
            Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" ", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (ds.Tables[1].Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            //if (ds.Tables[1].Rows[0]["sign_right_image"].ToString().Length > 2)
            // Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_right_image"], 90, 50);
            //else
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Times New Roman"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" ", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);




            tr = new TableRow();
            Cell = GetCell("Declaration : I have read and agree to the terms and conditions as set forth above in this letter of agreement.", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("  ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell("Signature of Employee ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);



            #endregion

            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }
        private RadDocument OfferLetterMarketing(DataSet ds)
        {
            ////////////////////////////////////////////
            // Major Area of Problem if 
            // RadDocument document =new RadDocument() problems occurs
            // RadDocument document = ReportEditor2.Document; problems resolved all Text report open in correct form 
            ////////////////////////////////////////////

            RadDocument document = ReportEditor2.Document;

            DataRow dr = ds.Tables[2].Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            Table table = new Table();
            TableRow tr; TableCell Cell;
            tr = new TableRow();

            dr = ds.Tables[0].Rows[0];
            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 110);
            section.Blocks.Add(table);
            tr = new TableRow();

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            _letterNo = dr["letter_no"].ToString();

            tr = new TableRow();
            Cell = GetCell("Letter No : " + _letterNo, 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dated : " + dr["cr_date"].ToString(), 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            //tr.Height = 15;
            Cell = GetCell("To,", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            // tr.Height = 15;
            Cell = GetCell(dr["t_name"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            //tr.Height = 15;
            Cell = GetCell(dr["t_address"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 10;
            Cell = GetCell(dr["t_mobile"].ToString(), 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Dear Sir/Madam ,", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(" ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetSalaryCell("On behalf of the company, I am pleased to offer you an appointment in our organization as ", dr["t_designation"].ToString(), dr["issue_date"].ToString() + ".", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(" ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Your monthly gross will be Rs." + dr["t_amount"].ToString() + ". ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Performance Bonus: " + dr["t_bonus"].ToString() + " added. ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("Performance Bonus will be released on the basis of achievement of Target. ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("50% will be released after achieving 90% of target or above. ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("100% will be released after achieving 100% of target. ", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell("(For any outstation visit, you  will get reimbursement on actual bills)", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("Terms and Conditions: ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 20;
            Cell = GetCell("1. Leaves ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 11, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Bottom);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            section.Blocks.Add(BuletedParagraph("Weekly off (after six days working you are entitled for one off).", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("The permanent employee will be entitled to have 20 leaves on yearly basis,which may be taken any time during the job subject to max. of 10 leaves in a stretch.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("During the employment of temporary period, employee is entitled to have weekly off only. During temporary period, leave for any reason other than off will be considered as “leave without payment”", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("In case of hospitalization, medical leaves for max.15 days in a year.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("Other than above leaves any absence or leave will be treated as unpaid leave (auto calculation by software).", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("Co-ordinate with your head/Management for availing leaves.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));
            section.Blocks.Add(BuletedParagraph("Un-availed offs/leaves will not be en-cashed or carry forward to next financial year.", new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), 14));

            section.Blocks.Add(getParagraphText("The payment of emolument will be subjected to deduction of Income Taxes and Provident Fund as applicable.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Your services will be governed by the service rule book of the company which may be modified from time to time as required which may change time to time.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            section.Blocks.Add(getParagraphText("In case the above terms and conditions are acceptable to you, please sign and return the duplicate copy in token of your acceptance of the above.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));
            section.Blocks.Add(getParagraphText("Please carry signed copy of this letter at time of Joining with original envelope.", FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10));

            #region Signature Block


            table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            section.Blocks.Add(table);

            //tr = new TableRow();
            //Cell = GetCell(" ", 100, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 9, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["company_Name"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" ", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            if (ds.Tables[1].Rows[0]["sign_left_image"].ToString().Length > 2)
                Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_left_image"], 90, 50);
            else
                Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);

            //if (ds.Tables[1].Rows[0]["sign_right_image"].ToString().Length > 2)
            // Cell = GetImageCell(33, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center, (byte[])ds.Tables[1].Rows[0]["sign_right_image"], 90, 50);
            //else
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            Cell = GetCell(ds.Tables[1].Rows[0]["sign_title_left"].ToString(), 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell("", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            Cell = GetCell(" ", 33, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 10, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);




            tr = new TableRow();
            Cell = GetCell("Declaration : I have read and agree to the terms and conditions as set forth above in this letter of agreement.", 110, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);

            tr = new TableRow();
            tr.Height = 30;
            Cell = GetCell("  ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);


            tr = new TableRow();
            Cell = GetCell("Signature of Employee ", 110, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 8, 3, Telerik.WinForms.Documents.Layout.RadTextAlignment.Center, RadVerticalAlignment.Top);
            tr.Cells.Add(Cell);
            table.Rows.Add(tr);



            #endregion

            document.Sections.Clear();
            document.Sections.Add(section);

            return document;
        }

        private Paragraph BuletedParagraph(string text, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, int fontsize)
        {
            Telerik.WinForms.Documents.Lists.DocumentList list = new Telerik.WinForms.Documents.Lists.DocumentList(Telerik.WinForms.Documents.Lists.DefaultListStyles.Bulleted, this.ReportEditor2.Document);
            Paragraph listItemParagraph = new Paragraph();
            Span spn = new Span(text);
            spn.FontSize = fontsize;
            spn.FontFamily = fontfamily;
            listItemParagraph.Inlines.Add(spn);
            listItemParagraph.LineSpacing = 0.75;
            //listItemParagraph.Inlines.Add(new Break(BreakType.LineBreak));
            list.AddParagraph(listItemParagraph);
            return listItemParagraph;
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
        private void HeaderFooterToFirstAndLast()
        {
            ReportEditor.ToggleDifferentFirstPageHeaderFooter();
            Header header = new Header() { Body = HeaderBlock(_ds.Tables[2]), IsLinkedToPrevious = false };
            ReportEditor.UpdateHeader(ReportEditor.Document.Sections.First, HeaderFooterType.First, header);

            //Adding footer
            Footer footer = new Footer() { Body = FooterBlock(), IsLinkedToPrevious = false };
            Section lastSection = ReportEditor.Document.Sections.Last;
            lastSection.Footers.Default = footer;
        }
        private RadDocument CreateHeaderFooterDocument(string text)
        {
            Span span = new Span(text);
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(span);

            Section section = new Section();
            section.Blocks.Add(paragraph);

            RadDocument document = new RadDocument();
            document.Sections.Add(section);

            return document;
        }
        TableCell GetSalaryCell(string text, string designation, string dated, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
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

            Span span1 = new Span(text);
            span1.ForeColor = color;
            span1.FontWeight = FontWeights.Normal;
            span1.FontSize = Unit.PointToDip(fontsize);
            span1.FontFamily = fontfamily;

            Span span2 = new Span(designation);
            span2.ForeColor = color;
            span2.FontWeight = FontWeights.Bold;
            span2.FontSize = Unit.PointToDip(fontsize);
            span2.FontFamily = fontfamily;

            Span span3 = new Span(" From ");
            span3.ForeColor = color;
            span3.FontWeight = FontWeights.Normal;
            span3.FontSize = Unit.PointToDip(fontsize);
            span3.FontFamily = fontfamily;


            Span span4 = new Span(dated);
            span4.ForeColor = color;
            span4.FontWeight = FontWeights.Bold; ;
            span4.FontSize = Unit.PointToDip(fontsize);
            span4.FontFamily = fontfamily;

            paragraph.Inlines.Add(rs);
            paragraph.Inlines.Add(span1);
            paragraph.Inlines.Add(span2);
            paragraph.Inlines.Add(span3);
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
        TableCell GetIncludingBoldCell(string prm1, string prm2, string prm3, int width, FontWeight fontweight, Telerik.WinControls.RichTextEditor.UI.FontFamily fontfamily, Telerik.WinControls.RichTextEditor.UI.Color color, int fontsize, int colspan, RadTextAlignment HorzAlign, RadVerticalAlignment VertAlign)
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
        private RadDocument HeaderBlock(DataTable dt)
        {
            RadDocument headerDoc = new RadDocument();
            
            Table tableAdd = new Table();
            tableAdd.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
            tableAdd.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableAdd.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);

            #region Header
            DataRow dr = dt.Rows[0];
            Section section = new Section();

            Table tableblock = new Table();
            tableblock.Borders = new TableBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black));
            tableblock.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            tableblock.Tag = "Block";
            section.Blocks.Add(tableblock);

            #region Add Logo
            string path = Application.StartupPath + "\\ChandanLogo.jpg";
            TableRow rowblock = new TableRow();
            byte[] logo = System.IO.File.ReadAllBytes(path);
            TableCell logoCell = GetImageCell(20, 1, Telerik.WinForms.Documents.Layout.RadTextAlignment.Left, RadVerticalAlignment.Center, logo, 120, 50);
            logoCell.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(logoCell);
            #endregion

            TableCell tcaddress = GetAddressCell(dr["comp_name"].ToString(), "Corp. Office : " + dr["corp_office_add"].ToString(), "Reg. Office : " + dr["reg_office"].ToString(), dr["Phone_No"].ToString(), "CIN NO : " + dr["CIN_no"].ToString(), 80, FontWeights.Bold, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 1, RadTextAlignment.Left, RadVerticalAlignment.Top);
            tcaddress.Borders = new TableCellBorders(new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.None, Colors.Black), new Border(0.5f, Telerik.WinForms.Documents.Model.BorderStyle.Single, Colors.Black));
            rowblock.Cells.Add(tcaddress);
            tableblock.Rows.Add(rowblock);
            headerDoc.Sections.Add(section);
            //Table table = new Table();
            ////table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);
            ////section.Blocks.Add(table);
            //TableRow tr; TableCell Cell;
            //tr = new TableRow();
            //tr.Height = 40;
            //Cell = GetCell("", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Arial Narrow"), Colors.Black, 12, 2, Telerik.WinForms.Documents.Layout.RadTextAlignment.Right, RadVerticalAlignment.Center);
            //tr.Cells.Add(Cell);
            //table.Rows.Add(tr);

            #endregion
            return headerDoc;
        }
        private RadDocument FooterBlock()
        {
            RadDocument doc = new RadDocument();
            Section sec = new Section();
            Table table = new Table();
            table.PreferredWidth = new TableWidthUnit(TableWidthUnitType.Percent, 100);

            TableRow tr3 = new TableRow();
            TableCell cellPageNum = GetCell(" ", 100, FontWeights.Normal, new Telerik.WinControls.RichTextEditor.UI.FontFamily("Times New Roman"), Colors.Black, 8, 1, RadTextAlignment.Right, RadVerticalAlignment.Center);
            tr3.Cells.Add(cellPageNum);
            table.Rows.Add(tr3);
            sec.Blocks.Add(table);
            doc.Sections.Add(sec);
            doc.MeasureAndArrangeInDefaultSize();
            doc.CaretPosition.MoveToStartOfDocumentElement(cellPageNum);

            RadDocumentEditor editor = new RadDocumentEditor(doc);
            editor.Document.CaretPosition.MoveToStartOfDocumentElement(cellPageNum);
            editor.Insert("Page ");
            PageField page = new PageField();
            page.DisplayMode = FieldDisplayMode.Result;
            editor.InsertField(page);
            editor.Insert(" of ");
            //editor.Insert(" 30");
            editor.InsertField(new NumPagesField());
            editor.UpdateAllFields(FieldDisplayMode.Result);

            return doc;
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
        #endregion
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("If Print(Yes) if PrintPreview(No)", "Confirmation", MessageBoxButtons.YesNo).ToString() == "Yes")
                ReportEditor.Print();
            else
                ReportEditor.PrintPreview();
        }

        private void dgPatients_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
        string _empcode = string.Empty;
        string _staffType = string.Empty;
        string _companyName = string.Empty;
        DataSet dsLetterSign = new DataSet();
        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            LoadLetterInfo();
        }

        private void LoadLetterInfo()
        {
            _empcode = dgEmpList.CurrentRow.Cells[0].Value.ToString();
            _staffType = dgEmpList.CurrentRow.Cells["status"].Value.ToString();
            _emailsendby = dgEmpList.CurrentRow.Cells["email_by"].Value.ToString();

            if (_staffType.ToUpper() == "PROFESSIONAL" || _staffType.ToUpper() == "SPCA")
                _letterType = "Contract Letter";
            else
                _letterType = "Appointment Letter";
            lblemployee.Text = dgEmpList.CurrentRow.Cells["emp_name"].Value + " [" + _empcode + "], " + _staffType;
            lblEmpOffer.Text = dgEmpList.CurrentRow.Cells["emp_name"].Value + " [" + _empcode + "], " + _staffType;
            Cursor.Current = Cursors.WaitCursor;
            string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','" + _letterType + "','-','CheckPreservedLetter' ";
            DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
            if(ds.Tables[0].Rows.Count>0)
            { 
            if (dgEmpList.CurrentRow.Cells["letter_no"].Value.ToString().Length < 5)
                dgEmpList.CurrentRow.Cells["letter_no"].Value = ds.Tables[0].Rows[0]["letter_no"].ToString();
            }
            if (ddlLetterName.Text == "Appointment Letter")
            { AppointmentLetterView(ds); btnMail.Enabled = true; }
            else
            { OfferLetterView(ds); btnMail.Enabled = false; }
            Cursor.Current = Cursors.Default;
        }

        byte[] data;
        private void AppointmentLetterView(DataSet ds)
        {
            try
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    radSplitContainer1.SplitPanels[0].Collapsed = true;
                    radSplitContainer1.SplitPanels[1].Collapsed = false;
                    data = ((byte[])ds.Tables[0].Rows[0]["letter_content"]);
                    if (data.Length > 0)
                    {
                        pnlControl.Enabled = true;
                        btnPreview.Enabled = false; btnSaveApp.Enabled = false; btnMail.Enabled = true;
                        //this.radPdfViewer1.UnloadDocument();
                        // string path = Application.StartupPath + "\\" + "temp.pdf";
                        //File.WriteAllBytes(path, data);
                        pdfViewAppoint.LoadDocument(new MemoryStream(data));
                        //this.radPdfViewer2.LoadDocument(Application.StartupPath + "\\" + "temp.pdf");
                    }
                    else
                    { MessageBox.Show("Report not uploaded"); }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    btnGenLetter.Enabled = true;
                    btnPreview.Enabled = true; btnSaveApp.Enabled = true; btnMail.Enabled = false;
                    pnlControl.Enabled = true;
                    radSplitContainer1.SplitPanels[0].Collapsed = false;
                    radSplitContainer1.SplitPanels[1].Collapsed = true;
                }
            }
            catch (Exception ex)
            {
                pnlControl.Enabled = true;
                radSplitContainer1.SplitPanels[0].Collapsed = false;
                radSplitContainer1.SplitPanels[1].Collapsed = true;
            }
            try
            {
                ReportEditor.Document = new RadDocument();
            }
            catch (Exception ex) { }

        }
        private void OfferLetterView(DataSet ds)
        {
            try
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    radSplitContainer2.SplitPanels[0].Collapsed = true;
                    radSplitContainer2.SplitPanels[1].Collapsed = false;
                    data = ((byte[])ds.Tables[0].Rows[0]["letter_content"]);
                    if (data.Length > 0)
                    {
                        pnlControlOffer.Enabled = false;
                        pdfViewOffer.LoadDocument(new MemoryStream(data));
                    }
                    else
                    { MessageBox.Show("Report not uploaded"); }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    pnlControlOffer.Enabled = true;
                    radSplitContainer2.SplitPanels[0].Collapsed = false;
                    radSplitContainer2.SplitPanels[1].Collapsed = true;
                }
            }
            catch (Exception ex)
            {
                pnlControlOffer.Enabled = true;
                radSplitContainer2.SplitPanels[0].Collapsed = false;
                radSplitContainer2.SplitPanels[1].Collapsed = true;
            }
            try
            {
                ReportEditor2.Document = new RadDocument();
            }
            catch (Exception ex) { }

        }
        private void ddlLetterName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlLetterName.SelectedItem.ToString() == "Appointment Letter")
            {
                PageReport.SelectedPage = PageReport.Pages[0];
                radPageViewPage1.Enabled = true;
                radPageViewPage2.Enabled = false;
            }
            else
            {
                PageReport.SelectedPage = PageReport.Pages[1];
                radPageViewPage1.Enabled = false;
                radPageViewPage2.Enabled = true;
                FillOfferLetterList();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbCompany.Text.ToUpper()=="SELECT")
                {
                    MessageBox.Show("Select Company");
                    return;
                }
                byte[] img = null;
                Cursor.Current = Cursors.WaitCursor;
                if (btnSave.Text == "Save")
                {
                    _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(cmbCompany.Text, ddlLetterName.Text, img, dtissue_date.Value.ToString("yyyy/MM/dd"), "-", txtempname.Text, txtmobile.Text, txtAddress.Text, ddldesignation.Text, Convert.ToDecimal(txtamount.Text), Convert.ToDecimal(txtPBonus.Text), "Y", GlobalUsage.Login_id, "Save");
                    if (_result.Contains("Success"))
                    {
                        FillOfferLetterList();
                    }
                }
                else
                    _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(cmbCompany.Text, ddlLetterName.Text, img, dtissue_date.Value.ToString("yyyy/MM/dd"), ddlEmployeeList.SelectedValue.ToString(), txtempname.Text, txtmobile.Text, txtAddress.Text, ddldesignation.Text, Convert.ToDecimal(txtamount.Text), Convert.ToDecimal(txtPBonus.Text), "Y", GlobalUsage.Login_id, "Update");
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }
        private void FillOfferLetterList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ddlEmployeeList.Items.Clear();
                byte[] img = null;
                string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','" + ddlLetterName.Text + "','-','OfferLetterNameList' ";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                ddlEmployeeList.Items.AddRange(Config.FillTelrikCombo(ds.Tables[0]));
                ddlEmployeeList.SelectedIndex = 0;
                ddldesignation.Items.AddRange(Config.FillTelrikCombo(ds.Tables[1]));
                ddldesignation.SelectedIndex = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void btnSaveOfferLetter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                PdfFormatProvider provider = new PdfFormatProvider();
                pdfbyte = provider.Export(ReportEditor2.Document);
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(_empcode, ddlLetterName.Text, pdfbyte, System.DateTime.Now.ToString("yyyy/MM/dd"), ddlEmployeeList.SelectedValue.ToString(), "-", "-", "-", "-", 0, 0, "Y", GlobalUsage.Login_id, "UpdateOfferPDF");
                if (_result.Contains("Success"))
                { }
                MessageBox.Show(_result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void btnViewLetter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','" + ddlEmployeeList.SelectedValue.ToString() + "','-','CheckPreservedOfferLetter' ";
            DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
            btnSaveOfferLetter.Enabled = true;
            btnSave.Enabled = true;
            btnLinkLetter.Enabled = false;
            btnSave.Text = "Save";
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cmbCompany.Text = ds.Tables[0].Rows[0]["compCode"].ToString();
                txtempname.Text = ds.Tables[0].Rows[0]["t_name"].ToString();
                txtmobile.Text = ds.Tables[0].Rows[0]["t_mobile"].ToString();
                txtamount.Text = ds.Tables[0].Rows[0]["t_amount"].ToString();
                txtPBonus.Text = ds.Tables[0].Rows[0]["t_bonus"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["t_address"].ToString();
                dtissue_date.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["issue_date"]);
                ddldesignation.Text = ds.Tables[0].Rows[0]["t_designation"].ToString();
                btnSaveOfferLetter.Enabled = true;
                btnSave.Text = "Update";

                if (ds.Tables[0].Rows[0]["emp_code"].ToString() == "-")
                    btnLinkLetter.Enabled = true;
                else
                    btnLinkLetter.Enabled = false;

                if (ds.Tables[0].Rows[0]["status"].ToString() == "Y")
                {
                    radSplitContainer2.SplitPanels[0].Collapsed = true;
                    radSplitContainer2.SplitPanels[1].Collapsed = false;
                    btnSave.Enabled = false;
                    btnSaveOfferLetter.Enabled = false;
                    byte[] data = ((byte[])ds.Tables[0].Rows[0]["letter_content"]);
                    if (data.Length > 0)
                    {
                        pdfViewOffer.LoadDocument(new MemoryStream(data));
                    }
                }
                else
                {
                    GetOfferLetter(ddlEmployeeList.SelectedValue.ToString());
                }
            }
            else
            {
                btnLinkLetter.Enabled = true;
                txtempname.Text = "";
                txtmobile.Text = "";
                txtamount.Text = "";
                txtAddress.Text = "";
                ddldesignation.Text = "";
            }

        }
        private void MasterPanelOffer_Paint(object sender, PaintEventArgs e)
        {

        }
        byte[] bytedata;
        int letterid = 0;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog odg = new System.Windows.Forms.OpenFileDialog();
            odg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            odg.ShowDialog();
            try
            {
                bytedata = System.IO.File.ReadAllBytes(odg.FileName);
                pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(bytedata));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSaveSign_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string imageLeftRight = string.Empty;
                if (rbtnLeft.Checked)
                { imageLeftRight = "Left"; }
                else
                { imageLeftRight = "Right"; }
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterSignature(letterid, imageLeftRight, bytedata, "Update");
                MessageBox.Show(_result);
            }
            catch (Exception ex) { }
            { Cursor.Current = Cursors.Default; }
        }
        private void PageReport_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (PageReport.SelectedPage.Text == "Update Signature")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','" + ddlLetterName.Text + "','-','LetterNames' ";
                    DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                    dgletterName.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void radPageViewPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgletterName_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            letterid = Convert.ToInt32(dgletterName.CurrentRow.Cells["auto_id"].Value);
            lblName.Text = dgletterName.CurrentRow.Cells["letter_name"].Value.ToString();
        }
        private void btnAppPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If Print(Yes) if PrintPreview(No)", "Confirmation", MessageBoxButtons.YesNo).ToString() == "Yes")
                ReportEditor.Print();
            else
                ReportEditor.PrintPreview();
        }
        byte[] pdfbyte;
        private void btnSaveApp_Click(object sender, EventArgs e)
        {
            if (btnPreview.Enabled)
            {
                MessageBox.Show("First Click on Preview.");
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
       
                PdfFormatProvider provider = new PdfFormatProvider();
                pdfbyte = provider.Export(ReportEditor.Document);
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(_empcode, _letterType, pdfbyte, System.DateTime.Now.ToString("yyyy/MM/dd"), "-", "-", "-", "-", "-", 0, 0, "Y", GlobalUsage.Login_id, "UpdatePDF");
                if (_result.Contains("Success"))
                { LoadLetterInfo(); }
                //MessageBox.Show(_result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnGenLetter_Click(object sender, EventArgs e)
        {
            try
            {
                PdfFormatProvider provider = new PdfFormatProvider();
                

                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(_empcode, _letterType, pdfbyte,
                    System.DateTime.Now.ToString("yyyy/MM/dd"), "-", "-", "-", "-", "-", 0, 0, "Y", GlobalUsage.Login_id, "Save");
                if (_result.Contains("Success"))
                { }
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnPreview.Enabled = false;
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(_empcode, _letterType, pdfbyte,
                   System.DateTime.Now.ToString("yyyy/MM/dd"), "-", "-", "-", "-", "-", 0, 0, "Y", GlobalUsage.Login_id, "Save");
                string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','" + ddlLetterName.Text + "','-','LetterSignature' ";
                dsLetterSign = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                GetLetter(_empcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If Print(Yes) if PrintPreview(No)", "Confirmation", MessageBoxButtons.YesNo).ToString() == "Yes")
                ReportEditor.Print();
            else
                ReportEditor.PrintPreview();
        }
        private void btnLinkLetter_Click(object sender, EventArgs e)
        {
            try
            {
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterInfo(_empcode, ddlLetterName.Text, pdfbyte, System.DateTime.Now.ToString("yyyy/MM/dd"), ddlEmployeeList.SelectedValue.ToString(), "-", "-", "-", "-", 0, 0, "Y", GlobalUsage.Login_id, "LinkEmployee");
                if (_result.Contains("Success"))
                {
                    btnLinkLetter.Enabled = false;
                }
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteSign_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string imageLeftRight = string.Empty;
                if (rbtnLeft.Checked)
                { imageLeftRight = "Left"; }
                else
                { imageLeftRight = "Right"; }
                _result = GlobalUsage.hr_proxy.Insert_Modify_EmployeeLetterSignature(letterid, imageLeftRight, bytedata, "Delete");
                MessageBox.Show(_result);
            }
            catch (Exception ex) { }
            { Cursor.Current = Cursors.Default; }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pLetter_Queries '" + _empcode + "','1900/01/01','-','-','GetAllLetters' ";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                dgLetters.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { }
            { Cursor.Current = Cursors.Default; }
        }

        private void dgLetters_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (dgLetters.CurrentRow.Cells["status"].Value.ToString() == "Y")
                pnlCorrection.Enabled = true;
            else
                pnlCorrection.Enabled = false;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "pDeletePreservedLetter '" + dgLetters.CurrentRow.Cells["letter_no"].Value.ToString() + "','" + txtRemarkforCorr.Text.Replace("'", " ") + "','" + GlobalUsage.Login_id + "','Insert','-'";
                GlobalUsage.hr_proxy.QueryExecute(qry, "ExHrd");
                MessageBox.Show("Successfully Unlocked");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;

        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnSaveApp.Enabled)
                {
                    MessageBox.Show("First Save The Letter and Click On Employee Only Then You can send the Mail.");
                    return;
                }
                if (_empcode.Length > 0 && _empcode != "Select")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string subject = string.Empty;
                    if (_staffType.ToUpper() == "PROFESSIONAL" || _staffType.ToUpper() == "SPCA")
                        subject = "Contarct Document";
                    else
                        subject = "Appointment Letter";

                    string FileName = "SS_"+ subject + _empcode.Replace("-", "") + ".pdf";
                    try
                    {
                        //if (_empcode.Contains("CHL"))
                        //    _emailsendby = "hr@Hosp";
                        //else if (_empcode.Contains("CHCL"))
                        //    _emailsendby = "hr@Diag";
                        //else if (_empcode.Contains("CPL"))
                        //    _emailsendby = "hr@Phar";
                        //else if (_empcode.Contains("IDC"))
                        //    _emailsendby = "hr@Phar";

                        string msg = GlobalUsage.accounts_proxy.Insert_ConversationByDesktopApp("Post", _emailsendby, _empcode, "", subject, "Kindly download " + subject + ".", 0, "Normal", data, FileName);
                        MessageBox.Show(msg);
                        string qry = "update EmployeeLetterInfo set email_flag='Y',email_date=getdate(),email_by='" + GlobalUsage.Login_id + "' where letter_no='" + dgEmpList.CurrentRow.Cells["letter_no"].Value.ToString() + "'";
                        GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    Cursor.Current = Cursors.Default;
                }
                else
                { MessageBox.Show("Please select employee"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["email_flag"].Value.ToString()=="Y")
                e.RowElement.ForeColor = System.Drawing.Color.Green;
            else if (e.RowElement.RowInfo.Cells["letter_no"].Value.ToString().Length>4)
                e.RowElement.ForeColor = System.Drawing.Color.Blue;
            else
                e.RowElement.ForeColor = System.Drawing.Color.Black;

        }

        
    }
}
