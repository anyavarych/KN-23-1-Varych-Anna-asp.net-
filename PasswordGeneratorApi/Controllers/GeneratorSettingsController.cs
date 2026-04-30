using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Data;
using PasswordGeneratorApi.Models;

namespace PasswordGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class GeneratorSettingsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DatabaseSimulation.GeneratorSettings);
        }

        [HttpPost]
        public IActionResult Save(PasswordGeneratorSettings settings)
        {
            DatabaseSimulation.GeneratorSettings.Add(settings);

            return Ok(settings);
        }
    }
}
