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
using System.Data;

namespace Deportivo.Web.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class EspacioDeportivoController : Controller
    {
        private readonly DataContext _context;

        public EspacioDeportivoController(DataContext context)
        {
            _context = context;
        }

        // GET: EspacioDeportivo
        public async Task<IActionResult> Index()
        {
              ViewBag.tipdep = await _context.tipoDeportivos.Where(x => x.tipdep_act == true).ToListAsync();
              return View();
        }

        private bool EspacioDeportivoExists(int id)
        {
          return _context.espacioDeportivos.Any(e => e.id_espdep == id);
        }
    }
}
