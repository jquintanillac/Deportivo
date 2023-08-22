using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Tipo_Documento")]
    public class TipoDocumento
    {
        [Key]
        public int id_tipdoc { get; set; }
        public string? tipdoc_desc { get; set; }
        public string? tipodoc_tipo { get; set; }
        public bool tipdoc_act { get; set; }       

    }
}
