using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    internal class PagoCabeceraResponse
    {
        public int id_pagcab { get; set; }
        public int id_tipodoc { get; set; }
        public int id_client { get; set; }
        public string pagcab_descr { get; set; }
        public DateTime pagcab_feccrea { get; set; }
        public DateTime pagcab_fecemis { get; set; }
        public string pagcab_nro { get; set; }
        public string pagcab_obs { get; set; }
        public decimal pagcab_total { get; set; }
    }
}
