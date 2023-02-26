using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Controllers
{
    
    public class CustomerController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CUSTOMER_SEARCH = "CustomerCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;

            var data = CommonDataService.ListOfCustomers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.CustomerSearchOutput result = new Models.CustomerSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[CUSTOMER_SEARCH] = condition;

            return View(result);
        }
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            Models.PaginationSearchInput condition = Session[CUSTOMER_SEARCH] as Models.PaginationSearchInput;
            if (condition == null)
            {


                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }
            return View(condition);
        }
        ///
        public ActionResult Create()
        {
            var data = new Customer()
            {
                CustomerID = 0
            };

            ViewBag.Title = "Bổ sung khách hàng";
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetCustomer(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Cập nhập khách hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer data)//
        {
            if (data.CustomerID == 0)
            {
                CommonDataService.AddCustomers(data);
            }
            else
            {
                CommonDataService.UpdateCustomer(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCustomers(id);
                return RedirectToAction("Index");
            }

            var data = CommonDataService.GetCustomer(id);
            if (data == null)
                return RedirectToAction("Index");


            return View(data);
        }
    }
}