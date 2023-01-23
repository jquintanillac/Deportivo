using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Deportivo_Accesorio")]
    public class DeportivoAccesorio
    {
        [Key]
        public int id_depacce { get; set; }
        public int id_espdep { get; set; }
        public int id_acce { get; set; }
        public DateTime depacce_fecingr { get; set; }
        public bool depacce_act { get; set; }     

    }
}
