using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
    public interface ITipoDeportivo
    {
        Task<List<TipoDeportivo>> Gettipodep();
        void Save(TipoDeportivo oTipdepo);
        void Update(TipoDeportivo oTipdepo);
        string Delete(int id_tipdep);
    }
}
