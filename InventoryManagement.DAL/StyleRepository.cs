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
    public class StyleRepository : BaseRepository
    {
        public async Task<IEnumerable<Style>> StyleList(bool IsActive = true)
        {
            IEnumerable<Style> StyleList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StyleList = await connection.QueryAsync<Style>("GetStyleDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return StyleList;
        }

        public async Task<IEnumerable<int>> AddStyle(Style style)
        {
            IEnumerable<int> StyleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@StyleName", style.StyleName);
            parameter.Add("@ShortName", style.ShortName);
            parameter.Add("@CreatedBy", style.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StyleList = await connection.QueryAsync<int>("AddStyle",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StyleList;
        }

        public async Task<IEnumerable<int>> EditStyle(Style style)
        {
            IEnumerable<int> StyleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@StyleId", style.StyleId);
            parameter.Add("@StyleName", style.StyleName);
            parameter.Add("@ShortName", style.ShortName);
            parameter.Add("@UpdatedBy", style.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", style.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StyleList = await connection.QueryAsync<int>("EditStyle",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StyleList;
        }

        public async Task<IEnumerable<int>> DeleteStyle(int StyleId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> StyleList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@StyleId", StyleId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StyleList = await connection.QueryAsync<int>("DeleteUnDeleteStyle",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StyleList;
        }
    }
}
