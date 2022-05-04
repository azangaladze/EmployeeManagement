using CoreWebApp.Enums;
using CoreWebApp.Interfaces;
using CoreWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApp.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Department.HR, Email = "mary@test.com"},
                new Employee() { Id = 2, Name = "John", Department = Department.IT, Email = "john@test.com"},
                new Employee() { Id = 3, Name = "Sam", Department = Department.IT, Email = "sam@test.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Count + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public void Delete(int id)
        {
            var employeeToDelete = _employeeList.FirstOrDefault(x => x.Id == id);
            if (employeeToDelete != null)
            {
                _employeeList.Remove(employeeToDelete);
            }

        }

        public Employee Edit(Employee employeeChanges)
        {
            var employee = _employeeList.FirstOrDefault(x => x.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }
}
