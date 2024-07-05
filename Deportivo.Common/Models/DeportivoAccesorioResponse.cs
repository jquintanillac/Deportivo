using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class DeportivoAccesorioResponse
    {
        public int id_depacce { get; set; }
        public int id_espdep { get; set; }
        public int id_acce { get; set; }
        public DateTime depacce_fecingr { get; set; }
        public bool depacce_act { get; set; }
    }
}
