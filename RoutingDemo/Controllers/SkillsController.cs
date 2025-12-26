using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Data;
using RoutingDemo.Models;
using RoutingDemo.ModelsData;
using System.Net.Http.Json;
namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly HRContext _context;
        public SkillsController(HttpClient client,HRContext context)
        {
            _client = client;
            _context = context;
        }

        [HttpGet("employee/{empid}")]
        public async Task<IActionResult> GetSkills(int empid)
        {
            int eid = empid;
            var emp = await _client.GetFromJsonAsync<Employee>($"https://localhost:7052/api/Employee/{empid}");
            var skills = from s in _context.EmpSkills
                         where s.Empdid == empid
                         select new { empidfetched=s.Empdid, skillid=s.SkillId };


            

            var empskillsData = new
            {
                emp.EmpId,
                emp.EmpName,
                emp.DeptId,
                Skills = skills
            };
            
            return Ok(empskillsData);
        }
    }
}
