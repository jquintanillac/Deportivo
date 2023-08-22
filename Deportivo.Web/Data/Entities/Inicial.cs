using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
	[Table("Inicial")]
	public class Inicial
	{
		[Key]
		public int id_ini { get; set; }		
		public string ini_desc { get; set; }		
		public decimal ini_monto { get; set; }		
		public DateTime ini_fecha { get; set; }
	}
}
