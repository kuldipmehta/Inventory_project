using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Area : BaseModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string PinCode { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public string RegionCode { get; set; }
    }
}
