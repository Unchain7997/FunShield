using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunShield.Data;
using FunShield.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunShield.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly FunShieldDbContext _context;

        public IndexModel(FunShieldDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = new List<Student>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        private const int PageSize = 10;

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Students == null)
            {
                Students = new List<Student>();
                TotalPages = 0;
                return;
            }

            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                var lowerCaseSearchString = SearchString.ToLower();
                query = query.Where(s => s.FirstName.ToLower().Contains(lowerCaseSearchString) ||
                                         s.LastName.ToLower().Contains(lowerCaseSearchString));
            }

            query = SortOrder switch
            {
                "FirstName_Desc" => query.OrderByDescending(s => s.FirstName),
                "LastName" => query.OrderBy(s => s.LastName),
                "LastName_Desc" => query.OrderByDescending(s => s.LastName),
                "Age" => query.OrderBy(s => s.Age),
                "Age_Desc" => query.OrderByDescending(s => s.Age),
                "Grade" => query.OrderBy(s => s.Grade),
                "Grade_Desc" => query.OrderByDescending(s => s.Grade),
                "EnrollmentHistory" => query.OrderBy(s => s.EnrollmentHistory),
                "EnrollmentHistory_Desc" => query.OrderByDescending(s => s.EnrollmentHistory),
                "SessionID" => query.OrderBy(s => s.SessionID),
                "SessionID_Desc" => query.OrderByDescending(s => s.SessionID),
                _ => query.OrderBy(s => s.FirstName),
            };

            int totalStudents = await query.CountAsync();
            TotalPages = (int)System.Math.Ceiling(totalStudents / (double)PageSize);

            Students = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}