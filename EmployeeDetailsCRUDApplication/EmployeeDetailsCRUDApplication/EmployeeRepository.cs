using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MongoDB.Bson.Serialization.BsonDeserializationContext;

namespace EmployeeDetailsCRUDApplication
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IMongoCollection<Employee> _employees;
        public EmployeeRepository()
        {
                var connection = "mongodb://localhost:27017";

                MongoClient Client = new MongoClient(connection);
                _employees = Client.GetDatabase("Employee").GetCollection<Employee>("EmployeeDetails");
        }

        public Employee AddEmployee(Employee NewEmployee)
        {
            NewEmployee.Id = ObjectId.GenerateNewId();
            _employees.InsertOne(NewEmployee);
            return NewEmployee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> emplist = _employees.Find<Employee>(_=> true).ToList<Employee>();
            return emplist;
        }

        public Employee GetEmployee(string id)
        {
            var condition = Query.EQ("Id", id).ToString();
            return _employees.Find(condition).FirstOrDefault();
        }

        public bool RemoveEmployee(string id)
        {
            var condition = Query.EQ("Id", id).ToString();
            var result = _employees.DeleteOne(condition);
            return result.IsAcknowledged;
        }

        public bool UpdateEmployee(string id, Employee item)
        {
            var condition = Query.EQ("Id", id).ToString();
            var _update = Builders<Employee>.Update
                .Set("FirstName", item.FirstName)
                .Set("LastName", item.LastName)
                .Set("Phone", item.Phone)
                .Set("Email", item.Email)
                .Set("Address", item.Address)
                .Set("Status", item.Status);
            var result = _employees.UpdateOne(condition, _update);
            return result.IsAcknowledged;

        }
    }
}

    

