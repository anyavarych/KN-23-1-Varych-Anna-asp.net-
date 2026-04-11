using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Models;
using PasswordGeneratorApi.Services;

namespace PasswordGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/passwords")]
    public class PasswordController : Controller
    {
        private readonly PasswordService _service;

        public PasswordController(PasswordService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var item = _service.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PasswordEntry entry)
        {
            _service.Create(entry);
            return Ok(entry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PasswordEntry entry)
        {
            _service.Update(id, entry);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
