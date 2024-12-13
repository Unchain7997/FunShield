using System.ComponentModel.DataAnnotations;
namespace FunShield.Models;

public class StudentCourse
{
    public int StudentID { get; set; }
    public Student Student { get; set; } = null!;
    
    public int CourseID { get; set; }
    public Course Course { get; set; } = null!;
}