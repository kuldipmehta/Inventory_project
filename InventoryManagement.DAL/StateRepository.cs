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
    public class StateRepository : BaseRepository
    {
        public async Task<IEnumerable<State>> StateList(bool isActive = true)
        {
            IEnumerable<State> StateList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StateList = await connection.QueryAsync<State>("GetStateDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return StateList;
        }

        public async Task<IEnumerable<int>> AddState(State state)
        {
            IEnumerable<int> StateList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@StateName", state.StateName);
            parameter.Add("@StateCode", state.StateCode);
            parameter.Add("@CountryId", state.CountryId);
            parameter.Add("@CreatedBy", state.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StateList = await connection.QueryAsync<int>("AddState",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StateList;
        }

        public async Task<IEnumerable<int>> EditState(State state)
        {
            IEnumerable<int> StateList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@StateId", state.StateId);
            parameter.Add("@StateName", state.StateName);
            parameter.Add("@StateCode", state.StateCode);
            parameter.Add("@CountryId", state.CountryId);
            parameter.Add("@UpdatedBy", state.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", state.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StateList = await connection.QueryAsync<int>("EditState",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StateList;
        }

        public async Task<IEnumerable<int>> DeleteState(int stateId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> StateList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@StateId", stateId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                StateList = await connection.QueryAsync<int>("DeleteUnDeleteState",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return StateList;
        }
    }
}
