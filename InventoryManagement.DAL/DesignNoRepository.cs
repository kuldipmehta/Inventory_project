
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
    public class DesignNoRepository : BaseRepository
    {
        public async Task<IEnumerable<DesignNos>> DesignNoList(bool isActive = true)
        {
            IEnumerable<DesignNos> DesignNoList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DesignNoList = await connection.QueryAsync<DesignNos>("GetDesignNoDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return DesignNoList;
        }

        public async Task<IEnumerable<int>> AddDesignNo(DesignNos designNo)
        {
            IEnumerable<int> DesignNoList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CompanyId", designNo.CompanyId);
            parameter.Add("@BranchId", designNo.BranchId);
            parameter.Add("@DesignNo", designNo.DesignNo);
            parameter.Add("@ItemId", designNo.ItemId);
            parameter.Add("@PurchaseRate", designNo.PurchaseRate);
            parameter.Add("@SalesRate", designNo.SalesRate);
            parameter.Add("@MRP", designNo.Mrp);
            parameter.Add("@WhSalesRate", designNo.WhSalesRate);
            parameter.Add("@WhSalesRate2", designNo.WhSalesRate2);
            parameter.Add("@MinStockQty", designNo.MinStockQty);
            parameter.Add("@MaxStockQty", designNo.MaxStockQty);
            parameter.Add("@Remarks", designNo.Remarks);
            parameter.Add("@CreatedBy", designNo.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DesignNoList = await connection.QueryAsync<int>("AddDesignNo",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DesignNoList;
        }

        public async Task<IEnumerable<int>> EditDesignNo(DesignNos designNo)
        {
            IEnumerable<int> DesignNoList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@DesignNoId", designNo.DesignNoId);
            parameter.Add("@CompanyId",designNo.CompanyId);
            parameter.Add("@BranchId",designNo.BranchId );
            parameter.Add("@DesignNo",designNo.DesignNo);
            parameter.Add("@ItemId",designNo.ItemId);
            parameter.Add("@PurchaseRate",designNo.PurchaseRate);
            parameter.Add("@SalesRate",designNo.SalesRate);
            parameter.Add("@MRP",designNo.Mrp);
            parameter.Add("@WhSalesRate",designNo.WhSalesRate);
            parameter.Add("@WhSalesRate2",designNo.WhSalesRate2);
            parameter.Add("@MinStockQty",designNo.MinStockQty);
            parameter.Add("@MaxStockQty",designNo.MaxStockQty);
            parameter.Add("@Remarks", designNo.Remarks);
            parameter.Add("@UpdatedBy", designNo.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", designNo.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DesignNoList = await connection.QueryAsync<int>("EditDesignNo",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DesignNoList;
        }

        public async Task<IEnumerable<int>> DeleteDesignNo(int designNoId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> DesignNoList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@DesignNoId", designNoId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DesignNoList = await connection.QueryAsync<int>("DeleteUnDeleteDesignNo",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DesignNoList;
        }
    }
}
