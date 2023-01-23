using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
    public interface IAccesorios
    {
        Task<List<Accesorios>> GetAccesorio();
        void Save(Accesorios oAccesorio);
        void Update(Accesorios oAccesorio);
        string Delete(int id_acce);
    }
}
