using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
	public interface IInicial
	{
		Task<List<Inicial>> Getinicio();
		void Save(Inicial oInicial);
		void Update(Inicial oInicial);
		string Delete(int id);
	}
}
