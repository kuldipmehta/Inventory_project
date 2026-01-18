using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class AccountCategory :BaseModel
    {
        public int AccountCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ShortCode { get; set; }
    }


}
