using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Validate(NewEmployee);

            NewEmployee.Id = ObjectId.GenerateNewId();
            _employees.InsertOne(NewEmployee);
            return NewEmployee;

        }

        public static void Validate(Employee NewEmployee)
        {
            if (NewEmployee.FirstName == null)
                throw new Exception("FirstName cannot be NUll");
            if (NewEmployee.LastName == null)
                throw new Exception("LastName cannot be Null");
            if (NewEmployee.Email == null)
                throw new Exception("Email cannot be empty");
            try
            {
                System.Net.Mail.MailAddress NewEmployeeEmail = new System.Net.Mail.MailAddress(NewEmployee.Email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "Email Is not valid");
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> emplist = _employees.Find<Employee>(_=> true).ToList<Employee>();
            return emplist;
        }

        public Employee GetEmployee(string id)
        {
            var ObjId = ObjectId.Parse(id);
            var returnvalue = _employees.Find(_ => _.Id == ObjId).Single();
            return returnvalue;
        }

        public bool RemoveEmployee(string id)
        {

            var ObjId = ObjectId.Parse(id);
            var EmployeeObject =  _employees.Find(_ => _.Id == ObjId).Single();

            if(EmployeeObject.Status == "Activated")
                throw new Exception("Activated Employee cant be deleted");

            var filter = Builders<Employee>.Filter.Eq("Id", ObjId);
            var result = _employees.DeleteOne(filter);
            return result.IsAcknowledged; 
        }

        public bool UpdateEmployee(string id, Employee NewEmployee)
        {
            Validate(NewEmployee);

            var Objid = ObjectId.Parse(id);
            var filter = Builders<Employee>.Filter.Eq("Id", Objid);
            var result = _employees.ReplaceOneAsync(filter, NewEmployee);
            if (result != null)
                return true;
            else
                return false;
        }
    }
}

    

