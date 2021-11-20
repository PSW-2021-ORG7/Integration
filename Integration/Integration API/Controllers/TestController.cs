using Integration_Class_Library.SharedModel;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new TestClass().Test());
        }
    }
}
