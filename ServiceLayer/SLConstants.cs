using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class SLConstants
    {
        public static class Messages
        {
            public const string EmployeeAddedSuccessMessage = "Record added successfully";
            public const string EmployeeAddedFailureMessage = "Record can not be added. Email should be unique.";
            public const string EmployeeUpdatedSuccessMessage = "Record updated successfully";
            public const string EmployeeUpdatedFailureMessage = "Record update failed.";
            public const string EmployeeDeletedSuccessMessage = "Record deleted successfully";
            public const string EMPLOYEE_ADDED_FAILUE_NAME_UNIQUE = "Record can not be added. Name should be unique.";
        }
    }
}
