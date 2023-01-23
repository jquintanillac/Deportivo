using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADeportivoaccesorioController : ControllerBase
    {
        IDeportivoAccesorio _deportivoaccesorio;
        public ADeportivoaccesorioController(IDeportivoAccesorio deportivoaccesorio)
        {
            _deportivoaccesorio = deportivoaccesorio;
        }

        // GET: api/<ADeportivoaccesorioController>
        [HttpGet]
        public async Task<IEnumerable<DeportivoAccesorio>> Get()
        {
            return await _deportivoaccesorio.GetDeporacce();
        }

        // POST api/<ADeportivoaccesorioController>
        [HttpPost]
        public void Post([FromForm] DeportivoAccesorio oDepoacc)
        {
            if (oDepoacc.id_depacce == 0)
            {
                _deportivoaccesorio.Save(oDepoacc);
            }
            else
            {
                _deportivoaccesorio.Update(oDepoacc);
            }
        }

        // DELETE api/<ADeportivoaccesorioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _deportivoaccesorio.Delete(id);
        }
    }
}
