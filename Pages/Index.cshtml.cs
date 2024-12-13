using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunShield.Models;
using FunShield.Data;

namespace FunShield.Pages;

public class IndexModel : PageModel
{
    private readonly FunShieldDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(FunShieldDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
