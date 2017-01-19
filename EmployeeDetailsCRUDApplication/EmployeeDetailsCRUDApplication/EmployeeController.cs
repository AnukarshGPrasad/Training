using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace EmployeeDetailsCRUDApplication
{
    public class EmployeeController : ApiController
     {
        private static readonly IEmployeeRepository _employee = new EmployeeRepository();

        public IQueryable<Employee> Get()
        {
            return _employee.GetAllEmployee().AsQueryable();
        }

        public Employee Get(string id)
        {
            Employee emp = _employee.GetEmployee(id);
            if (emp == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return emp;
        }

        public Employee Post(Employee value)
        {
            Employee emp = _employee.AddEmployee(value);
            return emp;
        }

        public void Put(string id,Employee value)
        {
            if (!_employee.UpdateEmployee(id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(string id)
        {
            if (!_employee.RemoveEmployee(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}