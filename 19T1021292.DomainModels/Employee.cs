using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021292.DomainModels
{
   public class Employee
    {
        /// <summary>
        /// mã id
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// ảnh
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// email
        /// </summary>
       public string Email { get; set; }
    

    }
}
