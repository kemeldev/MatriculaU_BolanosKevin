using Microsoft.AspNetCore.Mvc;
using MatriculaU_BolanosKevin.Models;
using MatriculaU_BolanosKevin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[Authorize] // Solo los usuarios autenticados pueden acceder
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Acción Index
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.ToListAsync();
        return View(students); // Pasamos los estudiantes a la vista
    }
}

