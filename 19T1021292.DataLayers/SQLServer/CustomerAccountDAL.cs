using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DomainModels;
namespace _19T1021292.DataLayers.SQLServer
{
    /// <summary>
    /// cài đặc cho tài khoản khách hàng
    /// </summary>
    public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    {
        public CustomerAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public UserAccount Authorize(string userName, string password)
        {
            UserAccount data = null;
            using (var connection = OpenConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers WHERE Email=@Email AND Password=@Password";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                using (var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new UserAccount()
                        {
                            UserId = Convert.ToString(dbReader["CustomerID"]),
                            UserName = Convert.ToString(dbReader["Email"]),
                            FullName= Convert.ToString(dbReader["CustomerName"]),
                            ContactName = Convert.ToString(dbReader["ContactName"]),
                            //FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                            Email = Convert.ToString(dbReader["Email"]),
                            Photo = Convert.ToString(dbReader["Photo"]),
                            City = Convert.ToString(dbReader["City"]),
                            Country = Convert.ToString(dbReader["Country"]),
                            PostalCode = Convert.ToString(dbReader["PostalCode"]),
                            Address = Convert.ToString(dbReader["Address"]),
                            Password = "",
                            RoleNames = ""
                        };
                    }
                    dbReader.Close();
                }
                connection.Close();
            }

            return data;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
