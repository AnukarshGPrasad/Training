using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetailsCRUDApplication
{
    public class Employee
    {

        public Employee()
        {

        }
        [BsonId]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

    }
}