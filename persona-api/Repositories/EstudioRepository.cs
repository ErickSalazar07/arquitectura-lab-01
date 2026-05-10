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

        void IEstudioRepository.CreateEstudio(Estudio estudio)
        {   
            _personaDbContext.Estudios.Add(estudio);
            _personaDbContext.SaveChanges();
        }

        List<Estudio> IEstudioRepository.FindAll()
        {
            return _personaDbContext.Estudios.ToList();
        }

        Estudio? IEstudioRepository.FindById(int idProf, int ccPer)
        {
            return _personaDbContext.Estudios
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);
        }

        void IEstudioRepository.UpdateEstudio(Estudio estudio)
        {
            _personaDbContext.Update(estudio);
            _personaDbContext.SaveChanges();
        }

        void IEstudioRepository.DeleteById(int idProf, int ccPer)
        {
            var estudio = _personaDbContext.Estudios
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

            if (estudio == null) return;

            _personaDbContext.Remove(estudio);
            _personaDbContext.SaveChanges();

        }
    }
}
