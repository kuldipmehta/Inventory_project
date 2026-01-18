using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class DesignNos : BaseModel
    {
        public int DesignNoId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string DesignNo { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double PurchaseRate { get; set; }
        public double SalesRate { get; set; }
        public double Mrp { get; set; }
        public double WhSalesRate { get; set; }
        public double WhSalesRate2 { get; set; }
        public double MinStockQty { get; set; }
        public double  MaxStockQty { get; set; }
        public string Remarks { get; set; }
    }


}
