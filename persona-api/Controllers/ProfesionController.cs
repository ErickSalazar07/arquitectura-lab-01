using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _repository;

        public ProfesionController(IProfesionRepository repository)
        {
            _repository = repository;
        }

        // =========================
        // READ
        // =========================
        public IActionResult Index()
        {
            var profesiones = _repository.FindAll();

            return View(profesiones);
        }

        // =========================
        // CREATE GET
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE POST
        // =========================
        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            _repository.CreateProfesion(profesion);

            return RedirectToAction("Index");
        }

        // =========================
        // EDIT GET
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var profesion = _repository.FindById(id);

            if (profesion == null)
                return NotFound();

            return View(profesion);
        }

        // =========================
        // EDIT POST
        // =========================
        [HttpPost]
        public IActionResult Edit(Profesion profesion)
        {
            _repository.UpdateProfesion(profesion);

            return RedirectToAction("Index");
        }

        // =========================
        // DELETE GET
        // =========================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var profesion = _repository.FindById(id);

            if (profesion == null)
                return NotFound();

            return View(profesion);
        }

        // =========================
        // DELETE POST
        // =========================
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
