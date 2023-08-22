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
    public class HorariosController : Controller
    {
        private readonly DataContext _context;

        public HorariosController(DataContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            ViewBag.espdepor = await _context.espacioDeportivos.Where(x => x.espdep_act == true).ToListAsync();
            ViewBag.cliente = await _context.clientes.Where(x => x.client_act == true).ToListAsync();
            return View();
        }

		public IActionResult Calendar()
		{			
			return View();
		}

		private bool HorarioExists(int id)
        {
          return _context.horarios.Any(e => e.id_hordep == id);
        }
    }
}
