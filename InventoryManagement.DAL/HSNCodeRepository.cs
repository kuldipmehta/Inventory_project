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
    public class HSNCodeRepository : BaseRepository
    {
        public async Task<IEnumerable<HSNCode>> HSNCodeList(bool isActive = true)
        {
            IEnumerable<HSNCode> HSNCodeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                HSNCodeList = await connection.QueryAsync<HSNCode>("GetHSNCodeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return HSNCodeList;
        }

        public async Task<IEnumerable<HSNTax>> GetHSNTaxDetailsByHSNCodeId(int hsnCodeId)
        {
            IEnumerable<HSNTax> hsnTaxList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                hsnTaxList = await connection.QueryAsync<HSNTax>("GetHSNTaxDetailsByHSNCodeId",
                                                              new { hsnCodeId },
                                                              commandType: CommandType.StoredProcedure);
            }
            return hsnTaxList;
        }


        public async Task<IEnumerable<int>> AddHSNCode(HSNCode hsnCode)
        {
            IEnumerable<int> HSNCodeList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TaxId", typeof(int));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("ToDate", typeof(DateTime));
            dataTable.Columns.Add("FromRate", typeof(float));
            dataTable.Columns.Add("ToRate", typeof(float));
            dataTable.Columns.Add("FromPurcRate", typeof(float));
            dataTable.Columns.Add("ToPurcRate", typeof(float));
            foreach (var item in hsnCode.HSNTaxes)
            {
                dataTable.Rows.Add(item.TaxId, item.FromDate, item.ToDate, item.FromRate, item.ToRate, item.FromPurcRate, item.ToPurcRate);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@HSNCode", hsnCode.HsnCode);
            parameter.Add("@HSNDetail", hsnCode.HSNDetail);
            parameter.Add("@CreatedBy", hsnCode.CreatedBy);
            parameter.Add("@HSNTaxType", dataTable.AsTableValuedParameter("[dbo].[HSNTaxType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                HSNCodeList = await connection.QueryAsync<int>("AddHSNCode",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return HSNCodeList;
        }

        public async Task<IEnumerable<int>> EditHSNCode(HSNCode hsnCode)
        {
            IEnumerable<int> HSNCodeList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TaxId", typeof(int));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("ToDate", typeof(DateTime));
            dataTable.Columns.Add("FromRate", typeof(float));
            dataTable.Columns.Add("ToRate", typeof(float));
            dataTable.Columns.Add("FromPurcRate", typeof(float));
            dataTable.Columns.Add("ToPurcRate", typeof(float));
            foreach (var item in hsnCode.HSNTaxes)
            {
                dataTable.Rows.Add(item.TaxId, item.FromDate, item.ToDate, item.FromRate, item.ToRate, item.FromPurcRate, item.ToPurcRate);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@HSNCodeId", hsnCode.HSNCodeId);
            parameter.Add("@HSNCode", hsnCode.HsnCode);
            parameter.Add("@HSNDetail", hsnCode.HSNDetail);
            parameter.Add("@UpdatedBy", hsnCode.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", hsnCode.ChangeTimeStamp);
            parameter.Add("@HSNTaxType", dataTable.AsTableValuedParameter("[dbo].[HSNTaxType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                HSNCodeList = await connection.QueryAsync<int>("EditHSNCode",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return HSNCodeList;
        }

        public async Task<IEnumerable<int>> DeleteHSNCode(int hsnCodeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> HSNCodeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@HSNCodeId", hsnCodeId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                HSNCodeList = await connection.QueryAsync<int>("DeleteUnDeleteHSNCode",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return HSNCodeList;
        }
    }
}
