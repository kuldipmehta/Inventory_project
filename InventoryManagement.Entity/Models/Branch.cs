using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Branch : BaseModel
    {
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public string BranchName { get; set; }
        public string BranchType { get; set; }
        public string BranchVoucherNoPrefix { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string OtherMobile { get; set; }
        public string PhoneNo { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string GSTNo { get; set; }
        public string OutwardRateType { get; set; }
        public int FromCustCardNo { get; set; }
        public int ToCustCardNo { get; set; }
        public int BranchAccountId { get; set; }
        public int HOAccountId { get; set; }
        public string AllowedBankAccountId { get; set; }
        public string AllowedCardAccountId { get; set; }
        public string AllowedBankDaybookId { get; set; }
        public string AllowedCompanyId { get; set; }
        public int StockOutwardAccountId { get; set; }
        public int StockInwardAccountId { get; set; }
        public int TaxPayerTypeId { get; set; }
    }
}
