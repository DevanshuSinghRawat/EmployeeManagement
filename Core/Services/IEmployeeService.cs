using Core.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public OperationResult Insert(Employee employee);

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="employee"></param>
        public OperationResult Update(Employee employee);

        /// <summary>
        /// GetAll()
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll();

        /// <summary>
        /// GetByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Employee GetByName(string fname, string lname);

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id);

        /// <summary>
        /// GetByName
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Employee GetByEmail(string email);


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
