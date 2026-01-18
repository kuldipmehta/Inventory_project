using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class EmployeeDesignation : BaseModel
    {
        public int DesignationId { get; set; }
        public string Designation { get; set; }
    }

}
