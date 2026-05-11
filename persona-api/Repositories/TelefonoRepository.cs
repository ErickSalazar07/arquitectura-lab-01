using persona_api.Models.Entities;
using persona_api.Repositories.Interfaces;

namespace persona_api.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _personaDbContext;

        public TelefonoRepository(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }

        List<Telefono> ITelefonoRepository.FindAll()
        {
            return _personaDbContext.Telefonos.ToList();
        }

        Telefono? ITelefonoRepository.FindById(string num)
        {
            return _personaDbContext.Telefonos
                .FirstOrDefault(t => t.Num == num);
        }

        void ITelefonoRepository.CreateTelefono(Telefono telefono)
        {
            _personaDbContext.Telefonos.Add(telefono);
            _personaDbContext.SaveChanges();
        }

        void ITelefonoRepository.UpdateTelefono(Telefono telefono)
        {
            _personaDbContext.Update(telefono);
            _personaDbContext.SaveChanges();
        }

        void ITelefonoRepository.DeleteById(string num)
        {
            var telefono = _personaDbContext.Telefonos
                .FirstOrDefault(t => t.Num == num);

            if (telefono == null) return;

            _personaDbContext.Remove(telefono);
            _personaDbContext.SaveChanges();
        }
    }
}