using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Size : BaseModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string ShortName { get; set; }
        public int SrNo { get; set; }
        public List<SizeCountry> SizeCountryList { get; set; }
    }
    public class SizeCountry
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string USSizeShortName { get; set; }
        public string EuropSizeShortName { get; set; }
        public string LengthCM { get; set; }
        public string LengthInch { get; set; }
    }
}
