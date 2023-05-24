using POCApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POCApplication.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployeeDetails();

        IEnumerable<Employee> GetEmployeeDetailsbyId(int EmployeeId);

        Task<Employee> InsertEmployee(Employee emp);

        Task<Employee> UpdateEmployee(Employee emp);

        bool DeleteEmployee(int EmployeeId);


    }
}
