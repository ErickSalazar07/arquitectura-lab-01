using persona_api.Models.Entities;

namespace persona_api.Repositories.Interfaces
{
    public interface ITelefonoRepository
    {
        List<Telefono> FindAll();
        Telefono? FindById(string num);
        void CreateTelefono(Telefono telefono);
        void UpdateTelefono(Telefono telefono);
        void DeleteById(string num);
    }
}