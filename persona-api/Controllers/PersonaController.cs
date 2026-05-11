using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _repository;

        public PersonaController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        // ------- get ------
        public IActionResult Index()
        {
            var personas = _repository.FindAll();
            return View(personas);
        }

        // ------- create ------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            _repository.CreatePersona(persona);
            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Edit(int cc)
        {
            var persona = _repository.FindById(cc);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            _repository.UpdatePersona(persona);
            return RedirectToAction("Index");
        }

        // ------- delete ------
        [HttpGet]
        public IActionResult Delete(int cc)
        {
            var persona = _repository.FindById(cc);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int cc)
        {
            _repository.DeleteById(cc);
            return RedirectToAction("Index");
        }
    }
}