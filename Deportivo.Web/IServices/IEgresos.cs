using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
	public interface IEgresos
	{
		Task<List<Egresos>> GetEgresos();
		void Save(Egresos oEgresos);
		void Update(Egresos oEgresos);
		string Delete(int id);
	}
}
