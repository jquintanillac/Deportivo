using Deportivo.Web.Data.Entities;
using NuGet.Protocol.Core.Types;

namespace Deportivo.Web.Models
{
    public class VMPago
    {
		// public VMPagCab oPagocab { get; set; }
		public int id_pagcab { get; set; }
		public int id_tipodoc { get; set; }
		public int id_client { get; set; }
		public string pagcab_descr { get; set; }
		public DateTime pagcab_fecemis { get; set; }
		public string pagcab_nro { get; set; }
		public string pagcab_obs { get; set; }
		public decimal pagcab_total { get; set; }
		public List<VMPagdet> oPagoDet { get; set; }
    }
 
}
