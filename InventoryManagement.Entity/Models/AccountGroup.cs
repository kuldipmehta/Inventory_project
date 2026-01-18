using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class AccountGroup : BaseModel
    {
        public int GroupId { get; set; }
        public int GroupIdManual { get; set; }
        public int GroupTypeId { get; set; }
        public string GroupTypeName { get; set; }
        public string GroupName { get; set; }
        public bool AccountTransferdToBranch { get; set; }
        

       
    }

}
