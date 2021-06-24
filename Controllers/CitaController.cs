using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcVeterinaria.Data;
using MvcVeterinaria.Models;

namespace MvcVeterinaria.Controllers
{
    public class CitaController : Controller
    {
        private readonly MvcVeterinariaContext _context;

        public CitaController(MvcVeterinariaContext context)
        {
            _context = context;
        }

        // GET: Cita
        public async Task<IActionResult> Index()
        {
            var mvcVeterinariaContext = _context.Cita.Include(c => c.Medicamento).Include(c => c.Veterinario);
            return View(await mvcVeterinariaContext.ToListAsync());
        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Medicamento)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Cita/Create
        public IActionResult Create()
        {
            var mc = new  MascotaController();
            List<string> n =  mc.obtenerNombres();
            SelectList list = new SelectList(n);
             ViewData["MascotaID"] = list;

            var veterinarioQuery = from v in _context.Veterinario orderby v.Nombre select v;
            ViewData["VeterinarioID"] = new SelectList(veterinarioQuery.AsNoTracking(), "Id", "Nombre");
            var MedicamentoQuery=  from me in _context.Medicamento orderby me.Nombre select me;
            ViewData["MedicamentoID"] = new SelectList(MedicamentoQuery, "Id", "Nombre");
           
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Descripcion,MascotaID,VeterinarioID,MedicamentoID")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           var mc = new  MascotaController();
            List<string> n =  mc.obtenerNombres();
            SelectList list = new SelectList(n);
             ViewData["MascotaID"] = list;

            var veterinarioQuery = from v in _context.Veterinario orderby v.Nombre select v;
            ViewData["VeterinarioID"] = new SelectList(veterinarioQuery.AsNoTracking(), "Id", "Nombre");
            var MedicamentoQuery=  from me in _context.Medicamento orderby me.Nombre select me;
            ViewData["MedicamentoID"] = new SelectList(MedicamentoQuery, "Id", "Nombre");
            return View(cita);
        }

        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
           var mc = new  MascotaController();
            List<string> n =  mc.obtenerNombres();
            SelectList list = new SelectList(n);
             ViewData["MascotaID"] = list;

            var veterinarioQuery = from v in _context.Veterinario orderby v.Nombre select v;
            ViewData["VeterinarioID"] = new SelectList(veterinarioQuery.AsNoTracking(), "Id", "Nombre");
            var MedicamentoQuery=  from me in _context.Medicamento orderby me.Nombre select me;
            ViewData["MedicamentoID"] = new SelectList(MedicamentoQuery, "Id", "Nombre");
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Descripcion,MascotaID,VeterinarioID,MedicamentoID")] Cita cita)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.Id))
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
            var mc = new  MascotaController();
            List<string> n =  mc.obtenerNombres();
            SelectList list = new SelectList(n);
             ViewData["MascotaID"] = list;

            var veterinarioQuery = from v in _context.Veterinario orderby v.Nombre select v;
            ViewData["VeterinarioID"] = new SelectList(veterinarioQuery.AsNoTracking(), "Id", "Nombre");
            var MedicamentoQuery=  from me in _context.Medicamento orderby me.Nombre select me;
            ViewData["MedicamentoID"] = new SelectList(MedicamentoQuery, "Id", "Nombre");
            return View(cita);
        }

        // GET: Cita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Medicamento)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }
    }
}
