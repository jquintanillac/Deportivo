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
    public class AdicionalesController : Controller
    {
        private readonly DataContext _context;

        public AdicionalesController(DataContext context)
        {
            _context = context;
        }

        // GET: Adicionales
        public async Task<IActionResult> Index()
        {
              return View(await _context.adicionales.ToListAsync());
        }

        // GET: Adicionales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.adicionales == null)
            {
                return NotFound();
            }

            var adicionales = await _context.adicionales
                .FirstOrDefaultAsync(m => m.id_adicio == id);
            if (adicionales == null)
            {
                return NotFound();
            }

            return View(adicionales);
        }

        // GET: Adicionales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adicionales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adicionales adicionales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adicionales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adicionales);
        }

        // GET: Adicionales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.adicionales == null)
            {
                return NotFound();
            }

            var adicionales = await _context.adicionales.FindAsync(id);
            if (adicionales == null)
            {
                return NotFound();
            }
            return View(adicionales);
        }

        // POST: Adicionales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Adicionales adicionales)
        {
            if (id != adicionales.id_adicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adicionales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdicionalesExists(adicionales.id_adicio))
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
            return View(adicionales);
        }

        // GET: Adicionales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.adicionales == null)
            {
                return NotFound();
            }

            var adicionales = await _context.adicionales
                .FirstOrDefaultAsync(m => m.id_adicio == id);
            if (adicionales == null)
            {
                return NotFound();
            }
            _context.adicionales.Remove(adicionales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool AdicionalesExists(int id)
        {
          return _context.adicionales.Any(e => e.id_adicio == id);
        }
    }
}
