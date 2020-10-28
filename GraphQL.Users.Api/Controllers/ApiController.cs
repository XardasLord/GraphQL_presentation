using GraphQL.Users.Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly UsersDbContext _usersDbContext;

        public ApiController(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("User services");
        }
    }
}
