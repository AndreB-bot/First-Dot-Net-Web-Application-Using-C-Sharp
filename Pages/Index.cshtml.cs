using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApplication.Services;

namespace TestApplication.Pages
{
    public class IndexModel : PageModel
    {
        // You don't make a logger. You ask for one.
        private readonly ILogger<IndexModel> _logger;
        
        // Constructor.
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}