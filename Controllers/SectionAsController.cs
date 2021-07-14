using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UEW_Quality_Assurance.Data;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Controllers
{
    public class SectionAsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SectionAsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SectionAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SectionA.ToListAsync());
        }

        // GET: SectionAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionA = await _context.SectionA
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sectionA == null)
            {
                return NotFound();
            }

            return View(sectionA);
        }

        // GET: SectionAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SectionAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] SectionA sectionA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectionA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionA);
        }

        // GET: SectionAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionA = await _context.SectionA.FindAsync(id);
            if (sectionA == null)
            {
                return NotFound();
            }
            return View(sectionA);
        }

        // POST: SectionAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] SectionA sectionA)
        {
            if (id != sectionA.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectionA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionAExists(sectionA.ID))
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
            return View(sectionA);
        }

        // GET: SectionAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionA = await _context.SectionA
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sectionA == null)
            {
                return NotFound();
            }

            return View(sectionA);
        }

        // POST: SectionAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectionA = await _context.SectionA.FindAsync(id);
            _context.SectionA.Remove(sectionA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionAExists(int id)
        {
            return _context.SectionA.Any(e => e.ID == id);
        }
    }
}
