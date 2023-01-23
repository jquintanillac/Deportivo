using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class AccesoriosService : IAccesorios
    {
        private readonly DataContext _context;
        public AccesoriosService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_acce)
        {
            var acces = _context.accesorios.FirstOrDefault(x => x.id_acce == id_acce);
            if (acces != null)
            {
                _context.accesorios.Remove(acces);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public async Task<List<Accesorios>> GetAccesorio()
        {
            return await _context.accesorios.ToListAsync();
        }

        public void Save(Accesorios oAccesorio)
        {
            _context.accesorios.Add(oAccesorio);
            _context.SaveChanges();
        }

        public void Update(Accesorios oAccesorio)
        {
            _context.accesorios.Update(oAccesorio);
            _context.SaveChanges();
        }

      
    }
}
