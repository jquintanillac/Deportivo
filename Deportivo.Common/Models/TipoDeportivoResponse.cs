using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class TipoDeportivoResponse
    {
        public int id_tipdep { get; set; }
        public string tipdep_desc { get; set; }
        public bool tipdep_act { get; set; }
    }
}
