using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetailsCRUDApplication
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();

        Employee GetEmployee(string id);

        Employee AddEmployee(Employee item);

        bool RemoveEmployee(string id);

        bool UpdateEmployee(string id, Employee item);
    }
}