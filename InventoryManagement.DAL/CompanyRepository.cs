using Dapper;
using InventoryManagement.Common;
using InventoryManagement.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InventoryManagement.DAL;
using System.Data;

namespace InventoryManagement.DAL
{
    public class CompanyRepository : BaseRepository
    {
        public async Task<IEnumerable<Company>> CompanyList(bool isActive = true)
        {
            IEnumerable<Company> CompanyList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CompanyList = await connection.QueryAsync<Company>("GetCompanyDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return CompanyList;
        }


        public async Task<IEnumerable<CompanyType>> CompanyTypeList(bool isActive = true)
        {
            IEnumerable<CompanyType> CompanyTypeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CompanyTypeList = await connection.QueryAsync<CompanyType>("GetCompanyTypeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return CompanyTypeList;
        }

        public async Task<IEnumerable<BusinessType>> BusinessTypeList(bool isActive = true)
        {
            IEnumerable<BusinessType> BusinessTypeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BusinessTypeList = await connection.QueryAsync<BusinessType>("GetBusinessTypeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return BusinessTypeList;
        }

        public async Task<IEnumerable<int>> AddCompany(Company company)
        {
            IEnumerable<int> CompanyList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CompanyName", company.CompanyName);
            parameter.Add("@SubCompanyName", company.SubCompanyName);
            parameter.Add("@ShortName", company.ShortName);
            parameter.Add("@BusinessTypeId", company.BusinessTypeId);
            parameter.Add("@Address", company.Address);
            parameter.Add("@CityId", company.CityId);
            parameter.Add("@StateId", company.StateId);
            parameter.Add("@Pincode", company.Pincode);
            parameter.Add("@PhoneNo", company.PhoneNo);
            parameter.Add("@MobileNo", company.MobileNo);
            parameter.Add("@EmailId", company.EmailId);
            parameter.Add("@WebSite", company.WebSite);
            parameter.Add("@GSTNo", company.GSTNo);
            parameter.Add("@PANNO", company.PANNO);
            parameter.Add("@JurisDiction", company.JurisDiction);
            parameter.Add("@CurrentBranchId", company.CurrentBranchId);
            parameter.Add("@WithOutBarcodeOption", company.WithOutBarcodeOption);
            parameter.Add("@CompositionScheme", company.CompositionScheme);
            parameter.Add("@TaxPayerTypeId", company.TaxPayerTypeId);
            parameter.Add("@CompanyTypeId", company.CompanyTypeId);
            parameter.Add("@CreatedBy", company.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CompanyList = await connection.QueryAsync<int>("AddCompany",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CompanyList;
        }

        public async Task<IEnumerable<int>> EditCompany(Company company)
        {
            IEnumerable<int> CompanyList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CompanyId", company.CompanyId);
            parameter.Add("@CompanyName", company.CompanyName);
            parameter.Add("@SubCompanyName", company.SubCompanyName);
            parameter.Add("@ShortName", company.ShortName);
            parameter.Add("@BusinessTypeId", company.BusinessTypeId);
            parameter.Add("@Address", company.Address);
            parameter.Add("@CityId", company.CityId);
            parameter.Add("@StateId", company.StateId);
            parameter.Add("@Pincode", company.Pincode);
            parameter.Add("@PhoneNo", company.PhoneNo);
            parameter.Add("@MobileNo", company.MobileNo);
            parameter.Add("@EmailId", company.EmailId);
            parameter.Add("@WebSite", company.WebSite);
            parameter.Add("@GSTNo", company.GSTNo);
            parameter.Add("@PANNO", company.PANNO);
            parameter.Add("@JurisDiction", company.JurisDiction);
            parameter.Add("@CurrentBranchId", company.CurrentBranchId);
            parameter.Add("@WithOutBarcodeOption", company.WithOutBarcodeOption);
            parameter.Add("@CompositionScheme", company.CompositionScheme);
            parameter.Add("@TaxPayerTypeId", company.TaxPayerTypeId);
            parameter.Add("@CompanyTypeId", company.CompanyTypeId);
            parameter.Add("@UpdatedBy", company.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", company.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CompanyList = await connection.QueryAsync<int>("EditCompany",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CompanyList;
        }

        public async Task<IEnumerable<int>> DeleteCompany(int companyId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> CompanyList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CompanyId", companyId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CompanyList = await connection.QueryAsync<int>("DeleteUnDeleteCompany",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CompanyList;
        }
    }
}
