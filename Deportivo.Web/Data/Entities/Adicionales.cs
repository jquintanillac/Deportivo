using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Adicionales")]
    public class Adicionales
    {
        [Key]
        public int id_adicio { get; set; }
        public string? adicio_desc { get; set; }
        public bool adicio_est { get; set; }
        public PagoDetalle? PagoDetalle { get; set; }
    }
}
