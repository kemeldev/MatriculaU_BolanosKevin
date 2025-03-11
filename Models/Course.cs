using System.ComponentModel.DataAnnotations;

namespace MatriculaU_BolanosKevin.Models
{
    public class Course
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; } // Course Code (e.g., "CS101")

        [Required]
        public int Credits { get; set; }

        // Relationship: A course is taught by one professor
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        // Relationship: Many students can enroll in a course
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
