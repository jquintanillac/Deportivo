using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
	public class InicialServices : IInicial
	{
		private readonly DataContext _context;
		public InicialServices(DataContext context)
		{
			_context = context;
		}
		public string Delete(int id)
		{
			var inic = _context.iniciales.FirstOrDefault(x => x.id_ini == id);
			if (inic != null)
			{
				_context.iniciales.Remove(inic);
				_context.SaveChanges();
			}
			return "Deleted";
		}

		public async Task<List<Inicial>> Getinicio()
		{
			return await _context.iniciales.ToListAsync();
		}

		public void Save(Inicial oInicial)
		{
			_context.iniciales.Add(oInicial);
			_context.SaveChanges();
		}

		public void Update(Inicial oInicial)
		{
			_context.iniciales.Update(oInicial);
			_context.SaveChanges();
		}
	}
}
