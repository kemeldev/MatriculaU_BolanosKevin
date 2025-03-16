using MatriculaU_BolanosKevin.Data;
using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaU_BolanosKevin.Controllers
{
    public class CareersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var careers = await _context.Careers.ToListAsync();
            return View(careers);
        }

        public IActionResult Create()
        {
            return View();
        }

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

        public async Task<IActionResult> Edit(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            if (career == null) return NotFound();
            return View(career);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Career career)
        {
            if (id != career.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            if (career == null) return NotFound();
            return View(career);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            if (career != null)
            {
                _context.Careers.Remove(career);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}