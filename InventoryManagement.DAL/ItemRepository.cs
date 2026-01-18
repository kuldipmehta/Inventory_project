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
    public class ItemRepository : BaseRepository
    {
        public async Task<IEnumerable<Item>> ItemList(bool isActive = true)
        {
            IEnumerable<Item> ItemList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemList = await connection.QueryAsync<Item>("GetItemDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return ItemList;
        }

        public async Task<IEnumerable<int>> AddItem(Item item)
        {
            IEnumerable<int> ItemList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CompanyId", item.CompanyId);
            parameter.Add("@BranchId", item.BranchId);
            parameter.Add("@DepartmentId", item.DepartmentId);
            parameter.Add("@BrandId", item.BrandId);
            parameter.Add("@ProductId", item.ProductId);
            parameter.Add("@StyleId", item.StyleId);
            parameter.Add("@GroupId", item.GroupId);
            parameter.Add("@ItemName", item.ItemName);
            parameter.Add("@ShortName", item.ShortName);
            parameter.Add("@BarcodeType", item.BarcodeType);
            parameter.Add("@ItemShortcut", item.ItemShortcut);
            parameter.Add("@DefaultQty", item.DefaultQty);
            parameter.Add("@HSNCode", item.HsnCode);
            parameter.Add("@DayBookType", item.DayBookType);
            parameter.Add("@ItemWiseMargin", item.ItemWiseMargin);
            parameter.Add("@CreatedBy", item.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemList = await connection.QueryAsync<int>("AddItem",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemList;
        }

        public async Task<IEnumerable<int>> EditItem(Item item)
        {
            IEnumerable<int> ItemList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ItemId", item.ItemId);
            parameter.Add("@CompanyId", item.CompanyId);
            parameter.Add("@BranchId", item.BranchId);
            parameter.Add("@DepartmentId", item.DepartmentId);
            parameter.Add("@BrandId", item.BrandId);
            parameter.Add("@ProductId", item.ProductId);
            parameter.Add("@StyleId", item.StyleId);
            parameter.Add("@GroupId", item.GroupId);
            parameter.Add("@ItemName", item.ItemName);
            parameter.Add("@ShortName", item.ShortName);
            parameter.Add("@BarcodeType", item.BarcodeType);
            parameter.Add("@ItemShortcut", item.ItemShortcut);
            parameter.Add("@DefaultQty", item.DefaultQty);
            parameter.Add("@HSNCode", item.HsnCode);
            parameter.Add("@DayBookType", item.DayBookType);
            parameter.Add("@ItemWiseMargin", item.ItemWiseMargin);
            parameter.Add("@UpdatedBy", item.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", item.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemList = await connection.QueryAsync<int>("EditItem",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemList;
        }

        public async Task<IEnumerable<int>> DeleteItem(int itemId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> ItemList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ItemId", itemId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ItemList = await connection.QueryAsync<int>("DeleteUnDeleteItem",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ItemList;
        }
    }
}
