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
    public class RegularStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegularStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegularStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegularStudents.ToListAsync());
        }

        // GET: RegularStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularStudent = await _context.RegularStudents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (regularStudent == null)
            {
                return NotFound();
            }

            return View(regularStudent);
        }


        public async Task<IActionResult> SectionB()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var regularStudent = await _context.RegularStudents
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (regularStudent == null)
            //{
            //    return NotFound();
            //}

            return View(await _context.RegularStudents.ToListAsync());
        }

        public async Task<IActionResult> SectionF()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var regularStudent = await _context.RegularStudents
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (regularStudent == null)
            //{
            //    return NotFound();
            //}

            return View(await _context.RegularStudents.ToListAsync());
        }


        // GET: RegularStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegularStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Results")] RegularStudent regularStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regularStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regularStudent);
        }

        // GET: RegularStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularStudent = await _context.RegularStudents.FindAsync(id);
            if (regularStudent == null)
            {
                return NotFound();
            }
            return View(regularStudent);
        }

        // POST: RegularStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Results")] RegularStudent regularStudent)
        {
            if (id != regularStudent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regularStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegularStudentExists(regularStudent.ID))
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
            return View(regularStudent);
        }

        // GET: RegularStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularStudent = await _context.RegularStudents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (regularStudent == null)
            {
                return NotFound();
            }

            return View(regularStudent);
        }

        // POST: RegularStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regularStudent = await _context.RegularStudents.FindAsync(id);
            _context.RegularStudents.Remove(regularStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegularStudentExists(int id)
        {
            return _context.RegularStudents.Any(e => e.ID == id);
        }
    }
}
