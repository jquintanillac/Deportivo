using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class AdicionalesService : IAdicionales
    {
        private readonly DataContext _context;
        public AdicionalesService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_adicio)
        {
            var adic = _context.adicionales.FirstOrDefault(x => x.id_adicio == id_adicio);
            if (adic != null)
            {
                _context.adicionales.Remove(adic);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public async Task<List<Adicionales>> GetAdicion()
        {
            return await _context.adicionales.ToListAsync();
        }

        public void Save(Adicionales oAdcional)
        {
            _context.adicionales.Add(oAdcional);
            _context.SaveChanges();
        }

        public void Update(Adicionales oAdcional)
        {
            _context.adicionales.Update(oAdcional);
            _context.SaveChanges();
        }
    }
}
