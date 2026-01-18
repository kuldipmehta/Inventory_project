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
    public class ProductRepository : BaseRepository
    {
        public async Task<IEnumerable<Product>> ProductList(bool isActive = true)
        {
            IEnumerable<Product> ProductList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ProductList = await connection.QueryAsync<Product>("GetProductDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return ProductList;
        }

        public async Task<IEnumerable<int>> AddProduct(Product product)
        {
            IEnumerable<int> ProductList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeShortName", typeof(string));
            dataTable.Columns.Add("SrNo", typeof(int));
            //dataTable.Columns.Add("ChangeTimeStamp", typeof(byte[]));
            foreach (var item in product.ProductList)
            {
                dataTable.Rows.Add(item.SizeShortName, item.SrNo);
            }

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ProductName", product.ProductName);
            parameter.Add("@ShortName", product.ShortName);
            parameter.Add("@SizeGroupId", product.SizeGroupId);
            parameter.Add("@MeasurementTypeId", product.MeasurementTypeId);
            parameter.Add("@CreatedBy", product.CreatedBy);
            parameter.Add("@ProductSizeType", dataTable.AsTableValuedParameter("[dbo].[ProductSizeType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ProductList = await connection.QueryAsync<int>("AddProduct",
                                                               parameter,
                                                               commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ProductList;
        }

        public async Task<IEnumerable<int>> EditProduct(Product product)
        {
            IEnumerable<int> ProductList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SizeShortName", typeof(string));
            dataTable.Columns.Add("SrNo", typeof(int));
            //dataTable.Columns.Add("ChangeTimeStamp", typeof(byte[]));
            foreach (var item in product.ProductList)
            {
                dataTable.Rows.Add(item.SizeShortName, item.SrNo);
            }


            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ProductId", product.ProductId);
            parameter.Add("@ProductName", product.ProductName);
            parameter.Add("@ShortName", product.ShortName);
            parameter.Add("@SizeGroupId", product.SizeGroupId);
            parameter.Add("@MeasurementTypeId", product.MeasurementTypeId);
            parameter.Add("@UpdatedBy", product.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", product.ChangeTimeStamp);
            parameter.Add("@ProductSizeType", dataTable.AsTableValuedParameter("[dbo].[ProductSizeType]"));
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ProductList = await connection.QueryAsync<int>("EditProduct",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ProductList;
        }

        public async Task<IEnumerable<int>> DeleteProduct(int productId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> ProductList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@ProductId", productId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                ProductList = await connection.QueryAsync<int>("DeleteUnDeleteProduct",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return ProductList;
        }
    }
}
