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
        public async Task<IActionResult> Index()
        {
              return View(await _context.accesorios.ToListAsync());
        }

        // GET: Accesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.accesorios == null)
            {
                return NotFound();
            }

            var accesorios = await _context.accesorios
                .FirstOrDefaultAsync(m => m.id_acce == id);
            if (accesorios == null)
            {
                return NotFound();
            }

            return View(accesorios);
        }

        // GET: Accesorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accesorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Accesorios accesorios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesorios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accesorios);
        }

        // GET: Accesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.accesorios == null)
            {
                return NotFound();
            }

            var accesorios = await _context.accesorios.FindAsync(id);
            if (accesorios == null)
            {
                return NotFound();
            }
            return View(accesorios);
        }

        // POST: Accesorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Accesorios accesorios)
        {
            if (id != accesorios.id_acce)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesorios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesoriosExists(accesorios.id_acce))
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
            return View(accesorios);
        }

        // GET: Accesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.accesorios == null)
            {
                return NotFound();
            }

            var accesorios = await _context.accesorios
                .FirstOrDefaultAsync(m => m.id_acce == id);
            if (accesorios == null)
            {
                return NotFound();
            }

            _context.accesorios.Remove(accesorios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AccesoriosExists(int id)
        {
          return _context.accesorios.Any(e => e.id_acce == id);
        }
    }
}
