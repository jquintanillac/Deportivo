using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deportivo.Common.Models
{
    public class EventosResponse
    {
        public int id { get; set; }
        public int id_horario { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string Location { get; set; }
    }
}
