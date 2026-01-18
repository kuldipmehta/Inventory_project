using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ProductList();
        Task<IEnumerable<int>> AddProduct(Product product);
        Task<IEnumerable<int>> EditProduct(Product product);
        Task<IEnumerable<int>> DeleteProduct(int productId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
