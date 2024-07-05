using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class EspacioDeportivoResponse
    {
        public int id_espdep { get; set; }
        public int id_tipdep { get; set; }
        public string espdep_desc { get; set; }
        public DateTime espdep_fecha { get; set; }
        public bool espdep_act { get; set; }
    }
}
