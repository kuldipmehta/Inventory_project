using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class City : BaseModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int? StateId { get; set; }
        public string StateName { get; set; }
    }

}
