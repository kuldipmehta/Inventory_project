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
    public class TaxRepository : BaseRepository
    {
        public async Task<IEnumerable<Tax>> TaxList(bool isActive = true)
        {
            IEnumerable<Tax> TaxList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TaxList = await connection.QueryAsync<Tax>("GetTaxDetails",
                                                            new { isActive },
                                                            commandType: CommandType.StoredProcedure);
            }
            return TaxList;
        }

        public async Task<IEnumerable<TaxType>> TaxTypeList(bool isActive = true)
        {
            IEnumerable<TaxType> taxTypeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                taxTypeList = await connection.QueryAsync<TaxType>("GetTaxTypeDetails",
                                                                   new { isActive },
                                                                   commandType: CommandType.StoredProcedure);
            }
            return taxTypeList;
        }



        public async Task<IEnumerable<int>> AddTax(Tax tax)
        {
            IEnumerable<int> TaxList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@TaxTypeId", tax.TaxTypeId);
            parameter.Add("@TaxName", tax.TaxName);
            parameter.Add("@SGSTPrc", tax.SGSTPrc);
            parameter.Add("@CGSTPrc", tax.CGSTPrc);
            parameter.Add("@IGSTPrc", tax.IGSTPrc);
            parameter.Add("@SurchargePrc", tax.SurchargePrc);
            parameter.Add("@CompanyId", tax.CompanyId);
            parameter.Add("@SGSTInPutAccountId", tax.SGSTInPutAccountId);
            parameter.Add("@CGSTInPutAccountId", tax.CGSTInPutAccountId);
            parameter.Add("@IGSTInPutAccountId", tax.IGSTInPutAccountId);
            parameter.Add("@SGSTOutPutAccountId", tax.SGSTOutPutAccountId);
            parameter.Add("@CGSTOutPutAccountId", tax.CGSTOutPutAccountId);
            parameter.Add("@IGSTOutPutAccountId", tax.IGSTOutPutAccountId);
            parameter.Add("@SGSTPayableAccountId", tax.SGSTPayableAccountId);
            parameter.Add("@CGSTPayableAccountId", tax.CGSTPayableAccountId);
            parameter.Add("@IGSTPayableAccountId", tax.IGSTPayableAccountId);
            parameter.Add("@RCMSGSTPayableAccountId", tax.RCMSGSTPayableAccountId);
            parameter.Add("@RCMCGSTPayableAccountId", tax.RCMCGSTPayableAccountId);
            parameter.Add("@RCMIGSTPayableAccountId", tax.RCMIGSTPayableAccountId);
            parameter.Add("@RCMInPutSGSTAccountId", tax.RCMInPutSGSTAccountId);
            parameter.Add("@RCMInPutCGSTAccountId", tax.RCMInPutCGSTAccountId);
            parameter.Add("@RCMInPutIGSTAccountId", tax.RCMInPutIGSTAccountId);
            parameter.Add("@RCMOutPutSGSTAccountId", tax.RCMOutPutSGSTAccountId);
            parameter.Add("@RCMOutPutCGSTAccountId", tax.RCMOutPutCGSTAccountId);
            parameter.Add("@RCMOutPutIGSTAccountId", tax.RCMOutPutIGSTAccountId);
            parameter.Add("@CreatedBy", tax.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TaxList = await connection.QueryAsync<int>("AddTax",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return TaxList;
        }

        public async Task<IEnumerable<int>> EditTax(Tax tax)
        {
            IEnumerable<int> TaxList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@TaxId", tax.TaxId);
            parameter.Add("@TaxTypeId", tax.TaxTypeId);
            parameter.Add("@TaxName", tax.TaxName);
            parameter.Add("@SGSTPrc", tax.SGSTPrc);
            parameter.Add("@CGSTPrc", tax.CGSTPrc);
            parameter.Add("@IGSTPrc", tax.IGSTPrc);
            parameter.Add("@SurchargePrc", tax.SurchargePrc);
            parameter.Add("@CompanyId", tax.CompanyId);
            parameter.Add("@SGSTInPutAccountId", tax.SGSTInPutAccountId);
            parameter.Add("@CGSTInPutAccountId", tax.CGSTInPutAccountId);
            parameter.Add("@IGSTInPutAccountId", tax.IGSTInPutAccountId);
            parameter.Add("@SGSTOutPutAccountId", tax.SGSTOutPutAccountId);
            parameter.Add("@CGSTOutPutAccountId", tax.CGSTOutPutAccountId);
            parameter.Add("@IGSTOutPutAccountId", tax.IGSTOutPutAccountId);
            parameter.Add("@SGSTPayableAccountId", tax.SGSTPayableAccountId);
            parameter.Add("@CGSTPayableAccountId", tax.CGSTPayableAccountId);
            parameter.Add("@IGSTPayableAccountId", tax.IGSTPayableAccountId);
            parameter.Add("@RCMSGSTPayableAccountId", tax.RCMSGSTPayableAccountId);
            parameter.Add("@RCMCGSTPayableAccountId", tax.RCMCGSTPayableAccountId);
            parameter.Add("@RCMIGSTPayableAccountId", tax.RCMIGSTPayableAccountId);
            parameter.Add("@RCMInPutSGSTAccountId", tax.RCMInPutSGSTAccountId);
            parameter.Add("@RCMInPutCGSTAccountId", tax.RCMInPutCGSTAccountId);
            parameter.Add("@RCMInPutIGSTAccountId", tax.RCMInPutIGSTAccountId);
            parameter.Add("@RCMOutPutSGSTAccountId", tax.RCMOutPutSGSTAccountId);
            parameter.Add("@RCMOutPutCGSTAccountId", tax.RCMOutPutCGSTAccountId);
            parameter.Add("@RCMOutPutIGSTAccountId", tax.RCMOutPutIGSTAccountId);
            parameter.Add("@UpdatedBy", tax.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", tax.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TaxList = await connection.QueryAsync<int>("EditTax",
                                                           parameter,
                                                           commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return TaxList;
        }

        public async Task<IEnumerable<int>> DeleteTax(int taxId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> TaxList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@TaxId", taxId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                TaxList = await connection.QueryAsync<int>("DeleteUnDeleteTax",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return TaxList;
        }
    }
}
