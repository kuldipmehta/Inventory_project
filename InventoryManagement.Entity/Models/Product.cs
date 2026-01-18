using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Product : BaseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public string SizeGroupId { get; set; }
        public int[] SizeGroupIds { get { return string.IsNullOrEmpty(SizeGroupId) ? (new int[0]) : SizeGroupId.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => Convert.ToInt32(a)).ToArray(); } }
        public int MeasurementTypeId { get; set; }

        public string ProductNames { get; set; }
        public List<ProductSize> ProductList
        {
            get
            {
                if (string.IsNullOrEmpty(ProductNames))
                {
                    return new List<ProductSize>();
                }
                else
                {
                    int i = 0;
                    return ProductNames.Split(",").Select(a => new ProductSize() { SrNo = ++i, SizeShortName = a }).ToList();
                }
            }
        }
    }
    public class ProductSize
    {
        public string SizeShortName { get; set; }
        public int SrNo { get; set; }
    }

}
