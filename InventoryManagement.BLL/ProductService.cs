
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class ProductService : IProductService
    {
        ProductRepository productRepository = null;

        public async Task<IEnumerable<int>> AddProduct(Product Product)
        {
            using (productRepository = new ProductRepository())
            {
                return await productRepository.AddProduct(Product);
            }
        }

        public async Task<IEnumerable<int>> EditProduct(Product Product)
        {
            using (productRepository = new ProductRepository())
            {
                return await productRepository.EditProduct(Product);
            }
        }

        public async Task<IEnumerable<Product>> ProductList()
        {
            using (productRepository = new ProductRepository())
            {
                return await productRepository.ProductList();
            }
        }

        public async Task<IEnumerable<int>> DeleteProduct(int ProductId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (productRepository = new ProductRepository())
            {
                return await productRepository.DeleteProduct(ProductId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
