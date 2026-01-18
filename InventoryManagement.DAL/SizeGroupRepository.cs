
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
    public class SizeGroupRepository : BaseRepository
    {
        public async Task<IEnumerable<SizeGroup>> SizeGroupList(bool isActive = true)
        {
            IEnumerable<SizeGroup> SizeGroupList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupList = await connection.QueryAsync<SizeGroup>("GetSizeGroupDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return SizeGroupList;
        }

        public async Task<IEnumerable<int>> AddSizeGroup(SizeGroup sizeGroup)
        {
            IEnumerable<int> SizeGroupList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeShortName", typeof(string));
            dataTable.Columns.Add("SrNo", typeof(int));
            //dataTable.Columns.Add("ChangeTimeStamp", typeof(byte[]));
            foreach (var item in sizeGroup.SizeList)
            {
                dataTable.Rows.Add(item.SizeShortName, item.SrNo);
            }
            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@SizeGroupName", sizeGroup.SizeGroupName);
            parameter.Add("@CreatedBy", sizeGroup.CreatedBy);
            parameter.Add("@SizeGroupSizeType", dataTable.AsTableValuedParameter("[dbo].[SizeGroupSizeType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupList = await connection.QueryAsync<int>("AddSizeGroup",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupList;
        }

        public async Task<IEnumerable<int>> EditSizeGroup(SizeGroup sizeGroup)
        {
            IEnumerable<int> SizeGroupList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeShortName", typeof(string));
            dataTable.Columns.Add("SrNo", typeof(int));
            //dataTable.Columns.Add("ChangeTimeStamp", typeof(byte[]));
            foreach (var item in sizeGroup.SizeList)
            {
                dataTable.Rows.Add(item.SizeShortName, item.SrNo);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeGroupId", sizeGroup.SizeGroupId);
            parameter.Add("@SizeGroupName", sizeGroup.SizeGroupName);
            parameter.Add("@UpdatedBy", sizeGroup.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", sizeGroup.ChangeTimeStamp);
            parameter.Add("@SizeGroupSizeType", dataTable.AsTableValuedParameter("[dbo].[SizeGroupSizeType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupList = await connection.QueryAsync<int>("EditSizeGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupList;
        }

        public async Task<IEnumerable<int>> DeleteSizeGroup(int sizeGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> SizeGroupList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@SizeGroupId", sizeGroupId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SizeGroupList = await connection.QueryAsync<int>("DeleteUnDeleteSizeGroup",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return SizeGroupList;
        }
    }
}
