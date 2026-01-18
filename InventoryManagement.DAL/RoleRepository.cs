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
    public class RoleRepository : BaseRepository
    {
        public async Task<IEnumerable<ApplicationRole>> RoleList(bool IsActive = true)
        {
            IEnumerable<ApplicationRole> roleList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<ApplicationRole>("GetRoleDetails",
                                                                        new { IsActive },
                                                                        commandType: CommandType.StoredProcedure);
            }
            return roleList;
        }


        public async Task<IEnumerable<RolePermissions>> RolePermissionList(int roleId)
        {
            IEnumerable<RolePermissions> roleList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<RolePermissions>("GetRolePermisstionDetails",
                                                                        new { roleId },
                                                                        commandType: CommandType.StoredProcedure);
            }
            return roleList;
        }

        public async Task<IEnumerable<int>> SaveRolePermissionList(List<RolePermissionType> rolePermissionTypes, int roleId)
        {
            IEnumerable<int> roleList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MenuId", typeof(int));
            dataTable.Columns.Add("PermissionId", typeof(int));
            dataTable.Columns.Add("HasPermission", typeof(bool));
            foreach (var item in rolePermissionTypes)
            {
                dataTable.Rows.Add(item.MenuId, item.PermissionId, item.HasPermission);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@RoleId", roleId);
            parameter.Add("@RolePermissionType", dataTable.AsTableValuedParameter("[dbo].[RolePermissionType]"));
            //parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<int>("MergeRolePermissions",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return roleList;
        }

        public async Task<IEnumerable<int>> AddRole(ApplicationRole role)
        {
            IEnumerable<int> roleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Name", role.Name);
            parameter.Add("@CreatedBy", role.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<int>("AddRole",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return roleList;
        }

        public async Task<IEnumerable<int>> EditRole(ApplicationRole role)
        {
            IEnumerable<int> roleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", role.Id);
            parameter.Add("@Name", role.Name);
            parameter.Add("@UpdatedBy", role.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", role.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<int>("EditRole",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return roleList;
        }

        public async Task<IEnumerable<int>> DeleteRole(int roleId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> roleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", roleId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                roleList = await connection.QueryAsync<int>("DeleteUnDeleteRole",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return roleList;
        }
    }
}
