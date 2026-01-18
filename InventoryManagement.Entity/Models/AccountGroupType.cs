using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class AccountGroupType : BaseModel
    {
        public int AccountGroupTypeId { get; set; }
        public string GroupTypeName { get; set; }
        public string AccountGroupCrDrType { get; set; }
    }
}
