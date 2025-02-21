using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project1.Pages
{
    public class BaseModel : PageModel
    {
        public void Warning(string message)
        {
            TempData["WarningMessage"] = message;
        }
        public void Success(string message)
        {
            TempData["SuccessMessage"] = message;
        }
    }
}
