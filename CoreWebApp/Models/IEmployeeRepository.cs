using System.Collections.Generic;

namespace CoreWebApp.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();
        Employee Add(Employee employee);
        Employee Edit(Employee employeeChanges);
        Employee Delete(int id);

    }
}
