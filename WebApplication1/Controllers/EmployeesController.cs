using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeesController : ApiController
    {
        private static List<Employees> _employeesList = new List<Employees>();

        // GET: api/employees
        
        public HttpResponseMessage GetEmployees()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _employeesList);
        }

        // POST: api/department
        public HttpResponseMessage AddEmployees(Employees Employee)
        {
            _employeesList.Add(Employee);

            return Request.CreateResponse(HttpStatusCode.Accepted, Employee);
        }

        // GET: api/department/id
        public HttpResponseMessage GetEmployeeByid(int id)
        {
            Employees empObj = _employeesList.Find(m => m.id == id);
            if (empObj != null)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, empObj);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The employee with that ID is not found!");
            }
        }

        //UPDATE: api.department/id
        [HttpPut]
        public HttpResponseMessage updateempl(int id, [FromBody]Employees eObj)
        {
            Employees empObj = _employeesList.Find(m => m.id == id);
            if (empObj != null)
            {
                empObj.name = eObj.name;
                return Request.CreateResponse(HttpStatusCode.Accepted, _employeesList);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The employee with that ID is not found!");
            }
        }
    }
}
