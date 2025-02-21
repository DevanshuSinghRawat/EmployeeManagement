using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.BusinessObject
{ 
    public class Employee : BaseObject
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public DateTime DOB { get; set; }
        public string ProfilePic { get; set; }
        public string Gender { get; set; }
        public bool Isdependent { get; set; }
        public string Skills { get; set; }
        public string Address { get; set; }


        public Employee()
        {

        }

        public Employee(IDataReader reader) : base(reader)
        {
            FName = DBNull.Value != reader["FName"] ? (string)reader["FName"] : default(string);
            LName = DBNull.Value != reader["LName"] ? (string)reader["LName"] : default(string);
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default(string);
            Phone = DBNull.Value != reader["Phone"] ? (string)reader["Phone"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            DOB = DBNull.Value != reader["DOB"] ? (DateTime)reader["DOB"] : default(DateTime);
            ProfilePic = DBNull.Value != reader["ProfilePic"] ? (string)reader["ProfilePic"] : default(string);
            Gender = DBNull.Value != reader["Gender"] ? (string)reader["Gender"] : default(string);
            Isdependent = DBNull.Value != reader["Isdependent"] ? (bool)reader["Isdependent"] : default;
            Skills = DBNull.Value != reader["Skills"] ? (string)reader["Skills"] : default(string);
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default(string);
        }
    }
}
