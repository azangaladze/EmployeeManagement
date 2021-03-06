using System.Collections.Generic;
using System.Linq;
using CoreWebApp.Data;
using CoreWebApp.Interfaces;
using CoreWebApp.Models;

namespace CoreWebApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void Delete(int id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
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

        public IQueryable<Employee> Search(string employee)
        {
            if (employee == null) 
            {
                return _context.Employees;
            }

            return _context.Employees.Where(x => x.Name.ToLower().Contains(employee) ||
                                            x.Email.ToLower().Contains(employee.ToLower())).AsQueryable();
        }
    }
}
