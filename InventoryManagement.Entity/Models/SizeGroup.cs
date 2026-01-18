using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class SizeGroup : BaseModel
    {
        public int SizeGroupId { get; set; }
        public string SizeGroupName { get; set; }
        public string SizeNames { get; set; }
        public List<SizeGroupSize> SizeList
        {
            get
            {
                if (string.IsNullOrEmpty(SizeNames))
                {
                    return new List<SizeGroupSize>();
                }
                else
                {
                    int i = 0;
                    return SizeNames.Split(",").Select(a => new SizeGroupSize() { SrNo = ++i, SizeShortName = a }).ToList();
                }
            }
        }

    }
}
