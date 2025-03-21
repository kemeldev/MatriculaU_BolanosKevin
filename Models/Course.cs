﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MatriculaU_BolanosKevin.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }  // Course Code (e.g., "CS101")

        [Required]
        public int Credits { get; set; }

        // Relationship: A course is taught by one professor
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        // Relationship: A course belongs to one Career
        [ForeignKey("Career")]
        public int CareerId { get; set; }
        public virtual Career Career { get; set; }

        // Relationship: Many students can enroll in a course
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}