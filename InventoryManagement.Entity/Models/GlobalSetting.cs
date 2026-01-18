using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class GlobalSetting : BaseModel
    {
        public int GlobalSettingId { get; set; }
        public string SiteName { get; set; }
        public string CurrentSiteUrl { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
        public string SiteTagLine { get; set; }
        public string SiteFooter { get; set; }
        public string ReceivedOnEmail { get; set; }
        public string SendFromEmail { get; set; }
        public string SMTP { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public bool SSL { get; set; }
        public string PathToFolder { get; set; }
        public int ListLimit { get; set; }
    }
}
