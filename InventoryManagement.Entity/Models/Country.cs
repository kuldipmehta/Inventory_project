using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Country : BaseModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public string MobileFixCode { get; set; }

        public double CurrencyRate { get; set; }
    }
}
