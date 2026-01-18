using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Brand :BaseModel
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string ShortName { get; set; }

        public int SrNo { get; set; }
    }


}
