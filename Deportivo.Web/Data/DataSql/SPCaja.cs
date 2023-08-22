using Deportivo.Web.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Deportivo.Web.Data.DataSql
{
	public class SPCaja
	{
		public SqlConnection conex;

		public SPCaja()
		{
			var config = GetConfiguration();
			conex = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
		}
		public IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			return builder.Build();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<List<VMCaja>> mReporteQ01(DateTime fecini, DateTime fecfin)
		{
			try
			{
				List<VMCaja> LstCajaQ01 = new List<VMCaja>();
				SqlCommand cmd = new SqlCommand("[dbo].[SP_CAJA_Q01]", conex);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FECINI", fecini);
				cmd.Parameters.AddWithValue("@FECFIN", fecfin);
				conex.Open();
				SqlDataReader rdr = await cmd.ExecuteReaderAsync();
				while (rdr.Read())
				{
					VMCaja objCaja01 = new VMCaja();
					objCaja01.FECINI = rdr["FECINI"].ToString();
					objCaja01.FECFIN = rdr["FECFIN"].ToString();
					objCaja01.EGRESOS = Convert.ToDecimal(rdr["EGRESOS"]);
					objCaja01.INICIAL = Convert.ToDecimal(rdr["INICIAL"]);
					objCaja01.CANC_CANT = Convert.ToDecimal(rdr["CANC_CANT"]);
					objCaja01.CANC_DETA = Convert.ToInt32(rdr["CANC_DETA"]);
					objCaja01.ADIC_CANT = Convert.ToDecimal(rdr["ADIC_CANT"]);
					objCaja01.ADIC_DETA = Convert.ToDecimal(rdr["ADIC_DETA"]);
					objCaja01.CAJA_MONTO = Convert.ToDecimal(rdr["CAJA_MONTO"]);
					LstCajaQ01.Add(objCaja01);
				}
				conex.Close();
				return LstCajaQ01;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}
}
