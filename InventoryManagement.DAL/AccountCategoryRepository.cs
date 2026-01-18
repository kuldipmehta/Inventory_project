
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
    public class AccountCategoryRepository : BaseRepository
    {
        public async Task<IEnumerable<AccountCategory>> AccountCategoryList(bool isActive = true)
        {
            IEnumerable<AccountCategory> AccountCategoryList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountCategoryList = await connection.QueryAsync<AccountCategory>("GetAccountCategoryDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return AccountCategoryList;
        }

        public async Task<IEnumerable<int>> AddAccountCategory(AccountCategory accountCategory)
        {
            IEnumerable<int> AccountCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CategoryName", accountCategory.CategoryName);
            parameter.Add("@ShortCode", accountCategory.ShortCode);
            parameter.Add("@CreatedBy", accountCategory.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountCategoryList = await connection.QueryAsync<int>("AddAccountCategory",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountCategoryList;
        }

        public async Task<IEnumerable<int>> EditAccountCategory(AccountCategory accountCategory)
        {
            IEnumerable<int> AccountCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@AccountCategoryId", accountCategory.AccountCategoryId);
            parameter.Add("@CategoryName", accountCategory.CategoryName);
            parameter.Add("@ShortCode", accountCategory.ShortCode);
            parameter.Add("@UpdatedBy", accountCategory.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", accountCategory.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountCategoryList = await connection.QueryAsync<int>("EditAccountCategory",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountCategoryList;
        }

        public async Task<IEnumerable<int>> DeleteAccountCategory(int accountCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> AccountCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@AccountCategoryId", accountCategoryId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountCategoryList = await connection.QueryAsync<int>("DeleteUnDeleteAccountCategory",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountCategoryList;
        }
    }
}
