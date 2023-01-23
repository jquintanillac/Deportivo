using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.Models
{
    public class VMPago : PagoDetalle
    {     
        public int id_tipodoc { get; set; }
        
        public int id_id_pagcab { get; set; }
    }
 

}
