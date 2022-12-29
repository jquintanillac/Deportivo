using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Accesorios")]
    public class Accesorios
    {
        [Key]
        public int id_acce { get; set; }
        public string? acce_desc { get; set; }
        public string? acce_obs { get; set; }
        public bool acce_act { get; set; }
        public DateTime acce_fecing { get; set; }
        public DeportivoAccesorio? DeportivoAccesorio { get; set; }
    }
}
