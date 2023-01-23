using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface IEspacioDeportivo
    {
        Task<List<VMEspDepor>> GetEspadepor();      
        void Save(EspacioDeportivo oEspadepor);
        void Update(EspacioDeportivo oEspadepor);
        string Delete(int id_espdep);
    }
}
