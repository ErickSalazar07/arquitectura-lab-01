using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    [ApiController]
    [Route("api/estudio")]
    public class EstudioApiController : ControllerBase
    {
        private readonly IEstudioRepository _repository;

        public EstudioApiController(IEstudioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estudios = _repository.FindAll();
            return Ok(estudios);
        }

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetById(int idProf, int ccPer)
        {
            var estudio = _repository.FindById(idProf, ccPer);
            if (estudio == null) return NotFound();
            return Ok(estudio);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Estudio estudio)
        {
            _repository.CreateEstudio(estudio);
            return CreatedAtAction(nameof(GetById), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult Update(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer) return BadRequest();
            _repository.UpdateEstudio(estudio);
            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _repository.FindById(idProf, ccPer);
            if (estudio == null) return NotFound();
            _repository.DeleteById(idProf, ccPer);
            return NoContent();
        }
    }
}