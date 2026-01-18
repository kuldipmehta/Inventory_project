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
    public class ItemGroupRepository : BaseRepository
    {
        public async Task<IEnumerable<ItemGroup>> ItemGroupList(bool IsActive = true)
        {
            IEnumerable<ItemGroup> ItemGroupList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemGroupList = await connection.QueryAsync<ItemGroup>("GetItemGroupDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return ItemGroupList;
        }

        public async Task<IEnumerable<int>> AddItemGroup(ItemGroup itemGroup)
        {
            IEnumerable<int> ItemGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ItemGroupName", itemGroup.ItemGroupName);
            parameter.Add("@CreatedBy", itemGroup.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemGroupList = await connection.QueryAsync<int>("AddItemGroup",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemGroupList;
        }

        public async Task<IEnumerable<int>> EditItemGroup(ItemGroup itemGroup)
        {
            IEnumerable<int> ItemGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ItemGroupId", itemGroup.ItemGroupId);
            parameter.Add("@ItemGroupName", itemGroup.ItemGroupName);
            parameter.Add("@UpdatedBy", itemGroup.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", itemGroup.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemGroupList = await connection.QueryAsync<int>("EditItemGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemGroupList;
        }

        public async Task<IEnumerable<int>> DeleteItemGroup(int ItemGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> ItemGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ItemGroupId", ItemGroupId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemGroupList = await connection.QueryAsync<int>("DeleteUnDeleteItemGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemGroupList;
        }
    }
}
