using System.ComponentModel.DataAnnotations;

namespace MatriculaU_BolanosKevin.Models
{
    public class Student
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(12)]
        public string DocumentNumber { get; set; } // ID or passport number

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
