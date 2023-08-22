using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
	public interface ICaja
	{
		Task<List<VMCaja>> Getcaja(DateTime fecini, DateTime fecfin);
	}
}
