using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunShield.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public DetailsModel(FunShieldDbContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = null!;
        public IList<Student> Students { get; set; } = new List<Student>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Course = await _context.Courses!
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .FirstOrDefaultAsync(c => c.CourseID == id) ?? throw new InvalidOperationException("Course not found.");


            if (Course == null)
            {
                return NotFound();
            }

            Students = Course.StudentCourses.Select(sc => sc.Student).ToList();
            return Page();
        }
    }
}