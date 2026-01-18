using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Company : BaseModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string SubCompanyName { get; set; }
        public string ShortName { get; set; }
        public int BusinessTypeId { get; set; }
        public string BusinessTypeName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Pincode { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string WebSite { get; set; }
        public string GSTNo { get; set; }
        public string PANNO { get; set; }
        public string JurisDiction { get; set; }
        public int CurrentBranchId { get; set; }
        public bool WithOutBarcodeOption { get; set; }
        public bool CompositionScheme { get; set; }
        public string TaxPayerTypeId { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }

    }
}
