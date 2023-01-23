using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATipodeportivoController : ControllerBase
    {
        ITipoDeportivo _Tipodeportivo;
        public ATipodeportivoController(ITipoDeportivo tipodeportivo)
        {
            _Tipodeportivo = tipodeportivo;
        }

        // GET: api/<ATipodeportivoController>
        [HttpGet]
        public async Task<IEnumerable<TipoDeportivo>> Get()
        {
            return await _Tipodeportivo.Gettipodep();
        }

        // POST api/<ATipodeportivoController>
        [HttpPost]
        public void Post([FromForm] TipoDeportivo oTipdep)
        {
            if(oTipdep.id_tipdep == 0)
            {
                _Tipodeportivo.Save(oTipdep);
            }
            else
            {
                _Tipodeportivo.Update(oTipdep);
            }
        }

        // DELETE api/<ATipodeportivoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _Tipodeportivo.Delete(id);
        }
    }
}
