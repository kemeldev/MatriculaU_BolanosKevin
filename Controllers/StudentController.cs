using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Show details of a student
        public IActionResult Details(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Show form to create a student
        public IActionResult Create()
        {
            return View();
        }

        
    }
}
