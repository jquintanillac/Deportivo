using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{

    [Route("api/[controller]")]
    [ApiController]
    public class AClientesController : ControllerBase
    {
        ICliente _cliente;
        public AClientesController(ICliente cliente)
        {
            _cliente = cliente;
        }


        // GET: api/<AClientesController>
        [HttpGet]
        public async Task<IEnumerable<VMCliente>> Get()
        {
            return await _cliente.Getcliente();
        }

        // POST api/<AClientesController>
        [HttpPost]
        public void Post([FromForm] Cliente oCliente)
        {
            if(oCliente.id_client == 0)
            {
                _cliente.Save(oCliente);
            }
            else
            {
                _cliente.Update(oCliente);
            }

        }

 
        // DELETE api/<AClientesController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _cliente.Delete(id);
        }
    }
}
