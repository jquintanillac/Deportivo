using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Deportivo.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
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
            ViewBag.espdep = await _context.espacioDeportivos.Where(x => x.espdep_act == true).ToListAsync();
            ViewBag.acces = await _context.accesorios.Where(x => x.acce_act == true).ToListAsync();
              return View();
        }

        private bool DeportivoAccesorioExists(int id)
        {
          return _context.deportivoAccesorios.Any(e => e.id_depacce == id);
        }
    }
}
