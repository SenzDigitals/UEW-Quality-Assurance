using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public class AppraisalPeriodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppraisalPeriodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppraisalPeriods
        public async Task<IActionResult> Index()
        {
            await _context.AppraisalPeriods.ToListAsync();

            return RedirectToAction("Create");
        }

        // GET: AppraisalPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisalPeriod = await _context.AppraisalPeriods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appraisalPeriod == null)
            {
                return NotFound();
            }

            return View(appraisalPeriod);
        }

        // GET: AppraisalPeriods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppraisalPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,academicYear,semester,startDate,endDate")] AppraisalPeriod appraisalPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appraisalPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appraisalPeriod);
        }

        // GET: AppraisalPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisalPeriod = await _context.AppraisalPeriods.FindAsync(id);
            if (appraisalPeriod == null)
            {
                return NotFound();
            }
            return View(appraisalPeriod);
        }

        // POST: AppraisalPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,academicYear,semester,startDate,endDate")] AppraisalPeriod appraisalPeriod)
        {
            if (id != appraisalPeriod.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appraisalPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppraisalPeriodExists(appraisalPeriod.ID))
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
            return View(appraisalPeriod);
        }

        // GET: AppraisalPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisalPeriod = await _context.AppraisalPeriods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appraisalPeriod == null)
            {
                return NotFound();
            }

            return View(appraisalPeriod);
        }

        // POST: AppraisalPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appraisalPeriod = await _context.AppraisalPeriods.FindAsync(id);
            _context.AppraisalPeriods.Remove(appraisalPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create");
        }

        private bool AppraisalPeriodExists(int id)
        {
            return _context.AppraisalPeriods.Any(e => e.ID == id);
        }
    }
}
