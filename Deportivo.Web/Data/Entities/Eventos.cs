using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
	[Table("Eventos")]
	public class Eventos
	{
		[Key]
		public int id { get; set; }
		public int id_horario { get; set; }
		public string title { get; set; }
		public string Description { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public string Location { get; set; }
	}
}
