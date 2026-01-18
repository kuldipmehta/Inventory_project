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
    public class ColorRepository : BaseRepository
    {
        public async Task<IEnumerable<Color>> ColorList(bool IsActive = true)
        {
            IEnumerable<Color> ColorList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ColorList = await connection.QueryAsync<Color>("GetColorDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return ColorList;
        }

        public async Task<IEnumerable<int>> AddColor(Color color)
        {
            IEnumerable<int> ColorList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ColorName", color.ColorName);
            parameter.Add("@SrNo", color.SrNo);
            parameter.Add("@CreatedBy", color.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ColorList = await connection.QueryAsync<int>("AddColor",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ColorList;
        }

        public async Task<IEnumerable<int>> EditColor(Color color)
        {
            IEnumerable<int> ColorList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ColorId", color.ColorId);
            parameter.Add("@ColorName", color.ColorName);
            parameter.Add("@SrNo", color.SrNo);
            parameter.Add("@UpdatedBy", color.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", color.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ColorList = await connection.QueryAsync<int>("EditColor",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ColorList;
        }

        public async Task<IEnumerable<int>> DeleteColor(int ColorId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> ColorList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ColorId", ColorId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ColorList = await connection.QueryAsync<int>("DeleteUnDeleteColor",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ColorList;
        }
    }
}
