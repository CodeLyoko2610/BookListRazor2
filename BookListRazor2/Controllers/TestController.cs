using Microsoft.AspNetCore.Mvc;

namespace BookListRazor2.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Ok("Index of test says Hi to you!");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] string requestBody)
        {
            return Ok("Pending using the requestBody");
        }
    }
}