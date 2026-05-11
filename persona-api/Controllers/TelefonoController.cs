using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        // ------- get ------
        public IActionResult Index()
        {
            var telefonos = _repository.FindAll();
            return View(telefonos);
        }

        // ------- create ------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            _repository.CreateTelefono(telefono);
            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Edit(string num)
        {
            var telefono = _repository.FindById(num);
            if (telefono == null) return NotFound();
            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            _repository.UpdateTelefono(telefono);
            return RedirectToAction("Index");
        }

        // ------- delete ------
        [HttpGet]
        public IActionResult Delete(string num)
        {
            var telefono = _repository.FindById(num);
            if (telefono == null) return NotFound();
            return View(telefono);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string num)
        {
            _repository.DeleteById(num);
            return RedirectToAction("Index");
        }
    }
}