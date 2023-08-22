using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
	[Route("api/[controller]")]
	[ApiController]
	public class ANumeracionController : ControllerBase
	{
		INumeracion _numeracion;
		public ANumeracionController(INumeracion numeracion)
		{
			_numeracion = numeracion;
		}
		// GET: api/<ANumeracionController>
		[HttpGet]
		public async Task<IEnumerable<Numeracion>> GetAll()
		{
			return await _numeracion.GetNumeracion();
		}

	    // POST api/<ANumeracionController>
		[HttpPost]
		public void Post([FromForm] Numeracion oNumero)
		{
			if (oNumero.id_nume == 0)
			{
				_numeracion.Save(oNumero);
			}
			else
			{
				_numeracion.Update(oNumero);
			}
		}

		// DELETE api/<ANumeracionController>/5
		[HttpDelete("{id}")]
		public string Delete(int id)
		{
			return _numeracion.Delete(id);			
		}
	}
}
