using Microsoft.EntityFrameworkCore;
using POCApplication.DatabaseContext;
using POCApplication.Models;

namespace POCApplication.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _appDBContext;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public bool DeleteEmployee(int empId)
        {
            bool result = false;
            var employee = _appDBContext.Employee.Find(empId);
            if (employee != null)
            {
                _appDBContext.Entry(employee).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployeeDetails()
        {
            return _appDBContext.Employee.ToList();
           
        }

        public IEnumerable<Employee> GetEmployeeDetailsbyId(int EmployeeId)
        {
            return _appDBContext.Employee.Where(x => x.EmployeeId == EmployeeId).ToList(); ;
           
        }

        public async Task<Employee> InsertEmployee(Employee emp)
        {
            _appDBContext.Employee.Add(emp);
            await _appDBContext.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            _appDBContext.Entry(emp).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return emp;
        }
    }
}
