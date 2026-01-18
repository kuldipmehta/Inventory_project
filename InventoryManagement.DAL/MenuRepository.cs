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
    public class MenuRepository : BaseRepository
    {
        public async Task<IEnumerable<Menu>> MenuList(bool IsActive = true)
        {
            IEnumerable<Menu> menuList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                menuList = await connection.QueryAsync<Menu>("GetMenuDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return menuList;
        }

        public async Task<IEnumerable<int>> AddMenu(Menu menu)
        {
            IEnumerable<int> menuList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@MenuName", menu.MenuName);
            parameter.Add("@DisplayName", menu.DisplayName);
            parameter.Add("@Type", menu.Type);
            parameter.Add("@Url", menu.Url);
            parameter.Add("@Icon", menu.Icon);
            parameter.Add("@ParentId", menu.ParentId);
            parameter.Add("@Permissions", menu.Permissions);
            parameter.Add("@CreatedBy", menu.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                menuList = await connection.QueryAsync<int>("AddMenu",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return menuList;
        }

        public async Task<IEnumerable<int>> EditMenu(Menu menu)
        {
            IEnumerable<int> menuList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@MenuId", menu.MenuId);
            parameter.Add("@MenuName", menu.MenuName);
            parameter.Add("@DisplayName", menu.DisplayName);
            parameter.Add("@Type", menu.Type);
            parameter.Add("@Url", menu.Url);
            parameter.Add("@Icon", menu.Icon);
            parameter.Add("@ParentId", menu.ParentId);
            parameter.Add("@Permissions", menu.Permissions);
            parameter.Add("@UpdatedBy", menu.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", menu.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output,size:100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                menuList = await connection.QueryAsync<int>("EditMenu",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return menuList;
        }

        public async Task<IEnumerable<int>> DeleteMenu(int menuId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> menuList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@MenuId", menuId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                menuList = await connection.QueryAsync<int>("DeleteUnDeleteMenu",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return menuList;
        }
    }
}
