using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private static List<Department> _departmentList = new List<Department>();

        // GET: api/department
        public HttpResponseMessage GetDepartments()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _departmentList);
        }

        // POST: api/department
        public HttpResponseMessage AddDepartment(Department department)
        {
            _departmentList.Add(department);

            return Request.CreateResponse(HttpStatusCode.OK, _departmentList);
        }

        // GET: api/department/id
        public HttpResponseMessage GetDepartmentByid(int id)
        {
            Department depObj = _departmentList.Find(m => m.DepId == id);
            if (depObj != null)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, depObj);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The department with that ID is not found!");
            }
        }

        //UPDATE: api.department/id
        public HttpResponseMessage UpdateDepartment(int id, Department dObj)
        {
            Department depObj = _departmentList.Find(m => m.DepId == id);
            if (depObj != null)
            {
                depObj.DepName = dObj.DepName;
                return Request.CreateResponse(HttpStatusCode.Accepted, _departmentList);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The department with that ID is not found!");
            }
        }
    }
}
