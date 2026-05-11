using persona_api.Models.Entities;

namespace persona_api.Repositories.Interfaces
{
    public interface IProfesionRepository
    {
        List<Profesion> FindAll();
        Profesion? FindById(int id);
        void CreateProfesion(Profesion profesion);
        void UpdateProfesion(Profesion profesion);
        void DeleteById(int id);
    }
}
