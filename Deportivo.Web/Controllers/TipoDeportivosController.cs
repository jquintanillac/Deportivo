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
    public class TipoDeportivosController : Controller
    {
        private readonly DataContext _context;

        public TipoDeportivosController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDeportivos
        public async Task<IActionResult> Index()
        {
              return View(await _context.tipoDeportivos.ToListAsync());
        }

        // GET: TipoDeportivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipoDeportivos == null)
            {
                return NotFound();
            }

            var tipoDeportivo = await _context.tipoDeportivos
                .FirstOrDefaultAsync(m => m.id_tipdep == id);
            if (tipoDeportivo == null)
            {
                return NotFound();
            }

            return View(tipoDeportivo);
        }

        // GET: TipoDeportivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeportivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipdep,tipdep_desc,tipdep_act")] TipoDeportivo tipoDeportivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeportivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeportivo);
        }

        // GET: TipoDeportivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipoDeportivos == null)
            {
                return NotFound();
            }

            var tipoDeportivo = await _context.tipoDeportivos.FindAsync(id);
            if (tipoDeportivo == null)
            {
                return NotFound();
            }
            return View(tipoDeportivo);
        }

        // POST: TipoDeportivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipdep,tipdep_desc,tipdep_act")] TipoDeportivo tipoDeportivo)
        {
            if (id != tipoDeportivo.id_tipdep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeportivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeportivoExists(tipoDeportivo.id_tipdep))
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
            return View(tipoDeportivo);
        }

        // GET: TipoDeportivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipoDeportivos == null)
            {
                return NotFound();
            }

            var tipoDeportivo = await _context.tipoDeportivos
                .FirstOrDefaultAsync(m => m.id_tipdep == id);
            if (tipoDeportivo == null)
            {
                return NotFound();
            }

            _context.tipoDeportivos.Remove(tipoDeportivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeportivoExists(int id)
        {
          return _context.tipoDeportivos.Any(e => e.id_tipdep == id);
        }
    }
}
