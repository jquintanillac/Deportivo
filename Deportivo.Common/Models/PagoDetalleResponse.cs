using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class PagoDetalleResponse
    {
        public int id_pagdet { get; set; }
        public int id_pagcab { get; set; }
        public int id_hordep { get; set; }
        public int id_adicio { get; set; }
        public decimal? pagdet_monto { get; set; }
        public int? pagdet_unidad { get; set; }
        public decimal? pagdet_total { get; set; }
    }
}
