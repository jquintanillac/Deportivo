using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface IDeportivoAccesorio
    {
        Task<List<VMDeporacc>> GetDeporacce();       
        void Save(DeportivoAccesorio oDeporacce);
        void Update(DeportivoAccesorio oDeporacce);
        string Delete(int id_depacce);
    }
}
