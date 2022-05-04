using CoreWebApp.Models;
using System.Collections.Generic;

namespace CoreWebApp.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();
        Employee Add(Employee employee);
        Employee Edit(Employee employeeChanges);
        void Delete(int id);

    }
}
