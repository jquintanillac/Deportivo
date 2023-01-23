using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
    public interface IAdicionales
    {
        Task<List<Adicionales>> GetAdicion();
        void Save(Adicionales oAdcional);
        void Update(Adicionales oAdcional);
        string Delete(int id_adicio);
    }
}
