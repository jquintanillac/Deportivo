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
    public class AdicionalesController : Controller
    {
        private readonly DataContext _context;

        public AdicionalesController(DataContext context)
        {
            _context = context;
        }

        // GET: Adicionales
        public IActionResult Index()
        {
              return View();
        }

        private bool AdicionalesExists(int id)
        {
          return _context.adicionales.Any(e => e.id_adicio == id);
        }
    }
}
