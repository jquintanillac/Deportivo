using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.Models
{
	public class VMPagCab
	{
		//public VMPagCab()
		//{
		//	PagoDetalles = new HashSet<VMPagdet>();
		//}
		public int id_pagcab { get; set; }
		public int id_tipodoc { get; set; }
		public int id_client { get; set; }
		public string? pagcab_descr { get; set; }
		public DateTime pagcab_fecemis { get; set; }
		public string? pagcab_nro { get; set; }
		public string? pagcab_obs { get; set; }
		public decimal pagcab_total { get; set; }
		public List<VMPagdet> PagoDetalles { get; set; }
	}
}
