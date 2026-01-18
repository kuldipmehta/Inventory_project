using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Style:BaseModel
    {
        public int StyleId { get; set; }

        public string StyleName { get; set; }

        public string ShortName { get; set; }
    }


}
