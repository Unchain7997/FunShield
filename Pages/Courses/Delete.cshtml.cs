using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;
using System.Threading.Tasks;

namespace FunShield.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public DeleteModel(FunShieldDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course? Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}