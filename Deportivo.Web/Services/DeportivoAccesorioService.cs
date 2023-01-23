using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Deportivo.Web.Services
{
    public class DeportivoAccesorioService : IDeportivoAccesorio
    {
        private readonly DataContext _context;
        public DeportivoAccesorioService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_depacce)
        {
            var depacc = _context.deportivoAccesorios.FirstOrDefault(x => x.id_depacce == id_depacce);
            if (depacc != null)
            {
                _context.deportivoAccesorios.Remove(depacc);
                _context.SaveChanges();
            }
            return "Deleted";
        }
        async Task<List<VMDeporacc>> IDeportivoAccesorio.GetDeporacce()
        {
            var vmdepacc = await (from Depacc in _context.deportivoAccesorios
                                   join espdep in _context.espacioDeportivos on Depacc.id_espdep equals espdep.id_espdep
                                   join acce in _context.accesorios on Depacc.id_acce equals acce.id_acce
                                   select new VMDeporacc
                                   {
                                      id_depacce = Depacc.id_depacce,
                                      id_espdep = Depacc.id_espdep,
                                      id_acce = Depacc.id_acce,
                                      espdep_desc = espdep.espdep_desc,
                                      acce_desc = acce.acce_desc,                                      
                                      depacce_fecingr = Depacc.depacce_fecingr,
                                      depacce_act = Depacc.depacce_act
                                   }).ToListAsync();
            return vmdepacc;
        }

        public void Save(DeportivoAccesorio oDeporacce)
        {
            _context.deportivoAccesorios.Add(oDeporacce);
            _context.SaveChanges();
        }

        public void Update(DeportivoAccesorio oDeporacce)
        {
            _context.deportivoAccesorios.Update(oDeporacce);
            _context.SaveChanges();
        }
      
    }
}
