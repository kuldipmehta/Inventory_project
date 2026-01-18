using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class SizeGroupSize : BaseModel
    {
        public int SizeGroupSizeId { get; set; }
        public int SizeGroupId { get; set; }
        public string SizeShortName { get; set; }
        public int SrNo { get; set; }
    }
}
