using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class NumeracionResponse
    {
        public int id_nume { get; set; }
        public string nume_serie { get; set; }
        public string nume_numero { get; set; }
        public string nume_tipo { get; set; }
        public bool nume_act { get; set; }
    }
}
