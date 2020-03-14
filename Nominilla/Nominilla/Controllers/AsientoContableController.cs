using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nominilla.Data;

namespace Nominilla.Controllers
{
    public class AsientoContableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsientoContableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AsientoContable
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AsientoContables.Include(a => a.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AsientoContable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // GET: AsientoContable/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula");
            return View();
        }

        // POST: AsientoContable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Cuenta,IsCredit,FechaAsiento,Estado,EmpleadoId")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientoContable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", asientoContable.EmpleadoId);
            return View(asientoContable);
        }

        // GET: AsientoContable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables.FindAsync(id);
            if (asientoContable == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", asientoContable.EmpleadoId);
            return View(asientoContable);
        }

        // POST: AsientoContable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Cuenta,IsCredit,FechaAsiento,Estado,EmpleadoId")] AsientoContable asientoContable)
        {
            if (id != asientoContable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientoContable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientoContableExists(asientoContable.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", asientoContable.EmpleadoId);
            return View(asientoContable);
        }

        // GET: AsientoContable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // POST: AsientoContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientoContable = await _context.AsientoContables.FindAsync(id);
            _context.AsientoContables.Remove(asientoContable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientoContableExists(int id)
        {
            return _context.AsientoContables.Any(e => e.Id == id);
        }
    }
}
