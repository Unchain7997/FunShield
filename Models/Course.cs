using System.ComponentModel.DataAnnotations;

namespace FunShield.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Language { get; set; } = string.Empty;

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}