using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class ItemGroup : BaseModel
    {
        public int ItemGroupId { get; set; }

        public string ItemGroupName { get; set; }
    }
}
