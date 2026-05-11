using persona_api.Models.Entities;

namespace persona_api.Repositories.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> FindAll();
        Estudio? FindById(int idProf, int ccPer);
        void CreateEstudio(Estudio estudio);
        void UpdateEstudio(Estudio estudio);
        void DeleteById(int idProf, int ccPer);
    }
}
