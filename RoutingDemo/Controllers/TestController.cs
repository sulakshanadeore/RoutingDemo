using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("{code:regex(^[A-Z]$)}")]
        public IActionResult Get(string code)
        {
            return Ok(code);
        }
    }
}
