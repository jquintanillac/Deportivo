using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface ICliente
    {
        Task<List<VMCliente>> Getcliente();
        void Save(Cliente oCliente);
        void Update(Cliente oCliente);
        string Delete(int id_client);
    }
}
