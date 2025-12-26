using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Data;
using RoutingDemo.Models;
using RoutingDemo.ModelsData;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HRContext _context;
        public EmployeeController(HRContext context)
        {
            _context =context;
        }
        //api/Employee/1
        [HttpGet("{id}")]
        public IActionResult GetEmployeeByID(int id) {
            Employee empdata=_context.Employees.Find(id);
            //var empdata = new
            //{
            //    EmployeeId = id,
            //    EmpName="Rahul",
            //    Department="IT"
            //};

            return Ok(empdata);
        
        }
    }
}
