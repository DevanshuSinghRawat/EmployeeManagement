using Core;
using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using NLog;
using Project1.AppCode;
using Project1.Pages;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

[BindProperties]
public class Add_EmployeeModel : BaseModel
{
    public static Logger log = LogManager.GetLogger("Project1");
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter Name")]
    [StringLength(50, ErrorMessage = "Max: 50")]
    public string FName { get; set; }
    public string LName { get; set; }
    
    [Required(ErrorMessage = "Please Enter email ID")]
    [EmailAddress(ErrorMessage = "Enter valid email")]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Status { get; set; }
    public List<string> StatusList { get; set; }
    [Required]
    public string DOB { get; set; }
    public IFormFile ProfilePic { get; set; }
    public string Gender { get; set; }
    public List<string> GenderList { get; set; }
    public bool Isdependent { get; set; }
    [Required(ErrorMessage = "Please enter Skills")]
    [StringLength(50, ErrorMessage = "Max length: 100")]
    public string Skills { get; set; }

    [Required(ErrorMessage = "Please enter Address")]
    [StringLength(50, ErrorMessage = "Max: 50")]
    public string Address { get; set; }

    public void OnGet()
        {
            GenderList = CommonFunctions.GetGenderList();
            StatusList = CommonFunctions.GetStatusList();
        }

    public IActionResult OnPost()
    {
        log.Debug($"Begin: OnPost method");

        Employee employee = new Employee();
        employee.FName = FName;
        employee.LName = LName;
        employee.Email = Email;
        employee.Phone = Phone;
        employee.Status = Status;
        employee.Gender = Gender;
        employee.Skills = Skills;
        employee.Address = Address;
        employee.Isdependent = Isdependent;

        employee.CreatedOnUtc = DateTime.UtcNow;
        employee.UpdatedOnUtc = DateTime.UtcNow;
        employee.CreatedBy = "System";
        employee.UpdatedBy = "System";
        DateTime dateOfBirth = DateTime.MinValue;
        DateTime.TryParse(DOB, out dateOfBirth);
        employee.DOB = dateOfBirth;
        employee.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();

        if (ProfilePic != null)
        {

            string filename = $"{ProfilePic.FileName}";             // Removed Guid.NewGuid() that sir used 
            string FilePath = $"C:\\Dev\\Profile_Pics\\{filename}";         // Time=16:48 Line=68 Tutorial=52 Asp net core

            using (Stream filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                ProfilePic.CopyTo(filestream);
            }
            employee.ProfilePic = ProfilePic.FileName;
        }

        IEmployeeService employeeManager = new EmployeeManager();
        OperationResult operationResult = employeeManager.Insert(employee);
        if (operationResult.Status == (int)OperationStatus.Success)
        {
            Success(Messages.EmployeeAddedSuccessMessage);
        }
        else
        {
            Warning(Messages.EmployeeAddedFailureMessage);
        }

        log.Debug($"End: OnPost method");
        return RedirectToPage("Display");
    }
}

