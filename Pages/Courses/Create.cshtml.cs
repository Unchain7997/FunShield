using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunShield.Data;
using FunShield.Models;
using System.Threading.Tasks;

namespace FunShield.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public CreateModel(FunShieldDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; } = new Course();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses!.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}