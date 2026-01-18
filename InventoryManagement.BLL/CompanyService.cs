using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class CompanyService : ICompanyService
    {
        CompanyRepository companyRepository = null;

        public async Task<IEnumerable<int>> AddCompany(Company Company)
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.AddCompany(Company);
            }
        }

        public async Task<IEnumerable<int>> EditCompany(Company Company)
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.EditCompany(Company);
            }
        }

        public async Task<IEnumerable<Company>> CompanyList()
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.CompanyList();
            }
        }

        public async Task<IEnumerable<BusinessType>> BusinessTypeList()
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.BusinessTypeList();
            }
        }

        public async Task<IEnumerable<CompanyType>> CompanyTypeList()
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.CompanyTypeList();
            }
        }

        public async Task<IEnumerable<int>> DeleteCompany(int CompanyId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (companyRepository = new CompanyRepository())
            {
                return await companyRepository.DeleteCompany(CompanyId, isActive, updatedBy, changeTimeStamp);
            }
        }

       
    }

}
