using System.ComponentModel.DataAnnotations;

namespace MatriculaU_BolanosKevin.Models
{
    public class Professor
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

        // Relationship: A professor can teach multiple courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
