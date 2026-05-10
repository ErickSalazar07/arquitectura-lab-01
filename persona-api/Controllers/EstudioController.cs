using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Index()
        {
            var estudios = _repository.FindAll();

            return View(estudios);
        }
    }
}
