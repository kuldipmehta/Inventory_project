using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Employee : BaseModel
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string EmployeeCode { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public string AlloweCompanyId { get; set; }
        public string AllowedBranchId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string PinCode { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string AdharCardNo { get; set; }
        public int GenderId { get; set; }
        public string EmailId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ResignDate { get; set; }
        public int WeekoffDay { get; set; }
        public double Salary { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public int AccountId { get; set; }
        public string CommissionOn { get; set; }
        public double CommisionPrc { get; set; }
    }


}
