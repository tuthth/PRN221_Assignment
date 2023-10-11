using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class AdminModel : PageModel
    {
        public string AdminMessage { get; set; }
        public void OnGet()
        {
            AdminMessage = TempData["AdminMessage"] as string;
        }
    }
}
