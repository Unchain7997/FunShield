using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;

namespace FunShield.Pages_Students
{
    public class DetailsModel : PageModel
    {
        private readonly FunShield.Data.FunShieldDbContext _context;

        public DetailsModel(FunShield.Data.FunShieldDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);

            if (student is not null)
            {
                Student = student;

                return Page();
            }

            return NotFound();
        }
    }
}
