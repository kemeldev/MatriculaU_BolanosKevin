using MatriculaU_BolanosKevin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MatriculaU_BolanosKevin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Career> Careers { get; set; }  // Added Careers

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define Many-to-Many Relationship between Student and Course
            builder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // Define One-to-Many Relationship: Career -> Students
            builder.Entity<Student>()
                .HasOne(s => s.Career)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CareerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents accidental cascade deletion

            // Define One-to-Many Relationship: Career -> Courses
            builder.Entity<Course>()
                .HasOne(c => c.Career)
                .WithMany(cr => cr.Courses)
                .HasForeignKey(c => c.CareerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
