using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpPost("{email}")]
        public IActionResult Post(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { return BadRequest("Invalid email "); }
            return Ok(email);
        }

        //[HttpPost]
        //public IActionResult Post(UserProfile email)
        //{
        //    return Ok(email);
        //}

    }
}
