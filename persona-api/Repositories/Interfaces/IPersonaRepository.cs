using persona_api.Models.Entities;

namespace persona_api.Repositories.Interfaces
{
    public interface IPersonaRepository
    {
        List<Persona> FindAll();
        Persona? FindById(int cc);
        void CreatePersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeleteById(int cc);
    }
}