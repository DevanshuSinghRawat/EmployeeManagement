using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using ServiceLayer;

namespace Project1.Pages.NTier
{
    public class DisplayModel : PageModel
    {
        public static Logger log = LogManager.GetLogger("Project1");
        public List<Employee> EmployeeList { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public void OnGet()
        {
            log.Debug($"Begin: Display's OnGet method");
            IEmployeeService employeeManager = new EmployeeManager();
            EmployeeList = employeeManager.GetAll();
            if (TempData["Action"] != null)
            {
                Action = TempData["Action"].ToString();
            }
            if (TempData["Message"] != null)
            {
                Message = TempData["Message"].ToString();
            }
            log.Debug($"End: Display's OnGet method");
        }


        public IActionResult OnGetByName(string fname, string lname)
        {
            log.Debug("Begin: Display's OnGetByName");
            IEmployeeService employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetByName(fname, lname);
            log.Debug("End: Display's OnGetByName");
            return RedirectToPage("Display");
        }
    }
}
