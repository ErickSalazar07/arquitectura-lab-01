using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _personaDbContext;

        public EstudioRepository(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }

        List<Estudio> IEstudioRepository.FindAll()
        {
            return _personaDbContext.Estudios.ToList();
        }
    }
}
