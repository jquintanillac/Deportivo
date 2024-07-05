using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Tipo_Deportivo")]
    public class TipoDeportivo
    {
        [Key]
        public int id_tipdep { get; set; }
        public string tipdep_desc { get; set; }
        public bool tipdep_act { get; set; }       
    }
}
