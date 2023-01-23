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
    public class TipoDocumentosController : Controller
    {
        private readonly DataContext _context;

        public TipoDocumentosController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDocumentos
        public IActionResult Index()
        {
              return View();
        }

        private bool TipoDocumentoExists(int id)
        {
          return _context.tipoDocumentos.Any(e => e.id_tipdoc == id);
        }
    }
}
