using GraphQL.Photos.Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Photos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly PhotosDbContext _photosDbContext;

        public ApiController(PhotosDbContext photosDbContext)
        {
            _photosDbContext = photosDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Photo services");
        }
    }
}
