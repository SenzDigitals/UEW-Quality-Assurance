using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UEW_Quality_Assurance.Data;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Controllers
{
    //[Authorize]
    public class ThresholdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThresholdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Thresholds
        public async Task<IActionResult> Index()
        {
            await _context.Thresholds.ToListAsync();

            return RedirectToAction("Create", "Thresholds");
        }

        // GET: Thresholds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threshold = await _context.Thresholds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (threshold == null)
            {
                return NotFound();
            }

            return View(threshold);
        }

        // GET: Thresholds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thresholds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("limit,questions")] Threshold threshold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threshold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(threshold);
        }

        // GET: Thresholds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threshold = await _context.Thresholds.FindAsync(id);
            if (threshold == null)
            {
                return NotFound();
            }
            return View(threshold);
        }

        // POST: Thresholds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,limit,questions")] Threshold threshold)
        {
            if (id != threshold.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threshold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThresholdExists(threshold.ID))
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
            return View(threshold);
        }

        // GET: Thresholds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threshold = await _context.Thresholds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (threshold == null)
            {
                return NotFound();
            }

            return View(threshold);
        }

        // POST: Thresholds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threshold = await _context.Thresholds.FindAsync(id);
            _context.Thresholds.Remove(threshold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThresholdExists(int id)
        {
            return _context.Thresholds.Any(e => e.ID == id);
        }
    }
}
