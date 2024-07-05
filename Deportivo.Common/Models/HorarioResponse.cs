using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class HorarioResponse
    {
        public int id_hordep { get; set; }
        public int id_espdep { get; set; }
        public int id_client { get; set; }
        public string client_desc { get; set; }
        public string espdep_desc { get; set; }
        public string hordep_desc { get; set; }
        public DateTime hordep_fecing { get; set; }
        public DateTime hordep_fecsal { get; set; }
        public string hordep_obse { get; set; } 
        public string hordep_tipo { get; set; }
               
    }
}
