using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Tax : TaxAccount
    {
        public int TaxId { get; set; }

        public int TaxTypeId { get; set; }

        public string TaxTypeName { get; set; }

        public string TaxName { get; set; }

        public double SGSTPrc { get; set; }

        public double? CGSTPrc { get; set; }

        public double? IGSTPrc { get; set; }

        public double SurchargePrc { get; set; }

    }

    public class TaxAccount : BaseModel
    {
        public int CompanyId { get; set; }

        public int? SGSTInPutAccountId { get; set; }

        public int? CGSTInPutAccountId { get; set; }

        public int? IGSTInPutAccountId { get; set; }

        public int? SGSTOutPutAccountId { get; set; }

        public int? CGSTOutPutAccountId { get; set; }

        public int? IGSTOutPutAccountId { get; set; }

        public int? SGSTPayableAccountId { get; set; }

        public int? CGSTPayableAccountId { get; set; }

        public int? IGSTPayableAccountId { get; set; }

        public int? RCMSGSTPayableAccountId { get; set; }

        public int? RCMCGSTPayableAccountId { get; set; }

        public int? RCMIGSTPayableAccountId { get; set; }

        public int? RCMInPutSGSTAccountId { get; set; }

        public int? RCMInPutCGSTAccountId { get; set; }

        public int? RCMInPutIGSTAccountId { get; set; }

        public int? RCMOutPutSGSTAccountId { get; set; }

        public int? RCMOutPutCGSTAccountId { get; set; }

        public int? RCMOutPutIGSTAccountId { get; set; }

    }
    public class TaxType : BaseModel
    {
        public int TaxTypeId { get; set; }

        public string TaxTypeName { get; set; }

        public bool? IsFormRequired { get; set; }
    }
}
