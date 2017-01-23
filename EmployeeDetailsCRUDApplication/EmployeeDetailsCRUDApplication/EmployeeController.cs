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
        private static readonly IEmployeeRepository _employee = new EmployeeRepository();

        public HttpResponseMessage Get(string id)
        { 
            if (id=="all")
            {
               var result = _employee.GetAllEmployee().AsQueryable();
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }
            else
            {
                var  result = _employee.GetEmployee(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }
        }

        public HttpResponseMessage Post(Employee EmployeeObject)
        {
            var result = _employee.AddEmployee(EmployeeObject);
            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Insert the record");
        }

        public HttpResponseMessage Put(string id, Employee value)
        {
            var result = _employee.UpdateEmployee(id, value);
            if (result != false)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
        }

        public HttpResponseMessage Delete(string id)
        {
                 if(id == null)
                 {
                         throw new Exception("ID is Null");
                 }
                 string[] ids = id.Split(',');

                 if (ids.Length == 1)
                 {
                     var result = _employee.RemoveEmployee(ids[0]);
                if (result != false)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }
                 else
                {
                    var result  = false;
                     foreach (var item in ids)
                     {
                          result = _employee.RemoveEmployee(item);
                     }
                if (result != false)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldnt Fetch All Employees");
            }        
        }
    }
}