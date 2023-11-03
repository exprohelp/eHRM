using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHRM
{
    public class datasetWithResult
    {
        public DataSet result { get; set; }
        public string message { get; set; }
    }
    public class resultSetMIS
    {
        public DataSet ResultSet { get; set; }
        public string Msg { get; set; }
    }
    public class ipDocument
    {
        public string DocumentId { get; set; }
        public string DocType { get; set; }
        public string DocName { get; set; }
        public string DocVirtualPath { get; set; }
        public string DocPhysicalpath { get; set; }
        public string loginId { get; set; }
        public string Logic { get; set; }
    }
    public class orgDocuments
    {
        public string autoId { get; set; }
        public string emp_code { get; set; }
        public string docNme { get; set; }
        public string DoD { get; set; }
        public string depositedBy { get; set; }
        public string DoR { get; set; }
        public string releasedBy { get; set; }
        public string Remarks { get; set; }
        public string Logic { get; set; }
    }
    public class ipCV
    {
        public string cv_id { get; set; }
        public string cv_name { get; set; }
        public string Gender { get; set; }
        public string dob { get; set; }
        public string cv_type { get; set; }
        public string IsExperienced { get; set; }
        public decimal exprYears { get; set; }
        public string remarks { get; set; }
        public string entryBy { get; set; }
        public string DocumentName { get; set; }
        public string DocType { get; set; }
        public string cvFilePath { get; set; }
        public string cvVirtualPath { get; set; }
        public string Logic { get; set; }
        public string MobileNo { get; set; }
        public string eMail { get; set; }

    }
}
