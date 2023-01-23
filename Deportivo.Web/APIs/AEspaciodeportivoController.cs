using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AEspaciodeportivoController : ControllerBase
    {
        IEspacioDeportivo _espacios;
        public AEspaciodeportivoController(IEspacioDeportivo espacios)
        {
            _espacios = espacios;
        }

        // GET: api/<AEspaciodeportivoController>
        [HttpGet]
        public async Task<IEnumerable<EspacioDeportivo>> Get()
        {
            return await _espacios.GetEspadepor();
        }
  
        // POST api/<AEspaciodeportivoController>
        [HttpPost]
        public void Post([FromForm] EspacioDeportivo oEspadep)
        {
            if (oEspadep.id_espdep == 0)
            {
                _espacios.Save(oEspadep);
            }
            else
            {
                _espacios.Update(oEspadep);
            }
        }

        // DELETE api/<AEspaciodeportivoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _espacios.Delete(id);
        }
    }
}
