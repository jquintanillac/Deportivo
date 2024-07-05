using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class InicialResponse
    {
        public int id_ini { get; set; }
        public string ini_desc { get; set; }
        public decimal ini_monto { get; set; }
        public DateTime ini_fecha { get; set; }
    }
}
