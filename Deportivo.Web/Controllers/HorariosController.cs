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
    public class HorariosController : Controller
    {
        private readonly DataContext _context;

        public HorariosController(DataContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public IActionResult Index()
        {
              return View();
        }
        private bool HorarioExists(int id)
        {
          return _context.horarios.Any(e => e.id_hordep == id);
        }
    }
}
