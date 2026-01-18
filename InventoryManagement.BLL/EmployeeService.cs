
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class EmployeeService : IEmployeeService
    {
        EmployeeRepository employeeRepository = null;

        public async Task<IEnumerable<int>> AddEmployee(Employee Employee)
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.AddEmployee(Employee);
            }
        }

        public async Task<IEnumerable<int>> EditEmployee(Employee Employee)
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.EditEmployee(Employee);
            }
        }

        public async Task<IEnumerable<Employee>> EmployeeList()
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.EmployeeList();
            }
        }

        public async Task<IEnumerable<EmployeeDesignation>> GetEmployeeDesignationDetails()
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.GetEmployeeDesignationDetails();
            }
        }

        public async Task<IEnumerable<EmployeeDepartment>> GetEmployeeDepartmentDetails()
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.GetEmployeeDepartmentDetails();
            }
        }

        public async Task<IEnumerable<int>> DeleteEmployee(int EmployeeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (employeeRepository = new EmployeeRepository())
            {
                return await employeeRepository.DeleteEmployee(EmployeeId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
