using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AHorariosController : ControllerBase
    {
        IHorario _horarios;
        public AHorariosController(IHorario horarios)
        {
            _horarios = horarios;
        }

        // GET: api/<AHorariosController>
        [HttpGet]
        public async Task<IEnumerable<Horario>> Get()
        {
            return await _horarios.GetHorario();
        }

   
        // POST api/<AHorariosController>
        [HttpPost]
        public string Post([FromForm] Horario oHorario)
        {
            string result;
            if (oHorario.id_hordep == 0)
            {
              result = _horarios.Save(oHorario);
            }
            else
            {
              result = _horarios.Update(oHorario);
            }

            return result;
        }


        // DELETE api/<AHorariosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _horarios.Delete(id);

        }
    }
}
