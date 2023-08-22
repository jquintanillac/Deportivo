using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
	[Route("api/[controller]")]
	[ApiController]
	public class AInicialController : ControllerBase
	{
		IInicial _inicial;
		public AInicialController(IInicial inicial)
		{
			_inicial = inicial;
		}
		// GET: api/<AInicialController>
		[HttpGet]
		public async Task<IEnumerable<Inicial>> GetAll()
		{
			return await _inicial.Getinicio();
		}	

		// POST api/<AInicialController>
		[HttpPost]
		public void Post([FromForm] Inicial oInicial)
		{
			if(oInicial.id_ini == 0)
			{
				_inicial.Save(oInicial);
			}
			else
			{
				_inicial.Update(oInicial);
			}
		}

		// DELETE api/<AInicialController>/5
		[HttpDelete("{id}")]
		public string Delete(int id)
		{
			return _inicial.Delete(id);	
		}
	}
}
