using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
    public interface IHorario
    {
        Task<List<Horario>> GetHorario();      
        void Save(Horario oHorario);
        void Update(Horario oHorario);
        string Delete(int id_hordep);
    }
}
