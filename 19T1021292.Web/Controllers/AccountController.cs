﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021292.Web.Controllers
{
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

        public ActionResult Login()
        {
            return View();
        }
    }
}