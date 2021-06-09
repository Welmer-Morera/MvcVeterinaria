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
    public class VeterinarioController : Controller
    {
        private readonly MvcVeterinariaContext _context;

        public VeterinarioController(MvcVeterinariaContext context)
        {
            _context = context;
        }
        // public ActionResult Inprimir()  
        //     {  
        //     var report = new Rotativa.ActionAsPdf("Index");  
        //     return report;  
        //     } 

        // public async Task<IActionResult> Pdf(){
        //     return new ViewAsPdf("Pdf",await _context.Veterinario.ToListAsync());
        // }


        // GET: Veterinario
        public async Task<IActionResult> Index(string Busqueda)
        {
            var veterinarios = from m in _context.Veterinario select m;
            if (!String.IsNullOrEmpty(Busqueda))
            {

                veterinarios = veterinarios.Where(s => s.Nombre.Contains(Busqueda));
            }
            return View(await veterinarios.ToListAsync());
        }

        // GET: Veterinario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return View(veterinario);
        }

        // GET: Veterinario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especialidad,Experiencia,GradoAcademico")] Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        // GET: Veterinario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinario.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }
            return View(veterinario);
        }

        // POST: Veterinario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especialidad,Experiencia,GradoAcademico")] Veterinario veterinario)
        {
            if (id != veterinario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarioExists(veterinario.Id))
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
            return View(veterinario);
        }

        // GET: Veterinario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return View(veterinario);
        }

        // POST: Veterinario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinario = await _context.Veterinario.FindAsync(id);
            _context.Veterinario.Remove(veterinario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarioExists(int id)
        {
            return _context.Veterinario.Any(e => e.Id == id);
        }
    }
}
