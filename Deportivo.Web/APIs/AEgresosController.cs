using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
	[Route("api/[controller]")]
	[ApiController]
	public class AEgresosController : ControllerBase
	{
		IEgresos _egresos;
		public AEgresosController(IEgresos egresos)
		{
			_egresos = egresos;
		}
		// GET: api/<AEgresosController>
		[HttpGet]
		public async Task<IEnumerable<Egresos>> GetAll()
		{
			return await _egresos.GetEgresos();
		}

		// POST api/<AEgresosController>
		[HttpPost]
		public void Post([FromForm] Egresos oEgresos)
		{
			if(oEgresos.id_egre == 0)
			{
				_egresos.Save(oEgresos);
			}
			else
			{
				_egresos.Update(oEgresos);
			}
		}

		// DELETE api/<AEgresosController>/5
		[HttpDelete("{id}")]
		public string Delete(int id)
		{
			return _egresos.Delete(id);
		}
	}
}
