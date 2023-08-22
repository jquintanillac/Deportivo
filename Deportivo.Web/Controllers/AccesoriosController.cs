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
   // [Authorize(Roles = "Admin" )]
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
