using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Horario")]
    public class Horario
    {
        [Key]
        public int id_hordep { get; set; }
        public int id_espdep { get; set; }
        public int id_clien { get; set; }
        public string? hordep_desc { get; set; }
        public DateTime hordep_fecing { get; set; }
        public DateTime hordep_fecsal { get; set; }
        public string? hordep_obse { get; set; }

    }
}
