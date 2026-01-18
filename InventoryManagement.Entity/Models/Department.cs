using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Department : BaseModel
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
