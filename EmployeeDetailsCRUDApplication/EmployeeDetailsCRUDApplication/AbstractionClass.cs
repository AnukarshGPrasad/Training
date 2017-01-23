using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetailsCRUDApplication
{
    public class AbstractionClass
    {

        private readonly IEmployeeRepository _employee;
        public AbstractionClass()
        {
            _employee =  new EmployeeRepository();
        }
        public AbstractionClass(IEmployeeRepository emp)
        {
            if (emp != null)
                _employee = emp;
        }

       
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employee.GetAllEmployee();
        }

        public Employee GetEmployeeById(string EmployeeID)
        {
            return _employee.GetEmployee(EmployeeID);
        }

        public int InsertEmployee(Employee NewEmployee)
        {
            Validate(NewEmployee);
            var status = _employee.AddEmployee(NewEmployee);
            if (status == true)
                return 1;
            else
                return 0;
        }

        public int DeleteOneEmployee(string EmployeeID)
        {
            var EmployeeObject = _employee.GetEmployee(EmployeeID);

            if (EmployeeObject.Status == "Activated")
                throw new Exception("Activated Employee cant be deleted");

            var status =  _employee.RemoveEmployee(EmployeeID);
            if (status)
                return 1;
            else
                return 0;
        }

        public int UpdateEmployee(string EmployeeID, Employee NewEmployee)
        {
            Validate(NewEmployee);
            var status = _employee.UpdateEmployee(EmployeeID, NewEmployee);
            if (status)
                return 1;
            else
                return 0;
        }

        public static void Validate(Employee NewEmployee)
        {
            if (NewEmployee.FirstName == null)
                throw new Exception("FirstName cannot be NUll");
            if (NewEmployee.LastName == null)
                throw new Exception("LastName cannot be Null");
            if (NewEmployee.Email == "")
                throw new Exception("Email cannot be empty");
            try
            {
                System.Net.Mail.MailAddress NewEmployeeEmail = new System.Net.Mail.MailAddress(NewEmployee.Email);
            }
            catch (Exception e)
            {
                if (e.Message != null)
                    throw new Exception("Email Is not valid");
            }
        }

    }
}