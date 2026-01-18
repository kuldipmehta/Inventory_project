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
    public class AccountGroupRepository : BaseRepository
    {
        public async Task<IEnumerable<AccountGroup>> AccountGroupList(bool isActive = true)
        {
            IEnumerable<AccountGroup> AccountGroupList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountGroupList = await connection.QueryAsync<AccountGroup>("GetAccountGroupDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return AccountGroupList;
        }

        public async Task<IEnumerable<int>> AddAccountGroup(AccountGroup accountGroup)
        {
            IEnumerable<int> AccountGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@GroupIdManual", accountGroup.GroupIdManual);
            parameter.Add("@GroupName",accountGroup.GroupName);
            parameter.Add("@GroupTypeId",accountGroup.GroupTypeId);
            parameter.Add("@AccountTransferToBranch",accountGroup.AccountTransferdToBranch);
            parameter.Add("@CreatedBy", accountGroup.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountGroupList = await connection.QueryAsync<int>("AddAccountGroup",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountGroupList;
        }

        public async Task<IEnumerable<AccountGroupType>> AccountGroupTypeList(bool isActive = true)
        {
            IEnumerable<AccountGroupType> AccountGroupTypeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountGroupTypeList = await connection.QueryAsync<AccountGroupType>("GetAccountGroupTypeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return AccountGroupTypeList;
        }

        public async Task<IEnumerable<int>> EditAccountGroup(AccountGroup accountGroup)
        {
            IEnumerable<int> AccountGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@GroupId", accountGroup.GroupId);
            parameter.Add("@GroupIdManual", accountGroup.GroupIdManual);
            parameter.Add("@GroupName", accountGroup.GroupName);
            parameter.Add("@GroupTypeId", accountGroup.GroupTypeId);
            parameter.Add("@AccountTransferToBranch", accountGroup.AccountTransferdToBranch);
            parameter.Add("@UpdatedBy", accountGroup.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", accountGroup.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountGroupList = await connection.QueryAsync<int>("EditAccountGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountGroupList;
        }

        public async Task<IEnumerable<int>> DeleteAccountGroup(int accountGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> AccountGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@GroupId", accountGroupId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                AccountGroupList = await connection.QueryAsync<int>("DeleteUnDeleteAccountGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return AccountGroupList;
        }
    }
}
