using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;

namespace Deportivo.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        // GET: Clientes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.tipodoc = await _context.tipoDocumentos.ToListAsync();
            return View();
        }
      
        private bool ClienteExists(int id)
        {
          return _context.clientes.Any(e => e.id_client == id);
        }
    }
}
