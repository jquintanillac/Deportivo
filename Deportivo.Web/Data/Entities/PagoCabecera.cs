using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deportivo.Web.Data.Entities
{
    [Table("Pago_Cabecera")]
    public class PagoCabecera
    {
        [Key]
        public int id_pagcab { get; set; }
        public int id_tipodoc { get; set; }
        public string? pagcab_descr { get; set; }
        public DateTime pagcab_feccrea { get; set; }
        public DateTime pagcab_fecemis { get; set; }
        public string? pagcab_nro { get; set; }
        public string? pagcab_obs { get; set; }
        public decimal pagcab_total { get; set; }
        public string? pagcab_est { get; set; }
    }
}
