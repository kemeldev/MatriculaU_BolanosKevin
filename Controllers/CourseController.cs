using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all courses
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Professor).ToList();
            return View(courses);
        }

        // Show course details
        public IActionResult Details(int id)
        {
            var course = _context.Courses
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // Show form to create a course
        public IActionResult Create()
        {
            ViewBag.Professors = _context.Professors.ToList();
            return View();
        }

        // Handle course creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
    }
}
