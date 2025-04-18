﻿using System;
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
    public class PagoDetallesController : Controller
    {
        private readonly DataContext _context;

        public PagoDetallesController(DataContext context)
        {
            _context = context;
        }

        // GET: PagoDetalles
        public IActionResult Index()
        {
              return View();
        }

        private bool PagoDetalleExists(int id)
        {
          return _context.pagoDetalles.Any(e => e.id_pagdet == id);
        }
    }
}
