using System.ComponentModel.DataAnnotations;


namespace MatriculaU_BolanosKevin.Models
{
    public class Student
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        // Relationship: A student belongs to one Career
        public int? CareerId { get; set; }
        public Career Career { get; set; }

        // Many-to-Many Relationship: A student can enroll in many courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
