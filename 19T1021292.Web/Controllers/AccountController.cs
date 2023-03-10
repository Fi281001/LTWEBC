using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập
        /// </summary>
        /// <returns></returns>
        /// 
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName="", string password = "")
        {
            ViewBag.UserName = userName;
            if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }

            var userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);
            if(userAccount == null)
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }
            // ghi cookie cho phiên đăng nhập
            string cookieString = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount);

            FormsAuthentication.SetAuthCookie(cookieString, false);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Change()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChangePassword(string UserName, string oldPassword, string newPassword, string PasswordAgain)
        {
            if (newPassword != PasswordAgain)
            {
                ModelState.AddModelError("", "Nhập lại mật khẩu không đúng");
                return View("Change");
            }
            bool changePass = UserAccountService.ChangePassword(AccountTypes.Employee, UserName, oldPassword, newPassword);

            if (changePass == false)
            {
                ModelState.AddModelError("", "Sai mật khẩu cũ");
                return View("Change");
            }
            return RedirectToAction("Change");
        }
    }
}