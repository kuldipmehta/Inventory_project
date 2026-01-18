using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class TermsNCondition : BaseModel
    {
        public int CompanyID { get; set; }

        public int BranchID { get; set; }

        public byte[] CompanyLogo { get; set; }

        public string SalesHeaderPrintValue { get; set; }

        public string SalesFooterPrintValue { get; set; }

        public string OrderHeaderPrintValue { get; set; }

        public string OrderFooterPrintValue { get; set; }

        public string TermsCondition { get; set; }



    }

}
