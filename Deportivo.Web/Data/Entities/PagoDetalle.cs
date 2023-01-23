using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Pago_Detalle")]
    public class PagoDetalle
    {
        [Key]
        public int id_pagdet { get; set; }
        public int id_pagcab { get; set; }
        public int id_hordep { get; set; }
        public int id_adicio { get; set; }
        public decimal pagdet_monto { get; set; }
        public int pagdet_unidad { get; set; }     
    }
}
