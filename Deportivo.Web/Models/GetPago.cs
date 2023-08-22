namespace Deportivo.Web.Models
{
	public class GetPago
	{
		public int id_pagcab { get; set; }
        public string client_desc { get; set; }
        public string pagcab_nro { get; set; }
        public DateTime pagcab_fecemis { get; set; }
        public decimal pagcab_total { get; set; }

        
	}
}
