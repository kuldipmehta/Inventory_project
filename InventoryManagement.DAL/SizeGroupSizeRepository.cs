
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
    public class SizeGroupSizeRepository : BaseRepository
    {
        public async Task<IEnumerable<SizeGroupSize>> SizeGroupSizeList(bool isActive = true)
        {
            IEnumerable<SizeGroupSize> SizeGroupSizeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupSizeList = await connection.QueryAsync<SizeGroupSize>("GetSizeGroupSizeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return SizeGroupSizeList;
        }

        public async Task<IEnumerable<int>> AddSizeGroupSize(SizeGroupSize sizeGroupSize)
        {
            IEnumerable<int> SizeGroupSizeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@SizeGroupId", sizeGroupSize.SizeGroupId);
            parameter.Add("@SizeShortName", sizeGroupSize.SizeShortName);
            parameter.Add("@SrNo", sizeGroupSize.SrNo);
            parameter.Add("@CreatedBy", sizeGroupSize.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupSizeList = await connection.QueryAsync<int>("AddSizeGroupSize",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupSizeList;
        }

        public async Task<IEnumerable<int>> EditSizeGroupSize(SizeGroupSize sizeGroupSize)
        {
            IEnumerable<int> SizeGroupSizeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeGroupSizeId", sizeGroupSize.SizeGroupSizeId);
            parameter.Add("@SizeGroupId", sizeGroupSize.SizeGroupId);
            parameter.Add("@SizeShortName", sizeGroupSize.SizeShortName);
            parameter.Add("@SrNo", sizeGroupSize.SrNo);
            parameter.Add("@UpdatedBy", sizeGroupSize.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", sizeGroupSize.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupSizeList = await connection.QueryAsync<int>("EditSizeGroupSize",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupSizeList;
        }

        public async Task<IEnumerable<int>> DeleteSizeGroupSize(int sizeGroupSizeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> SizeGroupSizeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeGroupSizeId", sizeGroupSizeId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupSizeList = await connection.QueryAsync<int>("DeleteUnDeleteSizeGroupSize",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupSizeList;
        }
    }
}
