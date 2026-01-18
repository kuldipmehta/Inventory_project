
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
    public class TermsNConditionRepository : BaseRepository
    {
        

        public async Task<IEnumerable<int>> AddTermsNCondition(TermsNCondition termsNCondition)
        {
            IEnumerable<int> TermsNConditionList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CreatedBy", termsNCondition.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TermsNConditionList = await connection.QueryAsync<int>("AddAccountCategory",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return TermsNConditionList;
        }

        public async Task<IEnumerable<int>> EditTermsNCondition(TermsNCondition termsNCondition)
        {
            IEnumerable<int> TermsNConditionList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@UpdatedBy", termsNCondition.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", termsNCondition.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TermsNConditionList = await connection.QueryAsync<int>("EditAccountCategory",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return TermsNConditionList;
        }
        public async Task<IEnumerable<Branch>> BranchList(bool isActive = true)
        {
            IEnumerable<Branch> BranchList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BranchList = await connection.QueryAsync<Branch>("GetAccountGroupTypeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return BranchList;
        }



    }
}
