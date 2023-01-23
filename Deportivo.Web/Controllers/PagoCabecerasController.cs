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
    public class PagoCabecerasController : Controller
    {
        private readonly DataContext _context;

        public PagoCabecerasController(DataContext context)
        {
            _context = context;
        }

        // GET: PagoCabeceras
        public IActionResult Index()
        {
              return View();
        }

        private bool PagoCabeceraExists(int id)
        {
          return _context.pagoCabeceras.Any(e => e.id_pagcab == id);
        }
    }
}
