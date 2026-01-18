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
    public class PermissionRepository : BaseRepository
    {
        public async Task<IEnumerable<Permission>> PermissionList(bool IsActive = true)
        {
            IEnumerable<Permission> permissionList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                permissionList = await connection.QueryAsync<Permission>("GetPermissionDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return permissionList;
        }

        public async Task<IEnumerable<int>> AddPermission(Permission permission)
        {
            IEnumerable<int> permissionList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@PermissionName", permission.PermissionName);
            parameter.Add("@CreatedBy", permission.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                permissionList = await connection.QueryAsync<int>("AddPermission",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return permissionList;
        }

        public async Task<IEnumerable<int>> EditPermission(Permission permission)
        {
            IEnumerable<int> permissionList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@PermissionId", permission.PermissionId);
            parameter.Add("@PermissionName", permission.PermissionName);
            parameter.Add("@UpdatedBy", permission.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", permission.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output,size:100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                permissionList = await connection.QueryAsync<int>("EditPermission",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return permissionList;
        }

        public async Task<IEnumerable<int>> DeletePermission(int permissionId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> permissionList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@PermissionId", permissionId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                permissionList = await connection.QueryAsync<int>("DeleteUnDeletePermission",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return permissionList;
        }
    }
}
