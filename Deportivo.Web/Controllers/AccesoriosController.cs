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
    public class AccesoriosController : Controller
    {
        private readonly DataContext _context;

        public AccesoriosController(DataContext context)
        {
            _context = context;
        }

        // GET: Accesorios
        public IActionResult Index()
        {
              return View();
        }

    
        private bool AccesoriosExists(int id)
        {
          return _context.accesorios.Any(e => e.id_acce == id);
        }
    }
}
