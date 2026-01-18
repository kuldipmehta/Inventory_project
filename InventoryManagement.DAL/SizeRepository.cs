
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
    public class SizeRepository : BaseRepository
    {
        public async Task<IEnumerable<Size>> SizeList(bool isActive = true)
        {
            IEnumerable<Size> SizeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeList = await connection.QueryAsync<Size>("GetSizeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return SizeList;
        }

        public async Task<IEnumerable<SizeCountry>> GetSizeCountyDetailsById(int sizeId)
        {
            IEnumerable<SizeCountry> sizeCountryList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                sizeCountryList = await connection.QueryAsync<SizeCountry>("GetSizeCountyDetailsById",
                                                                            new { sizeId },
                                                                            commandType: CommandType.StoredProcedure);
            }
            return sizeCountryList;
        }

        public async Task<IEnumerable<int>> AddSize(Size size)
        {
            IEnumerable<int> SizeList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeDepartmentId", typeof(int));
            dataTable.Columns.Add("USSizeShortName", typeof(string));
            dataTable.Columns.Add("EuropSizeShortName", typeof(string));
            dataTable.Columns.Add("LengthCM", typeof(float));
            dataTable.Columns.Add("LengthInch", typeof(float));
            //dataTable.Columns.Add("ChangeTimeStamp", typeof(byte[]));
            foreach (var item in size.SizeCountryList)
            {
                dataTable.Rows.Add(item.DepartmentId, item.USSizeShortName, item.EuropSizeShortName, item.LengthCM, item.LengthInch);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@SizeName", size.SizeName);
            parameter.Add("@ShortName", size.ShortName);
            parameter.Add("@SrNo", size.SrNo);
            parameter.Add("@SizeCountryType", dataTable.AsTableValuedParameter("[dbo].[SizeCountryType]"));
            parameter.Add("@CreatedBy", size.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeList = await connection.QueryAsync<int>("AddSize",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeList;
        }


        public async Task<IEnumerable<int>> EditSize(Size size)
        {
            IEnumerable<int> SizeList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeDepartmentId", typeof(int));
            dataTable.Columns.Add("USSizeShortName", typeof(string));
            dataTable.Columns.Add("EuropSizeShortName", typeof(string));
            dataTable.Columns.Add("LengthCM", typeof(float));
            dataTable.Columns.Add("LengthInch", typeof(float));
            foreach (var item in size.SizeCountryList)
            {
                dataTable.Rows.Add(item.DepartmentId, item.USSizeShortName, item.EuropSizeShortName, item.LengthCM, item.LengthInch);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeId", size.SizeId);
            parameter.Add("@SizeName", size.SizeName);
            parameter.Add("@ShortName", size.ShortName);
            parameter.Add("@SrNo", size.SrNo);
            parameter.Add("@SizeCountryType", dataTable.AsTableValuedParameter("[dbo].[SizeCountryType]"));
            parameter.Add("@UpdatedBy", size.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", size.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeList = await connection.QueryAsync<int>("EditSize",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeList;
        }

        public async Task<IEnumerable<int>> DeleteSize(int sizeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> SizeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeId", sizeId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeList = await connection.QueryAsync<int>("DeleteUnDeleteSize",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeList;
        }
    }
}
