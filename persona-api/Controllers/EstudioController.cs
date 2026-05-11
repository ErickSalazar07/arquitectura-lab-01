using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;
        private readonly IProfesionRepository _profesionRepository;
        private readonly IPersonaRepository _personaRepository;

        public EstudioController(IEstudioRepository repository, IProfesionRepository profesionRepository, IPersonaRepository personaRepository)
        {
            _estudioRepository = repository;
            _profesionRepository = profesionRepository;
            _personaRepository = personaRepository;
        }

        // ------- get ------
        public IActionResult Index()
        {
            var estudios = _estudioRepository.FindAll();

            return View(estudios);
        }

        // ------- create ------
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Profesiones = _profesionRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Id} - {p.Nom}"
                })
                .ToList();

            ViewBag.Personas = _personaRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Cc.ToString(),
                    Text = $"{p.Cc} - {p.Nombre} {p.Apellido}"
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            _estudioRepository.CreateEstudio(estudio);
            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Edit(int idProf, int ccPer)
        {
            var estudio = _estudioRepository.FindById(idProf, ccPer);

            if (estudio == null)
                return NotFound();

            ViewBag.Profesiones = _profesionRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Id} - {p.Nom}"
                })
                .ToList();

            ViewBag.Personas = _personaRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Cc.ToString(),
                    Text = $"{p.Cc} - {p.Nombre} {p.Apellido}"
                })
                .ToList();

            return View(estudio);
        }

        [HttpPost]
        public IActionResult Edit(Estudio estudio)
        {
            _estudioRepository.UpdateEstudio(estudio);

            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _estudioRepository.FindById(idProf, ccPer);

            if (estudio == null) return NotFound();
            return View(estudio);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int idProf, int ccPer)
        {
            _estudioRepository.DeleteById(idProf, ccPer);

            return RedirectToAction("Index");
        }
    }
}
