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
    public class TipoDocumentosController : Controller
    {
        private readonly DataContext _context;

        public TipoDocumentosController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDocumentos
        public async Task<IActionResult> Index()
        {
              return View(await _context.tipoDocumentos.ToListAsync());
        }

        // GET: TipoDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.tipoDocumentos
                .FirstOrDefaultAsync(m => m.id_tipdoc == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipdoc,tipdoc_desc,tipdoc_act")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.tipoDocumentos.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipdoc,tipdoc_desc,tipdoc_act")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.id_tipdoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.id_tipdoc))
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
            return View(tipoDocumento);
        }

        // GET: TipoDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.tipoDocumentos
                .FirstOrDefaultAsync(m => m.id_tipdoc == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            _context.tipoDocumentos.Remove(tipoDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    
        private bool TipoDocumentoExists(int id)
        {
          return _context.tipoDocumentos.Any(e => e.id_tipdoc == id);
        }
    }
}
