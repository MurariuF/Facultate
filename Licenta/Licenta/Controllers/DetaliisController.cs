using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Licenta.Data;
using Licenta.Models;

namespace Licenta.Controllers
{
    public class DetaliisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetaliisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detaliis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detaliis.Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Detaliis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalii = await _context.Detaliis
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalii == null)
            {
                return NotFound();
            }

            return View(detalii);
        }

        // GET: Detaliis/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: Detaliis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Varsta,Greutate,Inaltimea,Data,Rezultat1,Rezultat2")] Detalii detalii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", detalii.UserId);
            return View(detalii);
        }

        // GET: Detaliis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalii = await _context.Detaliis.FindAsync(id);
            if (detalii == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", detalii.UserId);
            return View(detalii);
        }

        // POST: Detaliis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Varsta,Greutate,Inaltimea,Data,Rezultat1,Rezultat2")] Detalii detalii)
        {
            if (id != detalii.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetaliiExists(detalii.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", detalii.UserId);
            return View(detalii);
        }

        // GET: Detaliis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalii = await _context.Detaliis
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalii == null)
            {
                return NotFound();
            }

            return View(detalii);
        }

        // POST: Detaliis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalii = await _context.Detaliis.FindAsync(id);
            _context.Detaliis.Remove(detalii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetaliiExists(int id)
        {
            return _context.Detaliis.Any(e => e.Id == id);
        }
    }
}
