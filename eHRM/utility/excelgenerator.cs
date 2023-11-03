using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace eHRM
{
    public class ExcelGenerator
    {
        public byte[] GetExcelFile(DataSet ds)
        {
            byte[] data = null;
            try
            {
                var ms = new MemoryStream();
                using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                {
                    if (ds.Tables.Count > 0)
                    {
                        int ct = 1;
                        foreach (DataTable dt in ds.Tables)
                        {
                            wb.Worksheets.Add(dt, "Sheet" + ct.ToString());
                            ct++;
                        }
                    }
                    else { wb.Worksheets.Add(ds.Tables[0], "Sheet1"); }
                    wb.SaveAs(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                }
                data = ms.ToArray();
            }
            catch (Exception ex)
            {
            }
            return data;
        }
    }
}
