using Core;
using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using Project1.AppCode;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Project1.Pages.NTier
{
    [BindProperties]
    public class UpdateModel : BaseModel
    {
        public static Logger log = LogManager.GetLogger("Project1");
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, ErrorMessage = "Max: 50")]
        public string FName { get; set; }
        public string LName { get; set; }
        [Required(ErrorMessage = "Email should be unique, valid and non-empty")]
        [StringLength(50, ErrorMessage = "Max: 50")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        [StringLength(50, ErrorMessage = "Max: 50")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Status")]
        public string Status { get; set; }
        public List<string> StatusList { get; set; }

        [Required(ErrorMessage = "Please enter DOB")]
        public string DOB { get; set; }
        public DateTime dateOfBirth { get; set; }
        public IFormFile ProfilePic { get; set; }
        public string Gender { get; set; }
        public List<string> GenderList { get; set; }
        public bool Isdependent { get; set; }

        [Required(ErrorMessage = "Please enter Skills")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(50, ErrorMessage = "Max: 50")]
        public string Address { get; set; }



        public void OnGet(int id)
        {
            log.Debug("Begin: OnGet method");

            IEmployeeService employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetById(id);
            Id = employee.Id;
            FName = employee.FName;
            LName = employee.LName;
            Email = employee.Email;
            Phone = employee.Phone;
            DOB = employee.DOB.ToString("MMM dd, yyyy");
            Status = employee.Status;
            Gender = employee.Gender;

            Isdependent = employee.Isdependent;
            Skills = employee.Skills;
            Address = employee.Address;

            GenderList = CommonFunctions.GetGenderList();
            StatusList = CommonFunctions.GetStatusList();


            log.Debug("End: OnGet method");
        }


        public IActionResult OnPost()
        {
            log.Debug("Begin: OnPost method");
            IEmployeeService employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetById(Id);
            employee.Id = Id;
            employee.FName = FName;
            employee.LName = LName;
            employee.Email = Email;
            employee.Phone = Phone;
            employee.Status = Status;
            if (DOB != null)
                employee.DOB = DateTime.Parse(DOB);
            if (ProfilePic != null)
            {
                string filename = $"{ProfilePic.FileName}";
                string FilePath = $"C:\\Dev\\Profile_Pics\\{filename}";

                using (Stream filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    ProfilePic.CopyTo(filestream);
                }
                employee.ProfilePic = ProfilePic.FileName;
            }

            employee.Gender = Gender;
            employee.Isdependent = Isdependent;
            employee.Skills = Skills;
            employee.Address = Address;

            //employeeManager.Update(employee);
            OperationResult operationResult = employeeManager.Update(employee);
            if (operationResult.Status == (int)OperationStatus.Success)
            {
                Success(Messages.EmployeeAddedSuccessMessage);
            }
            else
            {
                Warning(Messages.EmployeeAddedFailureMessage);
            }


            log.Debug("End: OnPost method");

            return RedirectToPage("Display");
        }


        // DELETE USING GET
        public IActionResult OnGetDelete(int id)
        {
            log.Debug($"Begin: OnGetDelete using id: {id}");
            IEmployeeService employeeManager = new EmployeeManager();
            employeeManager.Delete(id);
            log.Debug($"End: OnGetDelete using id: {id}");
            return RedirectToPage("Display");
        }

    }
}
