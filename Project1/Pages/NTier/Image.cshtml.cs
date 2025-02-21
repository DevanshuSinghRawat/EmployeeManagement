using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project1.Pages.NTier
{
    public class ImageModel : BaseModel
    {
        public IActionResult OnGet(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                string path = $"C:\\Dev\\Profile_Pics\\{filename}";
                return File(System.IO.File.ReadAllBytes(path), "image/jpeg");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
