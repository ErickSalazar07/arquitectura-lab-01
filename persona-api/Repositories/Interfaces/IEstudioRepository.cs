using persona_api.Models.Entities;

namespace persona_api.Repositories.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> FindAll();
    }
}
