using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Entity.Models
{
    public class ApplicationUser : BaseModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Address { get; set; } = string.Empty;

        public string AdharCardNo { get; set; } = string.Empty;

        public string AllowedCompanyID { get; set; } = string.Empty;

        public string AllowedBranchID { get; set; } = string.Empty;

        public int LoginCompanyID { get; set; } 

        public int LoginBranchID { get; set; }

        public bool DefaultLastFinancialYearID { get; set; }

        public int AllowedListingDays { get; set; }

        public double AllowedDiscountLimitPrc { get; set; }

        public int PreviousDateEntryDays { get; set; }

        public bool PurchaseRateShow { get; set; }

        public bool AllUserDataShow { get; set; }

        public string AllowedDayBookID { get; set; } = string.Empty;

        public byte[] UserImage { get; set; }
    }
}
