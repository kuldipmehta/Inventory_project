using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Navigation
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<Navigation> Children { get; set; }
    }
}
