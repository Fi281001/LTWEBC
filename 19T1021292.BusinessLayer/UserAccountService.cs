using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DataLayers;
using _19T1021292.DomainModels;
namespace _19T1021292.BusinessLayer
{
    /// <summary>
    /// các chức năng tác nghiệp liên quan đến tài khoản
    /// </summary>
    public static class UserAccountService
    {
        private static IUserAccountDAL employeeAccountDB;
        private static IUserAccountDAL customerAccountDB;

        static UserAccountService()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            employeeAccountDB = new DataLayers.SQLServer.EmployeeAccountDAL(connectionstring);
            customerAccountDB = new DataLayers.SQLServer.CustomerAccountDAL(connectionstring);


        }

        public static UserAccount Authorize(AccountTypes accountTypes, string userName, string password)
        {
            if (accountTypes == AccountTypes.Employee)
                return employeeAccountDB.Authorize(userName, password);
            else
                return customerAccountDB.Authorize(userName, password);
        }

        public static bool ChangePassword(AccountTypes accountTypes, string userName, string oldPassword, string newPassword)
        {
            if (accountTypes == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAccountDB.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}
