using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class TipoDocumentoResponse
    {
        public int id_tipdoc { get; set; }
        public string tipdoc_desc { get; set; }
        public string tipodoc_tipo { get; set; }
        public bool tipdoc_act { get; set; }
    }
}
