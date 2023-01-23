using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AAdicionalesController : ControllerBase
    {
        IAdicionales _adicionales;
        public AAdicionalesController(IAdicionales adicionales)
        {
            _adicionales = adicionales;
        }

        // GET: api/<AAdicionalesController>
        [HttpGet]
        public async Task<IEnumerable<Adicionales>> Get()
        {
            return await _adicionales.GetAdicion();
        }


        // POST api/<AAdicionalesController>
        [HttpPost]
        public void Post([FromForm] Adicionales oAdicionales)
        {
            if (oAdicionales.id_adicio == 0)
            {
                _adicionales.Save(oAdicionales);
            }
            else
            {
                _adicionales.Update(oAdicionales);
            }

        }

        // DELETE api/<AAdicionalesController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _adicionales.Delete(id);
        }
    }
}
