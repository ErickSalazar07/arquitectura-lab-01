using Microsoft.AspNetCore.Mvc;
using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Controllers
{
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _repository;

        public EstudioController(IEstudioRepository repository)
        {
            _repository = repository;
        }

        // ------- get ------
        public IActionResult Index()
        {
            var estudios = _repository.FindAll();

            return View(estudios);
        }

        // ------- create ------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            _repository.CreateEstudio(estudio);
            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Edit(int idProf, int ccPer)
        {
            var estudio = _repository.FindById(idProf, ccPer);

            if (estudio == null) return NotFound();
            return View(estudio);
        }

        [HttpPost]
        public IActionResult Edit(Estudio estudio)
        {
            _repository.UpdateEstudio(estudio);

            return RedirectToAction("Index");
        }

        // ------- update ------
        [HttpGet]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _repository.FindById(idProf, ccPer);

            if (estudio == null) return NotFound();
            return View(estudio);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int idProf, int ccPer)
        {
            _repository.DeleteById(idProf, ccPer);

            return RedirectToAction("Index");
        }
    }
}
