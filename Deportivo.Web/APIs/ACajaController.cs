using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
	[Route("api/[controller]")]
	[ApiController]
	public class ACajaController : ControllerBase
	{
		ICaja _caja;
		public ACajaController(ICaja caja)
		{
			_caja = caja;
		}
		// GET: api/<ACajaController>
		[HttpGet]
		public async Task<IEnumerable<VMCaja>> GetAll(DateTime fecini, DateTime fecfin)
		{
			DateTime fecha1 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			DateTime fecha2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");

			if (fecini == DateTime.MinValue && fecfin == DateTime.MinValue)
			{
				fecini = fecha1;
				fecfin = fecha2;
			}
			return await _caja.Getcaja(fecini, fecfin);
		}


	}
}
