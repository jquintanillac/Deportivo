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
        public void Post([FromForm] Horario oHorario)
        {
            if (oHorario.id_hordep == 0)
            {
                _horarios.Save(oHorario);
            }
            else
            {
                _horarios.Update(oHorario);
            }
        }


        // DELETE api/<AHorariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
