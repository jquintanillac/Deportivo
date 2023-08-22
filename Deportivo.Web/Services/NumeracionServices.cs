using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
	public class NumeracionServices : INumeracion
	{
		private readonly DataContext _context;
		public NumeracionServices(DataContext context)
		{
			_context = context;
		}
		public string Delete(int id)
		{
			var acces = _context.numeraciones.FirstOrDefault(x => x.id_nume == id);
			if (acces != null)
			{
				_context.numeraciones.Remove(acces);
				_context.SaveChanges();
			}
			return "Deleted";
		}

		public async Task<List<Numeracion>> GetNumeracion()
		{
			return await _context.numeraciones.ToListAsync();
		}

		public void Save(Numeracion oNumeracion)
		{
			_context.numeraciones.Add(oNumeracion);
			_context.SaveChanges();
		}

		public void Update(Numeracion oNumeracion)
		{
			_context.numeraciones.Update(oNumeracion);
			_context.SaveChanges();
		}
	}
}
