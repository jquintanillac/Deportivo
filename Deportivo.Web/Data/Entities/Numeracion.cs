using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Numeracion")]
	public class Numeracion
	{
        [Key]
        public int id_nume { get; set; }
        public string nume_serie { get; set; }
        public string nume_numero { get; set; }
        public string nume_tipo { get; set; }
        public bool nume_act { get; set; }
    }
}
