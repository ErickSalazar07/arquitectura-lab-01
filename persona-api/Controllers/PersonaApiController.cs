using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaApiController : ControllerBase
    {
        private readonly IPersonaRepository _repository;

        public PersonaApiController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var personas = _repository.FindAll();
            return Ok(personas);
        }

        [HttpGet("{cc}")]
        public IActionResult GetById(int cc)
        {
            var persona = _repository.FindById(cc);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Persona persona)
        {
            _repository.CreatePersona(persona);
            return CreatedAtAction(nameof(GetById), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        public IActionResult Update(int cc, [FromBody] Persona persona)
        {
            if (cc != persona.Cc) return BadRequest();
            _repository.UpdatePersona(persona);
            return NoContent();
        }

        [HttpDelete("{cc}")]
        public IActionResult Delete(int cc)
        {
            var persona = _repository.FindById(cc);
            if (persona == null) return NotFound();
            _repository.DeleteById(cc);
            return NoContent();
        }
    }
}