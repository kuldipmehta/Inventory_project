using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> DepartmentList();
        Task<IEnumerable<int>> AddDepartment(Department department);
        Task<IEnumerable<int>> EditDepartment(Department department);
        Task<IEnumerable<int>> DeleteDepartment(int departmentId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
