using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.Models
{
	public class VMPagdet
	{
		public int? id_hordep { get; set; }
		public int? id_adicio { get; set; }
		public decimal? pagdet_monto { get; set; }
		public int? pagdet_unidad { get; set; }
		public decimal? pagdet_total { get; set; }

	}
}
