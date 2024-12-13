using System.ComponentModel.DataAnnotations;
namespace FunShield.Models;

public class Student
{
    public int StudentID { get; set; }

    [Required]
    [StringLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Range(5, 12, ErrorMessage = "Age must be between 5 and 12.")]
    public int Age { get; set; }

    [Required]
    [Range(1, 6, ErrorMessage = "Grade must be between 1 and 6.")]
    public int Grade { get; set; }

    [Required]
    public string EnrollmentHistory { get; set; } = string.Empty;

    [Required]
    public string SessionID { get; set; } = string.Empty;

    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}