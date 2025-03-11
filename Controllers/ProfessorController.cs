using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all professors
        public IActionResult Index()
        {
            var professors = _context.Professors.ToList();
            return View(professors);
        }

        // Show details of a professor
        public IActionResult Details(int id)
        {
            var professor = _context.Professors.FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound();
            return View(professor);
        }

        // Show form to create a new professor
        public IActionResult Create()
        {
            return View();
        }

        // Handle professor creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }
    }
}
