using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface IHorario
    {
        Task<List<VMHorario>> GetHorario();      
        string Save(Horario oHorario);
        string Update(Horario oHorario);
        string Delete(int id_hordep);
    }
}
