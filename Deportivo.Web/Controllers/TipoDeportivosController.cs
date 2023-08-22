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
    public class TipoDeportivosController : Controller
    {
        private readonly DataContext _context;

        public TipoDeportivosController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDeportivos
        public IActionResult Index()
        {
              return View();
        }


        private bool TipoDeportivoExists(int id)
        {
          return _context.tipoDeportivos.Any(e => e.id_tipdep == id);
        }
    }
}
