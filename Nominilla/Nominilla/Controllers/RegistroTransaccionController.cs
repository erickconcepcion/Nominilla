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
    public class RegistroTransaccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroTransaccionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroTransaccion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroTransaccions.Include(r => r.Empleado).Include(r => r.TipoDeduccion).Include(r => r.TipoIngreso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroTransaccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransaccions
                .Include(r => r.Empleado)
                .Include(r => r.TipoDeduccion)
                .Include(r => r.TipoIngreso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroTransaccion == null)
            {
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula");
            ViewData["TipoDeduccionId"] = new SelectList(_context.TipoDeduccions, "Id", "Nombre");
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "Id", "Nombre");
            return View();
        }

        // POST: RegistroTransaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Estado,Monto,EmpleadoId,TipoIngresoId,TipoDeduccionId")] RegistroTransaccion registroTransaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroTransaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", registroTransaccion.EmpleadoId);
            ViewData["TipoDeduccionId"] = new SelectList(_context.TipoDeduccions, "Id", "Nombre", registroTransaccion.TipoDeduccionId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "Id", "Nombre", registroTransaccion.TipoIngresoId);
            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransaccions.FindAsync(id);
            if (registroTransaccion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", registroTransaccion.EmpleadoId);
            ViewData["TipoDeduccionId"] = new SelectList(_context.TipoDeduccions, "Id", "Nombre", registroTransaccion.TipoDeduccionId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "Id", "Nombre", registroTransaccion.TipoIngresoId);
            return View(registroTransaccion);
        }

        // POST: RegistroTransaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Estado,Monto,EmpleadoId,TipoIngresoId,TipoDeduccionId")] RegistroTransaccion registroTransaccion)
        {
            if (id != registroTransaccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroTransaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroTransaccionExists(registroTransaccion.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Cedula", registroTransaccion.EmpleadoId);
            ViewData["TipoDeduccionId"] = new SelectList(_context.TipoDeduccions, "Id", "Nombre", registroTransaccion.TipoDeduccionId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "Id", "Nombre", registroTransaccion.TipoIngresoId);
            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransaccions
                .Include(r => r.Empleado)
                .Include(r => r.TipoDeduccion)
                .Include(r => r.TipoIngreso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroTransaccion == null)
            {
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // POST: RegistroTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroTransaccion = await _context.RegistroTransaccions.FindAsync(id);
            _context.RegistroTransaccions.Remove(registroTransaccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroTransaccionExists(int id)
        {
            return _context.RegistroTransaccions.Any(e => e.Id == id);
        }
    }
}
