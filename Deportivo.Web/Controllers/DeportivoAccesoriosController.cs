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
    public class DeportivoAccesoriosController : Controller
    {
        private readonly DataContext _context;

        public DeportivoAccesoriosController(DataContext context)
        {
            _context = context;
        }

        // GET: DeportivoAccesorios
        public async Task<IActionResult> Index()
        {
              return View(await _context.deportivoAccesorios.ToListAsync());
        }

        // GET: DeportivoAccesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.deportivoAccesorios == null)
            {
                return NotFound();
            }

            var deportivoAccesorio = await _context.deportivoAccesorios
                .FirstOrDefaultAsync(m => m.id_depacce == id);
            if (deportivoAccesorio == null)
            {
                return NotFound();
            }

            return View(deportivoAccesorio);
        }

        // GET: DeportivoAccesorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeportivoAccesorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_depacce,id_espdep,id_acce,depacce_fecingr,depacce_act")] DeportivoAccesorio deportivoAccesorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deportivoAccesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deportivoAccesorio);
        }

        // GET: DeportivoAccesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.deportivoAccesorios == null)
            {
                return NotFound();
            }

            var deportivoAccesorio = await _context.deportivoAccesorios.FindAsync(id);
            if (deportivoAccesorio == null)
            {
                return NotFound();
            }
            return View(deportivoAccesorio);
        }

        // POST: DeportivoAccesorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_depacce,id_espdep,id_acce,depacce_fecingr,depacce_act")] DeportivoAccesorio deportivoAccesorio)
        {
            if (id != deportivoAccesorio.id_depacce)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deportivoAccesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeportivoAccesorioExists(deportivoAccesorio.id_depacce))
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
            return View(deportivoAccesorio);
        }

        // GET: DeportivoAccesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.deportivoAccesorios == null)
            {
                return NotFound();
            }

            var deportivoAccesorio = await _context.deportivoAccesorios
                .FirstOrDefaultAsync(m => m.id_depacce == id);
            if (deportivoAccesorio == null)
            {
                return NotFound();
            }

            _context.deportivoAccesorios.Remove(deportivoAccesorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

  
        private bool DeportivoAccesorioExists(int id)
        {
          return _context.deportivoAccesorios.Any(e => e.id_depacce == id);
        }
    }
}
