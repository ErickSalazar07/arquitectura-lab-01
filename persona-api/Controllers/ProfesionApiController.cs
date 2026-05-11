using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    [ApiController]
    [Route("api/profesion")]
    public class ProfesionApiController : ControllerBase
    {
        private readonly IProfesionRepository _repository;

        public ProfesionApiController(IProfesionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profesiones = _repository.FindAll();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var profesion = _repository.FindById(id);
            if (profesion == null) return NotFound();
            return Ok(profesion);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Profesion profesion)
        {
            _repository.CreateProfesion(profesion);
            return CreatedAtAction(nameof(GetById), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id) return BadRequest();
            _repository.UpdateProfesion(profesion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var profesion = _repository.FindById(id);
            if (profesion == null) return NotFound();
            _repository.DeleteById(id);
            return NoContent();
        }
    }
}