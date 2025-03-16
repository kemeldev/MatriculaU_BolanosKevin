using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses.Include(c => c.Career);
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,Credits,ProfessorId,CareerId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", course.CareerId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", course.CareerId);
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,Credits,ProfessorId,CareerId")] Course course)
        {
            if (id != course.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", course.CareerId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses.Include(c => c.Career)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null) return NotFound();

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
