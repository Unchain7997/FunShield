using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;
using System.Threading.Tasks;

namespace FunShield.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public EditModel(FunShieldDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Courses == null)
            {
                return NotFound();
            }

            _context.Attach(Course!).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course!.CourseID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private bool CourseExists(int id)
        {
            return _context.Courses?.Any(c => c.CourseID == id) ?? false;
        }
    }
}