
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
    public class FinancialYearRepository : BaseRepository
    {
        public async Task<IEnumerable<FinancialYear>> FinancialYearList(bool isActive = true)
        {
            IEnumerable<FinancialYear> FinancialYearList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                FinancialYearList = await connection.QueryAsync<FinancialYear>("GetFinancialYearDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return FinancialYearList;
        }

        public async Task<IEnumerable<int>> AddFinancialYear(FinancialYear financialYear)
        {
            IEnumerable<int> FinancialYearList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OpeningDate", financialYear.OpeningDate);
            parameter.Add("@ClosingDate", financialYear.ClosingDate);
            parameter.Add("@YearCode", financialYear.YearCode);
            parameter.Add("@CreatedBy", financialYear.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                FinancialYearList = await connection.QueryAsync<int>("AddFinancialYear",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return FinancialYearList;
        }

        public async Task<IEnumerable<int>> EditFinancialYear(FinancialYear financialYear)
        {
            IEnumerable<int> FinancialYearList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@FinancialYearId", financialYear.FinancialYearId);
            parameter.Add("@OpeningDate", financialYear.OpeningDate);
            parameter.Add("@ClosingDate", financialYear.ClosingDate);
            parameter.Add("@YearCode", financialYear.YearCode);
            parameter.Add("@UpdatedBy", financialYear.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", financialYear.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                FinancialYearList = await connection.QueryAsync<int>("EditFinancialYear",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return FinancialYearList;
        }

        public async Task<IEnumerable<int>> DeleteFinancialYear(int financialYearId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> FinancialYearList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@FinancialYearId", financialYearId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                FinancialYearList = await connection.QueryAsync<int>("DeleteUnDeleteFinancialYear",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return FinancialYearList;
        }
    }
}
