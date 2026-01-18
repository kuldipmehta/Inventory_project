using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> EmployeeList();
        Task<IEnumerable<EmployeeDesignation>> GetEmployeeDesignationDetails();
        Task<IEnumerable<EmployeeDepartment>> GetEmployeeDepartmentDetails();
        Task<IEnumerable<int>> AddEmployee(Employee employee);
        Task<IEnumerable<int>> EditEmployee(Employee employee);
        Task<IEnumerable<int>> DeleteEmployee(int employeeId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
