using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Data;
using PasswordGeneratorApi.Models;

namespace PasswordGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DatabaseSimulation.Users);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            DatabaseSimulation.Users.Add(user);
            return Ok(user);
        }
    }
}
