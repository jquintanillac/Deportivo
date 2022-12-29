using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Espacio_Deportivo")]
    public class EspacioDeportivo
    {
        [Key]
        public int id_espdep { get; set; }
        // public int id_tipdep { get; set; }
        public string? id_tipdep { get; set; }
        public string? espdep_desc { get; set; }
        public DateTime espdep_fecha { get; set; }
        public bool espdep_act { get; set; }
        public ICollection<TipoDeportivo>? TipoDeportivos { get; set; }
        public DeportivoAccesorio? DeportivoAccesorio{ get; set; }
        public Horario? Horario { get; set; }
       

    }
}
