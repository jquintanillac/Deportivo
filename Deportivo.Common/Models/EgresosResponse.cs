using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class EgresosResponse
    {
        public int id_egre { get; set; }
        public string egre_descr { get; set; }
        public decimal egre_costo { get; set; }
        public DateTime egre_fecha { get; set; }

    }
}
