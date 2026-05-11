using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    [ApiController]
    [Route("api/telefono")]
    public class TelefonoApiController : ControllerBase
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoApiController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var telefonos = _repository.FindAll();
            return Ok(telefonos);
        }

        [HttpGet("{num}")]
        public IActionResult GetById(string num)
        {
            var telefono = _repository.FindById(num);
            if (telefono == null) return NotFound();
            return Ok(telefono);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Telefono telefono)
        {
            _repository.CreateTelefono(telefono);
            return CreatedAtAction(nameof(GetById), new { num = telefono.Num }, telefono);
        }

        [HttpPut("{num}")]
        public IActionResult Update(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num) return BadRequest();
            _repository.UpdateTelefono(telefono);
            return NoContent();
        }

        [HttpDelete("{num}")]
        public IActionResult Delete(string num)
        {
            var telefono = _repository.FindById(num);
            if (telefono == null) return NotFound();
            _repository.DeleteById(num);
            return NoContent();
        }
    }
}