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
        public async Task<IActionResult> Index()
        {
              return View(await _context.pagoCabeceras.ToListAsync());
        }

        // GET: PagoCabeceras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pagoCabeceras == null)
            {
                return NotFound();
            }

            var pagoCabecera = await _context.pagoCabeceras
                .FirstOrDefaultAsync(m => m.id_pagcab == id);
            if (pagoCabecera == null)
            {
                return NotFound();
            }

            return View(pagoCabecera);
        }

        // GET: PagoCabeceras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagoCabeceras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pagcab,id_tipodoc,pagcab_descr,pagcab_feccrea,pagcab_fecemis,pagcab_nro,pagcab_obs,pagcab_total,pagcab_est")] PagoCabecera pagoCabecera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagoCabecera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagoCabecera);
        }

        // GET: PagoCabeceras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pagoCabeceras == null)
            {
                return NotFound();
            }

            var pagoCabecera = await _context.pagoCabeceras.FindAsync(id);
            if (pagoCabecera == null)
            {
                return NotFound();
            }
            return View(pagoCabecera);
        }

        // POST: PagoCabeceras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_pagcab,id_tipodoc,pagcab_descr,pagcab_feccrea,pagcab_fecemis,pagcab_nro,pagcab_obs,pagcab_total,pagcab_est")] PagoCabecera pagoCabecera)
        {
            if (id != pagoCabecera.id_pagcab)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagoCabecera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoCabeceraExists(pagoCabecera.id_pagcab))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pagoCabecera);
        }

        // GET: PagoCabeceras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pagoCabeceras == null)
            {
                return NotFound();
            }

            var pagoCabecera = await _context.pagoCabeceras
                .FirstOrDefaultAsync(m => m.id_pagcab == id);
            if (pagoCabecera == null)
            {
                return NotFound();
            }
            _context.pagoCabeceras.Remove(pagoCabecera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
  

        private bool PagoCabeceraExists(int id)
        {
          return _context.pagoCabeceras.Any(e => e.id_pagcab == id);
        }
    }
}
