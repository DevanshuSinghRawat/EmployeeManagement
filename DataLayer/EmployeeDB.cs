using Core.BusinessObject;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NLog;

namespace DataLayer
{
    public class EmployeeDB
    {
        public static Logger log = LogManager.GetLogger("Project1");
        public static void Insert(Employee employee)
        {
            log.Debug("Begin: Insert");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert Into Employee_miniproject (FName, LName," +
                $" Email, Phone, Status, DOB, Gender, ProfilePic, Isdependent, Skills, Address, CreatedBy, " +
                $"CreatedOnUtc, UpdatedBy, UpdatedOnUtc, IPAddress)" +
                $" Values(@FName, @LName, @Email, @Phone, @Status, @DOB, @Gender, @ProfilePic, @Isdependent, @Skills, @Address, @CreatedBy," +
                $" @CreatedOnUtc, @UpdatedBy, @UpdatedOnUtc, @IPAddress);" +
                $" SELECT LAST_INSERT_ID()");

            db.AddInParameter(cmd, "FName", DbType.String, employee.FName);
            db.AddInParameter(cmd, "LName", DbType.String, employee.LName);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);
            db.AddInParameter(cmd, "DOB", DbType.DateTime, employee.DOB);
            db.AddInParameter(cmd, "Gender", DbType.String, employee.Gender);
            db.AddInParameter(cmd, "ProfilePic", DbType.String, employee.ProfilePic);
            db.AddInParameter(cmd, "Isdependent", DbType.Boolean, employee.Isdependent);

            db.AddInParameter(cmd, "Skills", DbType.String, employee.Skills);
            db.AddInParameter(cmd, "Address", DbType.String, employee.Address);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, employee.CreatedBy);
            db.AddInParameter(cmd, "CreatedOnUtc", DbType.DateTime, employee.CreatedOnUtc);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, employee.UpdatedBy);
            db.AddInParameter(cmd, "UpdatedOnUtc", DbType.DateTime, employee.UpdatedOnUtc);
            db.AddInParameter(cmd, "IPAddress", DbType.String, employee.IPAddress);

            employee.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            log.Debug("End: Insert");
        }


        public static void Update(Employee employee)
        {
            log.Debug("Begin: Update");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"update Employee_miniproject set " +
                $"FName=@FName, LName=@LName, Email=@Email, Phone=@Phone, Status=@Status, DOB=@DOB, Gender=@Gender, " +
                $"ProfilePic=@ProfilePic, Isdependent=@Isdependent, Skills=@Skills, Address=@Address, CreatedBy=@CreatedBy, " +
                $"CreatedOnUtc=@CreatedOnUtc, UpdatedBy=@UpdatedBy, UpdatedOnUtc=@UpdatedOnUtc, IPAddress=@IPAddress" +
                $" where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.Int32, employee.Id);
            db.AddInParameter(cmd, "FName", DbType.String, employee.FName);
            db.AddInParameter(cmd, "LName", DbType.String, employee.LName);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);
            db.AddInParameter(cmd, "DOB", DbType.DateTime, employee.DOB);
            db.AddInParameter(cmd, "Gender", DbType.String, employee.Gender);
            db.AddInParameter(cmd, "ProfilePic", DbType.String, employee.ProfilePic);
            db.AddInParameter(cmd, "Isdependent", DbType.Boolean, employee.Isdependent);

            db.AddInParameter(cmd, "Skills", DbType.String, employee.Skills);
            db.AddInParameter(cmd, "Address", DbType.String, employee.Address);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, employee.CreatedBy);
            db.AddInParameter(cmd, "CreatedOnUtc", DbType.DateTime, employee.CreatedOnUtc);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, employee.UpdatedBy);
            db.AddInParameter(cmd, "UpdatedOnUtc", DbType.DateTime, employee.UpdatedOnUtc);
            db.AddInParameter(cmd, "IPAddress", DbType.String, employee.IPAddress);
            db.ExecuteNonQuery(cmd);
            log.Debug("End: Update");
        }


        public static Employee GetByName(string fname, string lname)
        {
            log.Debug("Begin: GetByName");
            Employee employee = new Employee();
            Database db = ConnectionFactory.CreateDataBase();

            DbCommand cmd = db.GetSqlStringCommand($"select * from Employee_miniproject where FName=@FName and LName=@LName");
            db.AddInParameter(cmd, "FName", DbType.String, fname);
            db.AddInParameter(cmd, "LName", DbType.String, lname);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            log.Debug("End: GetByName");
            return employee;
        }

        public static Employee GetById(int id)
        {
            log.Debug("Begin: GetById");
            Employee employee = new Employee();
            Database db = ConnectionFactory.CreateDataBase();

            DbCommand cmd = db.GetSqlStringCommand($"select * from Employee_miniproject where Id=@id");
            db.AddInParameter(cmd, "Id", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            log.Debug("End: GetById");
            return employee;
        }


        public static List<Employee> GetAll()
        {
            log.Debug("Begin: GetAll");
            List<Employee> employeeList = new List<Employee>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Employee_miniproject");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Employee emp = new Employee(reader);
                employeeList.Add(emp);
            }
            log.Debug("End: GetAll");
            return employeeList;
        }


        public static Employee GetByEmail(string email)
        {
            log.Debug("Begin: GetByEmail");
            Employee employee = null;
            Database db = ConnectionFactory.CreateDataBase();

            DbCommand cmd = db.GetSqlStringCommand($"select * from Employee_miniproject where Email=@Email");
            db.AddInParameter(cmd, "Email", DbType.String, email);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            log.Debug("End: GetByEmail");
            return employee;
        }

        

        public static void Delete(int id)
        {
            log.Debug("Begin: Delete");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Delete From Employee_miniproject where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            log.Debug("End: Delete");
        }
    }
}