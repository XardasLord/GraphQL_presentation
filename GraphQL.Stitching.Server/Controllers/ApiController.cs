using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Stitching.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GraphQL Stitching Server");
        }
    }
}
