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
    public class HorariosController : Controller
    {
        private readonly DataContext _context;

        public HorariosController(DataContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.horarios.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.horarios
                .FirstOrDefaultAsync(m => m.id_hordep == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_hordep,id_espdep,id_clien,hordep_desc,hordep_fecing,hordep_fecsal,hordep_obse")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_hordep,id_espdep,id_clien,hordep_desc,hordep_fecing,hordep_fecsal,hordep_obse")] Horario horario)
        {
            if (id != horario.id_hordep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.id_hordep))
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
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.horarios
                .FirstOrDefaultAsync(m => m.id_hordep == id);
            if (horario == null)
            {
                return NotFound();
            }
            _context.horarios.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

  
        private bool HorarioExists(int id)
        {
          return _context.horarios.Any(e => e.id_hordep == id);
        }
    }
}
