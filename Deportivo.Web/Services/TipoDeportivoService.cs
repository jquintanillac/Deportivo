using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class TipoDeportivoService : ITipoDeportivo
    {
        private readonly DataContext _context;
        public TipoDeportivoService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_tipdep)
        {
            var horarios = _context.tipoDeportivos.FirstOrDefault(x => x.id_tipdep == id_tipdep);
            if (horarios != null)
            {
                _context.tipoDeportivos.Remove(horarios);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public async Task<List<TipoDeportivo>> Gettipodep()
        {
            return await _context.tipoDeportivos.ToListAsync();
        }

        public void Save(TipoDeportivo oTipdepo)
        {
            _context.tipoDeportivos.Add(oTipdepo);
            _context.SaveChanges();
        }

        public void Update(TipoDeportivo oTipdepo)
        {
            _context.tipoDeportivos.Update(oTipdepo);
            _context.SaveChanges();
        }
    }
}
