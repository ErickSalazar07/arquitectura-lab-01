using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }
        void IProfesionRepository.CreateProfesion(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            _context.SaveChanges();
        }

        void IProfesionRepository.DeleteById(int id)
        {
            var profesion = _context.Profesions
                .FirstOrDefault(p => p.Id == id);
            if (profesion == null) return;
            _context.Remove(profesion);
            _context.SaveChanges();
        }

        List<Profesion> IProfesionRepository.FindAll()
        {
            return _context.Profesions.ToList();
        }

        Profesion? IProfesionRepository.FindById(int id)
        {
            return _context.Profesions
                .FirstOrDefault(p => p.Id == id);
        }

        void IProfesionRepository.UpdateProfesion(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            _context.SaveChanges();
        }
    }
}
