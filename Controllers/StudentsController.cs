using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UEW_Quality_Assurance.Data;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Controllers
{
    //[Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //var students = _context.Students.ToList();

            ViewData["LastNameSortParm"] = String.IsNullOrEmpty( sortOrder ) ? "" : "lname_desc";
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "" : "fname_desc";
            ViewData["currentFilter"] = searchString;

            var student = from s in _context.Students
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.lname.Contains(searchString) ||
                s.fname.Contains(searchString) || s.studentID.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "lname_desc":
                    student = student.OrderByDescending(s => s.lname);
                    break;
                case "fname_desc":
                    student = student.OrderByDescending(s => s.fname);
                    break;
                default:
                    student = student.OrderBy(s => s.lname);
                    break;
            }

            return View(await student.AsNoTracking().ToListAsync()) ;
        }


        // GET: Students/Details/5
        public IActionResult Details(string id, Enrollment courseid)
        {

            dynamic myModel = new ExpandoObject();
            GetData getData = new GetData();

            myModel.Students = getData.getStudent(id); 
            myModel.Enrollments = getData.getEnrollment(id);
            //myModel.Courses = getData.getCourse();

            if(myModel == null)
            {

            }
            //var student = _context.Students
            //    .Include(s => s.Program)
            //    //.ThenInclude(c => c.Course)
            //    //.ThenInclude(d => d.Department)
            //    //.ThenInclude(p => p.Program)
            //    .SingleOrDefault(m => m.studentID == id);

            //if (student == null)
            //{
            //    return NotFound();
            //}


            return View(myModel);
        }

        
       

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["programID"] = new SelectList(_context.Progs, "programID", "programID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentID,lname,fname,programID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["programID"] = new SelectList(_context.Progs, "programID", "programID", student.programID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["programID"] = new SelectList(_context.Progs, "programID", "programID", student.programID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("studentID,lname,fname,programID")] Student student)
        {
            if (id != student.studentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.studentID))
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
            ViewData["programID"] = new SelectList(_context.Progs, "programID", "programID", student.programID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Program)
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.studentID == id);
        }
    }
}
