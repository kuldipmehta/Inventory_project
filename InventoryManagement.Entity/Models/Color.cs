using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Color : BaseModel
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int SrNo { get; set; }
    }

}
