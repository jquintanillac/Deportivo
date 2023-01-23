using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AAccesoriosController : ControllerBase
    {
        IAccesorios _accesorios;

        public AAccesoriosController(IAccesorios accesorios)
        {
            _accesorios = accesorios;
        }

        // GET: api/<AAccesoriosController>
        [HttpGet]
        public async Task<IEnumerable<Accesorios>> Getall()
        {
            return await _accesorios.GetAccesorio();
        }

 
        // POST api/<AAccesoriosController>
        [HttpPost]
        public void Post([FromForm] Accesorios oAccesorio)
        {
            if(oAccesorio.id_acce == 0)
            {
                _accesorios.Save(oAccesorio);
            }
            else
            {
                _accesorios.Update(oAccesorio);
            }
        }
   

        // DELETE api/<AAccesoriosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _accesorios.Delete(id);
        }
    }
}
