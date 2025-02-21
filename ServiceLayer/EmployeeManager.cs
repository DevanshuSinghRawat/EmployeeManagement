using Core;
using Core.BusinessObject;
using Core.Services;
using DataLayer;
using NLog;

namespace ServiceLayer
{
    public class EmployeeManager : IEmployeeService
    {
        public static Logger log = LogManager.GetLogger("Project1");
        public OperationResult Insert(Employee employee)
        {
            log.Debug($"Begin: Insert");
            if (GetByEmail(employee.Email) != null)     // If record does not already exist
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EMPLOYEE_ADDED_FAILUE_NAME_UNIQUE, employee);
            }
            EmployeeDB.Insert(employee);
            log.Debug($"End: Insert");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.EmployeeAddedSuccessMessage, employee);
        }


        public OperationResult Update(Employee employee)
        {
            log.Debug($"Begin: Update");
            EmployeeDB.Update(employee);
            log.Debug($"End: Update");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.EmployeeUpdatedSuccessMessage, employee);
        }


        public List<Employee> GetAll()
        {
            log.Debug("Begin: GetAll");
            List<Employee> employeeList = EmployeeDB.GetAll();
            log.Debug("End: GetAll");
            return employeeList;
        }



        /// <summary>
        /// This method Gets Employee data by Name
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> </returns>
        // FETCHES ALL DATA BY NAME
        public Employee GetByName(string fname, string lname)
        {
            log.Debug($"Calling to GetByName with name: {fname} {lname} (from Service Layer)");
            Employee employee = EmployeeDB.GetByName(fname,lname);
            log.Debug($"Called GetByName with name: {fname} {lname} (from Service Layer)");
            return employee;
        }

        /// <summary>
        /// This methods returns employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            log.Debug($"Calling to GetById with Id: {id} (from Service Layer)");
            Employee employee = EmployeeDB.GetById(id);
            log.Debug($"Called GetById with Id: {id} (from Service Layer)");
            return employee;
        }


        // FETCHES ALL DATA BY EMAIL ID
        /// <summary>
        /// Get Employee data by email ID
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee GetByEmail(string email)
        {
            log.Debug($"Calling to GetByEmail with email: {email} (from Service Layer)");
            Employee employee = EmployeeDB.GetByEmail(email);
            log.Debug($"Called to GetByEmail with email: {email} (from Service Layer)");
            return employee;
        }



        /// This method deletes by id
        public void Delete(int id)
        {
            log.Debug($"Calling to Delete with id: {id} (from Service Layer)");
            EmployeeDB.Delete(id);
            log.Debug($"Called to Delete with id: {id} (from Service Layer)");
        }
    }
}