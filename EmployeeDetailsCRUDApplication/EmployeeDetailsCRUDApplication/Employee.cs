using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EmployeeDetailsCRUDApplication
{
    public class Employee
    {

        public Employee()
        {

        }

        public Employee(string fname , string lname, string phone , string email, string address ,  string status)
        {
            Id = ObjectId.GenerateNewId();
            FirstName = fname;
            LastName = lname;
            Phone = phone;
            Email = email;
            Address = address;
            Status = status;
        }
        [BsonId]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public static explicit operator Employee(Task<Employee> v)
        {
            throw new NotImplementedException();
        }
    }
}