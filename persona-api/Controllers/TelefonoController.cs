using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;

        private readonly IPersonaRepository _personaRepository;

        public TelefonoController(ITelefonoRepository repository, IPersonaRepository personaRepository)
        {
            _telefonoRepository = repository;
            _personaRepository = personaRepository;
        }

        // ------- get ------
        public IActionResult Index()
        {
            var telefonos = _telefonoRepository.FindAll();
            return View(telefonos);
        }

        // =========================
        // CREATE GET
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Personas = _personaRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Cc.ToString(),
                    Text = $"{p.Cc} - {p.Nombre} {p.Apellido}"
                })
                .ToList();

            return View();
        }

        // =========================
        // CREATE POST
        // =========================
        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            _telefonoRepository.CreateTelefono(telefono);

            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Edit(string num)
        {
            var telefono = _telefonoRepository.FindById(num);
            if (telefono == null) return NotFound();


            ViewBag.Personas = _personaRepository.FindAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Cc.ToString(),
                    Text = $"{p.Cc} - {p.Nombre} {p.Apellido}"
                }).ToList();

            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            _telefonoRepository.UpdateTelefono(telefono);
            return RedirectToAction("Index");
        }

        // ------- delete ------
        [HttpGet]
        public IActionResult Delete(string num)
        {
            var telefono = _telefonoRepository.FindById(num);
            if (telefono == null) return NotFound();
            return View(telefono);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string num)
        {
            _telefonoRepository.DeleteById(num);
            return RedirectToAction("Index");
        }
    }
}