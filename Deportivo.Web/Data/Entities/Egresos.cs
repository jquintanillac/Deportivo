using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
	[Table("Egresos")]
	public class Egresos
	{
		[Key]
		public int id_egre { get; set; }		
		public string egre_descr { get; set; }		
		public decimal egre_costo { get; set; }		
		public DateTime egre_fecha { get; set; }
	}
}
