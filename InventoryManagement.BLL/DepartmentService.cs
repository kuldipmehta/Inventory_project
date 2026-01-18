using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class DepartmentService : IDepartmentService
    {
        DepartmentRepository departmentRepository = null;

        public async Task<IEnumerable<int>> AddDepartment(Department Department)
        {
            using (departmentRepository = new DepartmentRepository())
            {
                return await departmentRepository.AddDepartment(Department);
            }
        }

        public async Task<IEnumerable<int>> EditDepartment(Department Department)
        {
            using (departmentRepository = new DepartmentRepository())
            {
                return await departmentRepository.EditDepartment(Department);
            }
        }

        public async Task<IEnumerable<Department>> DepartmentList()
        {
            using (departmentRepository = new DepartmentRepository())
            {
                return await departmentRepository.DepartmentList();
            }
        }

        public async Task<IEnumerable<int>> DeleteDepartment(int DepartmentId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (departmentRepository = new DepartmentRepository())
            {
                return await departmentRepository.DeleteDepartment(DepartmentId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
