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
    public class BranchRepository : BaseRepository
    {
        public async Task<IEnumerable<Branch>> BranchList(bool isActive = true)
        {
            IEnumerable<Branch> BranchList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BranchList = await connection.QueryAsync<Branch>("GetBranchDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return BranchList;
        }

        public async Task<IEnumerable<int>> AddBranch(Branch branch)
        {
            IEnumerable<int> BranchList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CompanyId", branch.CompanyId);
            parameter.Add("@BranchName", branch.BranchName);
            parameter.Add("@BranchType", branch.BranchType);
            parameter.Add("@BranchVoucherNoPrefix", branch.BranchVoucherNoPrefix);
            parameter.Add("@Address", branch.Address);
            parameter.Add("@Mobile", branch.Mobile);
            parameter.Add("@OtherMobile", branch.OtherMobile);
            parameter.Add("@PhoneNo", branch.PhoneNo);
            parameter.Add("@CityId", branch.CityId);
            parameter.Add("@StateId", branch.StateId);
            parameter.Add("@GSTNo", branch.GSTNo);
            parameter.Add("@OutwardRateType", branch.OutwardRateType);
            parameter.Add("@FromCustCardNo", branch.FromCustCardNo);
            parameter.Add("@ToCustCardNo", branch.ToCustCardNo);
            parameter.Add("@BranchAccountId", branch.BranchAccountId);
            parameter.Add("@HOAccountId", branch.HOAccountId);
            parameter.Add("@AllowedBankAccountId", branch.AllowedBankAccountId);
            parameter.Add("@AllowedCardAccountId", branch.AllowedCardAccountId);
            parameter.Add("@AllowedBankDaybookId", branch.AllowedBankDaybookId);
            parameter.Add("@AllowedCompanyId", branch.AllowedCompanyId);
            parameter.Add("@StockOutwardAccountId", branch.StockOutwardAccountId);
            parameter.Add("@StockInwardAccountId", branch.StockInwardAccountId);
            parameter.Add("@TaxPayerTypeId", branch.TaxPayerTypeId);
            parameter.Add("@CreatedBy", branch.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BranchList = await connection.QueryAsync<int>("AddBranch",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BranchList;
        }

        public async Task<IEnumerable<int>> EditBranch(Branch branch)
        {
            IEnumerable<int> BranchList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@BranchId", branch.BranchId);
            parameter.Add("@CompanyId", branch.CompanyId);
            parameter.Add("@BranchName", branch.BranchName);
            parameter.Add("@BranchType", branch.BranchType);
            parameter.Add("@BranchVoucherNoPrefix", branch.BranchVoucherNoPrefix);
            parameter.Add("@Address", branch.Address);
            parameter.Add("@Mobile", branch.Mobile);
            parameter.Add("@OtherMobile", branch.OtherMobile);
            parameter.Add("@PhoneNo", branch.PhoneNo);
            parameter.Add("@CityId", branch.CityId);
            parameter.Add("@StateId", branch.StateId);
            parameter.Add("@GSTNo", branch.GSTNo);
            parameter.Add("@OutwardRateType", branch.OutwardRateType);
            parameter.Add("@FromCustCardNo", branch.FromCustCardNo);
            parameter.Add("@ToCustCardNo", branch.ToCustCardNo);
            parameter.Add("@BranchAccountId", branch.BranchAccountId);
            parameter.Add("@HOAccountId", branch.HOAccountId);
            parameter.Add("@AllowedBankAccountId", branch.AllowedBankAccountId);
            parameter.Add("@AllowedCardAccountId", branch.AllowedCardAccountId);
            parameter.Add("@AllowedBankDaybookId", branch.AllowedBankDaybookId);
            parameter.Add("@AllowedCompanyId", branch.AllowedCompanyId);
            parameter.Add("@StockOutwardAccountId", branch.StockOutwardAccountId);
            parameter.Add("@StockInwardAccountId", branch.StockInwardAccountId);
            parameter.Add("@TaxPayerTypeId", branch.TaxPayerTypeId);
            parameter.Add("@UpdatedBy", branch.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", branch.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BranchList = await connection.QueryAsync<int>("EditBranch",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BranchList;
        }

        public async Task<IEnumerable<int>> DeleteBranch(int branchId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> BranchList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@BranchId", branchId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BranchList = await connection.QueryAsync<int>("DeleteUnDeleteBranch",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BranchList;
        }
    }
}
