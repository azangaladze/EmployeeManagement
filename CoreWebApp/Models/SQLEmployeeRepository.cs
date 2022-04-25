using CoreWebApp.Data;
using System.Collections.Generic;

namespace CoreWebApp.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            _context.SaveChanges();
            }
            return employee;

        }

        public Employee Edit(Employee employeeChanges)
        {
            _context.Update(employeeChanges);
            _context.SaveChanges();
            return employeeChanges;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
