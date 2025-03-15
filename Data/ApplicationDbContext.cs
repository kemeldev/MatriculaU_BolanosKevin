using MatriculaU_BolanosKevin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MatriculaU_BolanosKevin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Career> Careers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  // Important to call the base method

            // Define Many-to-Many Relationship between Student and Course
            builder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // Define One-to-Many Relationship: Career -> Students (with nullable CareerId)
            builder.Entity<Career>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Career)
                .HasForeignKey(s => s.CareerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Define One-to-Many Relationship: Career -> Courses
            builder.Entity<Career>()
                .HasMany(c => c.Courses)
                .WithOne(c => c.Career)
                .HasForeignKey(c => c.CareerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
