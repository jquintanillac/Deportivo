using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class ClienteResponse
    {
        public int id_client { get; set; }
        public int id_tipdoc { get; set; }
        public string client_desc { get; set; }
        public string client_dociden { get; set; }
        public string client_tipdoc { get; set; }
        public string client_obser { get; set; }
        public string client_telf { get; set; }
        public string client_email { get; set; }
        public bool client_act { get; set; }
    }
}
