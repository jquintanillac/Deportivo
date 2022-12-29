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
    public class EspacioDeportivoController : Controller
    {
        private readonly DataContext _context;

        public EspacioDeportivoController(DataContext context)
        {
            _context = context;
        }

        // GET: EspacioDeportivo
        public async Task<IActionResult> Index()
        {
              return View(await _context.espacioDeportivos.ToListAsync());
        }

        // GET: EspacioDeportivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.espacioDeportivos == null)
            {
                return NotFound();
            }

            var espacioDeportivo = await _context.espacioDeportivos
                .FirstOrDefaultAsync(m => m.id_espdep == id);
            if (espacioDeportivo == null)
            {
                return NotFound();
            }

            return View(espacioDeportivo);
        }

        // GET: EspacioDeportivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspacioDeportivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_espdep,espdep_tipo,espdep_cod,espdep_desc,espdep_fecha,espdep_act")] EspacioDeportivo espacioDeportivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espacioDeportivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(espacioDeportivo);
        }

        // GET: EspacioDeportivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.espacioDeportivos == null)
            {
                return NotFound();
            }

            var espacioDeportivo = await _context.espacioDeportivos.FindAsync(id);
            if (espacioDeportivo == null)
            {
                return NotFound();
            }
            return View(espacioDeportivo);
        }

        // POST: EspacioDeportivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_espdep,espdep_tipo,espdep_cod,espdep_desc,espdep_fecha,espdep_act")] EspacioDeportivo espacioDeportivo)
        {
            if (id != espacioDeportivo.id_espdep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espacioDeportivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspacioDeportivoExists(espacioDeportivo.id_espdep))
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
            return View(espacioDeportivo);
        }

        // GET: EspacioDeportivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.espacioDeportivos == null)
            {
                return NotFound();
            }

            var espacioDeportivo = await _context.espacioDeportivos
                .FirstOrDefaultAsync(m => m.id_espdep == id);
            if (espacioDeportivo == null)
            {
                return NotFound();
            }
            _context.espacioDeportivos.Remove(espacioDeportivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

  
        private bool EspacioDeportivoExists(int id)
        {
          return _context.espacioDeportivos.Any(e => e.id_espdep == id);
        }
    }
}
