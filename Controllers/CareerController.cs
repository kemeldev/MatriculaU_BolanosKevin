using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class CareerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all careers
        public IActionResult Index()
        {
            var careers = _context.Careers.ToList();
            return View(careers);
        }

        // Show career details
        public IActionResult Details(int id)
        {
            var career = _context.Careers
                .FirstOrDefault(c => c.Id == id);
            if (career == null) return NotFound();
            return View(career);
        }

        // Show form to create a new career
        public IActionResult Create()
        {
            return View();
        }

        // Handle career creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Career career)
        {
            if (ModelState.IsValid)
            {
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }
    }
}
