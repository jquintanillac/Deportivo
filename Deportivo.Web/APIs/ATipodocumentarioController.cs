using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATipodocumentarioController : ControllerBase
    {
        ITipoDocumento _tipodocumento;
        public  ATipodocumentarioController(ITipoDocumento tipodocumento)
        {
            _tipodocumento = tipodocumento;
        }
        // GET: api/<ATipodocumentarioController>
        [HttpGet]
        public async Task<IEnumerable<TipoDocumento>> Get()
        {
            return await _tipodocumento.Gettipodoc();
        }   

        // POST api/<ATipodocumentarioController>
        [HttpPost]
        public void Post([FromForm] TipoDocumento oTipdoc)
        {
            if (oTipdoc.id_tipdoc == 0)
            {
                _tipodocumento.Save(oTipdoc);
            }
            else
            {
                _tipodocumento.Update(oTipdoc);
            }
        }

        // DELETE api/<ATipodocumentarioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _tipodocumento.Delete(id);
        }
    }
}
