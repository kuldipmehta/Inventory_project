
using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> CompanyList();
        Task<IEnumerable<BusinessType>> BusinessTypeList();
        Task<IEnumerable<CompanyType>> CompanyTypeList();
        Task<IEnumerable<int>> AddCompany(Company company);
        Task<IEnumerable<int>> EditCompany(Company company);
        Task<IEnumerable<int>> DeleteCompany(int companyId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
