using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class APagosController : ControllerBase
    {
		IPagoCabecera _pagoCabecera;

		public APagosController(IPagoCabecera pagoCabecera)
		{
			_pagoCabecera = pagoCabecera;
		}
		// GET: api/<APagosController>
		[HttpGet]
        public async Task<IEnumerable<GetPago>> GetAll()
        {
            return await _pagoCabecera.Getpago();                 
        }
     
      
        // DELETE api/<APagosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _pagoCabecera.Delete(id);
        }
    }
}
