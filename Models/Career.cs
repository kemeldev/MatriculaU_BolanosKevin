using System.ComponentModel.DataAnnotations;

namespace MatriculaU_BolanosKevin.Models
{
    public class Career
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Career Name (e.g., "Computer Science")

        [Required]
        [StringLength(10)]
        public string Code { get; set; }  // Short Code (e.g., "CS")

        // Relationship: A Career has many Students
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        // Relationship: A Career has many Courses
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}