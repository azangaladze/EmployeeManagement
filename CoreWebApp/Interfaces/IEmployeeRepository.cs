using CoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();
        Employee Add(Employee employee);
        Employee Edit(Employee employeeChanges);
        void Delete(int id);
        IQueryable<Employee> Search(string employee);
    }
}
