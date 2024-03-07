namespace Deportivo.Web.Models
{
    public class VMGrbHorario
    {
        public int id_espdep { get; set; }
        public int id_client { get; set; }
        public string hordep_desc { get; set; }
        public string hordep_obse { get; set; }
        public string hordep_tipo { get; set; }
        public DateTime hordep_fecing { get; set; }
        public DateTime hordep_fecsal { get; set; }
    }
}
