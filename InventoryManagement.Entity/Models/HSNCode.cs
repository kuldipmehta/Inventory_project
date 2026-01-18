using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class HSNCode : BaseModel
    {
        public int HSNCodeId { get; set; }
        public string HsnCode { get; set; }
        public string HSNDetail { get; set; }
        public List<HSNTax> HSNTaxes { get; set; }
    }

    public class HSNTax : BaseModel
    {
        public int HSNTaxId { get; set; }
        public int HSNCodeId { get; set; }
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
        public double FromRate { get; set; }
        public double ToRate { get; set; }
        public double FromPurcRate { get; set; }
        public double ToPurcRate { get; set; }
    }
}
