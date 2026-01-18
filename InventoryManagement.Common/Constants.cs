using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Common
{
    public static class Constants
    {
        public static string BaseURL { get; set; }
        public static class Status
        {
            public static int Success { get { return 0; } }
            public static int Warning { get { return 1; } }
            public static int Error { get { return 2; } }
            public static int Info { get { return 3; } }
        }

        public static class UserStatus
        {
            public static int Pending { get { return 1; } }
            public static int Approved { get { return 2; } }
            public static int Rejected { get { return 3; } }
            public static int Deleted { get { return 4; } }
        }

        public static class VisitorStatus
        {
            public static int Expected { get { return 1; } }
            public static int In { get { return 2; } }
            public static int Out { get { return 3; } }
            public static int Rejected { get { return 4; } }
            public static int Cancelled { get { return 5; } }
        }

      

        //public enum Role
        //{
        //    [Description("System Admin")]
        //    SYSTEMADMIN = 1,

        //    [Description("Admin")]
        //    ADMIN = 2,

        //    [Description("User")]
        //    USER = 3,
        //}

    }
}
