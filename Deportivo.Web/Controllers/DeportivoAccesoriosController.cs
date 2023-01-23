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
    public class DeportivoAccesoriosController : Controller
    {
        private readonly DataContext _context;

        public DeportivoAccesoriosController(DataContext context)
        {
            _context = context;
        }

        // GET: DeportivoAccesorios
        public async Task<IActionResult> Index()
        {
            ViewBag.espdep = await _context.espacioDeportivos.ToListAsync();
            ViewBag.acces = await _context.accesorios.ToListAsync();
              return View();
        }

        private bool DeportivoAccesorioExists(int id)
        {
          return _context.deportivoAccesorios.Any(e => e.id_depacce == id);
        }
    }
}
