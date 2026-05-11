using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _personaDbContext;

        public PersonaRepository(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }

        List<Persona> IPersonaRepository.FindAll()
        {
            return _personaDbContext.Personas.ToList();
        }

        Persona? IPersonaRepository.FindById(int cc)
        {
            return _personaDbContext.Personas
                .FirstOrDefault(p => p.Cc == cc);
        }

        void IPersonaRepository.CreatePersona(Persona persona)
        {
            _personaDbContext.Personas.Add(persona);
            _personaDbContext.SaveChanges();
        }

        void IPersonaRepository.UpdatePersona(Persona persona)
        {
            _personaDbContext.Update(persona);
            _personaDbContext.SaveChanges();
        }

        void IPersonaRepository.DeleteById(int cc)
        {
            var persona = _personaDbContext.Personas
                .FirstOrDefault(p => p.Cc == cc);

            if (persona == null) return;

            _personaDbContext.Remove(persona);
            _personaDbContext.SaveChanges();
        }
    }
}