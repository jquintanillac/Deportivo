using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Deportivo.Web.Services
{
	public class EgresosServices : IEgresos
	{
		private readonly DataContext _context;
		public EgresosServices(DataContext context)
		{
			_context = context;
		}
		public string Delete(int id)
		{
			var egre = _context.egresos.FirstOrDefault(x => x.id_egre == id);
			if (egre != null)
			{
				_context.egresos.Remove(egre);
				_context.SaveChanges();
			}
			return "Deleted";
		}

		public async Task<List<Egresos>> GetEgresos()
		{
			return await _context.egresos.ToListAsync();
		}

		public void Save(Egresos oEgresos)
		{
			_context.egresos.Add(oEgresos);
			_context.SaveChanges();
		}

		public void Update(Egresos oEgresos)
		{
			_context.Update(oEgresos);
			_context.SaveChanges();
		}
	}
}
