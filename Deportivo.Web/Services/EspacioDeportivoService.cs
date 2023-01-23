using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class EspacioDeportivoService : IEspacioDeportivo
    {
        private readonly DataContext _context;
        public EspacioDeportivoService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_espdep)
        {
            var espadep = _context.espacioDeportivos.FirstOrDefault(x => x.id_espdep == id_espdep);
            if (espadep != null)
            {
                _context.espacioDeportivos.Remove(espadep);
                _context.SaveChanges();
            }
            return "Deleted";
        }
        async Task<List<VMEspDepor>> IEspacioDeportivo.GetEspadepor()
        {
            var vmespdep = await (from espdep in _context.espacioDeportivos
                                   join tipdep in _context.tipoDeportivos on espdep.id_tipdep equals tipdep.id_tipdep
                                   select new VMEspDepor
                                   {
                                       id_espdep = espdep.id_espdep,
                                       id_tipdep = espdep.id_tipdep,
                                       tipdep_desc = tipdep.tipdep_desc,
                                       espdep_desc = espdep.espdep_desc,
                                       espdep_fecha = espdep.espdep_fecha,
                                       espdep_act = espdep.espdep_act
                                   }).ToListAsync();
            return vmespdep;
        }

        public void Save(EspacioDeportivo oEspadepor)
        {
            _context.espacioDeportivos.Add(oEspadepor);
            _context.SaveChanges();
        }

        public void Update(EspacioDeportivo oEspadepor)
        {
            _context.espacioDeportivos.Update(oEspadepor);
            _context.SaveChanges();
        }

   
    }
}
