using Microsoft.AspNetCore.Mvc;

namespace HTW.Todo.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HalloWorldController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hallo World!");
        }
    }
}