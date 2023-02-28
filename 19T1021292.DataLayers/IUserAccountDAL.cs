using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DomainModels;
namespace _19T1021292.DataLayers
{
    /// <summary>
    /// định nghĩa cách phép xử lý dữ liệu liên quán đến tài khoản người dùng
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// kiểm tra xem tên đăng nập và mật khẩu của người dùng có hợp lệ?
        /// nếu hợp lệ thì trả về thông tin của người dùng ngược lại trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// đổi mật khẩu người dùng 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
