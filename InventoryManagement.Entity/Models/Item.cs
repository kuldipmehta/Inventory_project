using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Item : BaseModel
    {
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public int StyleId { get; set; }
        public int GroupId { get; set; }
        public string DepartmentName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string StyleName { get; set; }
        public string GroupName { get; set; }
        public string ItemName { get; set; }
        public string ShortName { get; set; }
        public string BarcodeType { get; set; }
        public string ItemShortcut { get; set; }
        public double DefaultQty { get; set; }
        public string HsnCode { get; set; }
        public string DayBookType { get; set; }
        public bool ItemWiseMargin { get; set; }
    }
}
