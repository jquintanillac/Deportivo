using Deportivo.Web.Data;
using Deportivo.Web.Data.DataSql;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
	public class CajaServices : ICaja
	{
		private readonly DataContext _context;
		private readonly SPCaja _cajas;
		public CajaServices(DataContext context)
		{
			_context = context;
			_cajas = new SPCaja();
		}
		public async Task<List<VMCaja>> Getcaja(DateTime fecini, DateTime fecfin)
		{
			DateTime fecha1 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			DateTime fecha2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			if (fecini == DateTime.MinValue && fecfin == DateTime.MinValue)
			{
				fecini = fecha1;
				fecfin = fecha2;
			}
			List<VMCaja> lstCaja = new List<VMCaja>();
			lstCaja = await _cajas.mReporteQ01(fecini, fecfin);
			return lstCaja;
		}
	}
}
