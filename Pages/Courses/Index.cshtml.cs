using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunShield.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public IndexModel(FunShieldDbContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; } = new List<Course>();

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses!.ToListAsync();
        }
    }
}