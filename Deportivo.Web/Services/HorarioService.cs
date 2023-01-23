using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class HorarioService : IHorario
    {
        private readonly DataContext _context;
        public HorarioService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_hordep)
        {
            var horarios = _context.horarios.FirstOrDefault(x => x.id_hordep == id_hordep);
            if (horarios != null)
            {
                _context.horarios.Remove(horarios);
                _context.SaveChanges();
            }
            return "Deleted";
        }
        public async Task<List<Horario>> GetHorario()
        {
            return await _context.horarios.ToListAsync();
        }
        public void Save(Horario oHorario)
        {
            _context.horarios.Add(oHorario);
            _context.SaveChanges();
        }

        public void Update(Horario oHorario)
        {
            _context.horarios.Update(oHorario);
            _context.SaveChanges();
        }
 
    }
}
