using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = _context.Students
                .Include(s => s.Career)
                .Include(s => s.Courses);
            return View(await students.ToListAsync());
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            ViewData["Courses"] = new MultiSelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,CareerId,Courses")] Student student, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                student.Courses = _context.Courses.Where(c => selectedCourses.Contains(c.Id)).ToList();
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", student.CareerId);
            ViewData["Courses"] = new MultiSelectList(_context.Courses, "Id", "Name", selectedCourses);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(m => m.Id == id);
            if (student == null) return NotFound();

            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", student.CareerId);
            ViewData["Courses"] = new MultiSelectList(_context.Courses, "Id", "Name", student.Courses.Select(c => c.Id));
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,CareerId,Courses")] Student student, int[] selectedCourses)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var studentToUpdate = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
                if (studentToUpdate == null) return NotFound();

                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.Email = student.Email;
                studentToUpdate.PhoneNumber = student.PhoneNumber;
                studentToUpdate.CareerId = student.CareerId;
                studentToUpdate.Courses = _context.Courses.Where(c => selectedCourses.Contains(c.Id)).ToList();

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", student.CareerId);
            ViewData["Courses"] = new MultiSelectList(_context.Courses, "Id", "Name", selectedCourses);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.Career)
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
