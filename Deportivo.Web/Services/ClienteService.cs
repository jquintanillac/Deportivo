using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class ClienteService : ICliente
    {
        private readonly DataContext _context;
        public ClienteService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_client)
        {
            var clie = _context.clientes.FirstOrDefault(x => x.id_client == id_client);
            if (clie != null)
            {
                _context.clientes.Remove(clie);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public async Task<List<VMCliente>> Getcliente()
        {
            var vmviatdet = await (from cliente in _context.clientes
                             join tipodocumento in _context.tipoDocumentos on cliente.id_tipdoc equals tipodocumento.id_tipdoc
                             select new VMCliente
                             {
                                 id_client = cliente.id_client,
                                 id_tipdoc = cliente.id_tipdoc,
                                 client_desc = cliente.client_desc,
                                 client_telf = cliente.client_telf,
                                 tipodoc = tipodocumento.tipdoc_desc,
                                 client_dociden = cliente.client_dociden,
                                 client_email = cliente.client_email,
                                 client_obser = cliente.client_obser,
                                 client_act = cliente.client_act
                             }).ToListAsync();
            return vmviatdet;
        }
        public void Save(Cliente oCliente)
        {
            _context.clientes.Add(oCliente);
            _context.SaveChanges();
        }

        public void Update(Cliente oCliente)
        {
            _context.clientes.Update(oCliente);
            _context.SaveChanges();
        }
    }
}
