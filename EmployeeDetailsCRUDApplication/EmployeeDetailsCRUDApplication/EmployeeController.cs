using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using EmployeeDetailsCRUDApplication;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Net.Http;

namespace EmployeeDetailsCRUDApplication
{
    public class EmployeeController : ApiController
     {
        private static readonly AbstractionClass _employee = new AbstractionClass();

        public HttpResponseMessage Get()
        {
                var result = _employee.GetAllEmployees().AsQueryable();
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");      
        }

        public HttpResponseMessage Get(string id)
        {     
                var  result = _employee.GetEmployeeById(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
        }

        public HttpResponseMessage Post(Employee EmployeeObject)
        {
            var result = _employee.InsertEmployee(EmployeeObject);
            if (result == 1)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Insert the record");

        }

        public HttpResponseMessage Put(string id, Employee value)
        {
            value.Id = ObjectId.Parse(id);
            var result = _employee.UpdateEmployee(id, value);
            if (result == 1)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
        }

        public HttpResponseMessage Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("ID is Null");
            }
            string[] ids = id.Split(',');

            if (ids.Length == 1)
            {
                var result = _employee.DeleteOneEmployee(ids[0]);
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }
            else
            {
                var result = 0;
                foreach (var item in ids)
                {
                    result = _employee.DeleteOneEmployee(item);
                }
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }
        }
    }
}