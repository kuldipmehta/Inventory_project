using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Permission : BaseModel
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }
    }
}
