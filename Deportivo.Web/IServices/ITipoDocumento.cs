using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
    public interface ITipoDocumento
    {
        Task<List<TipoDocumento>> Gettipodoc();      
        void Save(TipoDocumento oTipdepo);
        void Update(TipoDocumento oTipdepo);
        string Delete(int id_tipdep);
    }
}
