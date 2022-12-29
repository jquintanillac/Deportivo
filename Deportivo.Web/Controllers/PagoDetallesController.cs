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
    public class PagoDetallesController : Controller
    {
        private readonly DataContext _context;

        public PagoDetallesController(DataContext context)
        {
            _context = context;
        }

        // GET: PagoDetalles
        public async Task<IActionResult> Index()
        {
              return View(await _context.pagoDetalles.ToListAsync());
        }

        // GET: PagoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pagoDetalles == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.pagoDetalles
                .FirstOrDefaultAsync(m => m.id_pagdet == id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }

            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pagdet,id_pagcab,id_hordep,id_adicio,pagdet_monto,pagdet_unidad")] PagoDetalle pagoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pagoDetalles == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.pagoDetalles.FindAsync(id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }
            return View(pagoDetalle);
        }

        // POST: PagoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_pagdet,id_pagcab,id_hordep,id_adicio,pagdet_monto,pagdet_unidad")] PagoDetalle pagoDetalle)
        {
            if (id != pagoDetalle.id_pagdet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoDetalleExists(pagoDetalle.id_pagdet))
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
            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pagoDetalles == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.pagoDetalles
                .FirstOrDefaultAsync(m => m.id_pagdet == id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }
            _context.pagoDetalles.Remove(pagoDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoDetalleExists(int id)
        {
          return _context.pagoDetalles.Any(e => e.id_pagdet == id);
        }
    }
}
