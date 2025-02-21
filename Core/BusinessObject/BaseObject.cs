using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessObject
{
    public class BaseObject 
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string IPAddress { get; set; }


        public BaseObject()
        {

        }

        public BaseObject(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (int)reader["Id"] : default(int);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);

            UpdatedOnUtc = DBNull.Value != reader["UpdatedOnUtc"] ? DateTime.Parse(reader["UpdatedOnUtc"].ToString()) : default;

            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);

            CreatedOnUtc = DBNull.Value != reader["CreatedOnUtc"] ? DateTime.Parse(reader["CreatedOnUtc"].ToString()) : default;
            IPAddress = DBNull.Value != reader["IPAddress"] ? (string)reader["IPAddress"] : default(string);
        }
    }
}
