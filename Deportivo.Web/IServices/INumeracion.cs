using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.IServices
{
	public interface INumeracion
	{
		Task<List<Numeracion>> GetNumeracion();
		void Save(Numeracion oNumeracion);
		void Update(Numeracion oNumeracion);
		string Delete(int id);
	}
}
