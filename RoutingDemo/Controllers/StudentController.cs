using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Models;
using System.Xml.Linq;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//webapi behaviour
    public class StudentController : ControllerBase
    {
        static List<SchoolStudents> studs = new List<SchoolStudents>() { 
        new SchoolStudents{Id=1,Name="Anita",Status="Enquired" },
        new SchoolStudents{Id=2,Name="Sunita",Status="Enquired" },
        new SchoolStudents{Id=4,Name="Vinita",Status="Enrolled" },
        new SchoolStudents{Id=3,Name="Nikita",Status="Enquired" },
        new SchoolStudents{Id=5,Name="Ankita",Status="Enrolled" },
                };

        [HttpGet]
        public IActionResult GetAllStudents() {

            return Ok(studs);
        }
       [HttpGet("{id:int}")]//Path with constraint int as datatype for value of id
        public IActionResult GetById(int id) {

            var s = studs.Where(e=>e.Id==id).FirstOrDefault();  
            return Ok($"Student details{s.Name}{s.Status}{s.Id}");
        }
        [HttpGet("studname")]//Queryparameter wih name and action name=studname
        public IActionResult GetByName(string name)
        {

            var s = studs.Where(e => e.Name == name).FirstOrDefault();
            return Ok($"Student details{s.Name}{s.Status}{s.Id}");
        }

        [HttpGet("activestudents")]
        public List<SchoolStudents> GetEnrolled()
        {
            var s = studs.Where(e => e.Status == "Enrolled").ToList();
            return s;
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = studs.Where(e => e.Id == id).FirstOrDefault();
            studs.Remove(s);
            return Ok($"Trying to delete {id}");
        }

        [HttpGet]
        [Route("/enquired")]
        public IActionResult StudentsEnquired()
        {

            var s = studs.Where(e => e.Status == "Enquired").ToList();
            return Ok(s);
        }

        [HttpGet("{id}/{status}")]
        //https://localhost:7052/api/Student/1/Enquired
        public IActionResult GetStudentStatus(int id, string status)
        {
            var s = studs.Where(e => e.Status == "Enquired" && e.Id==id).First();
            return Ok(s);

        }


        [HttpGet("{id}/studentstatus/{status}")]
        //https://localhost:7052/api/Student/1/studentstatus/Enquired
        public IActionResult GetStatus(int id, string status)
        {
            var s = studs.Where(e => e.Status == "Enquired" && e.Id == id).First();
            return Ok(s);

        }

        [HttpGet("{id}/status")]
        public IActionResult GetData(int id,string status) 
        {
            var s = studs.Where(e => e.Status == "Enquired" && e.Id == id).First();
            return Ok(s);
        }

        [HttpGet("Rollno/{id}")]
        public IActionResult GetData1(int id, string status)
        {
            var s = studs.Where(e => e.Status == "Enquired" && e.Id == id).First();
            return Ok(s);
        }

    }
}
