using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Controllers
{
    public class ShipperController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SHIPPER_SEARCH = "ShipperCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;

            var data = CommonDataService.ListOfShipperes(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.ShipperSearchOutput result = new Models.ShipperSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[SHIPPER_SEARCH] = condition;

            return View(result);
        }
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            Models.PaginationSearchInput condition = Session[SHIPPER_SEARCH] as Models.PaginationSearchInput;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Shipper()
            {
                ShipperID = 0
            };

            ViewBag.Title = "Bổ sung Shipper";
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id =0 )
        {
            if (id <= 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetShipper(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Cập nhập Shipper";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Shipper data)//
        {
            if (data.ShipperID == 0)
            {
                CommonDataService.AddShipper(data);
            }
            else
            {
                CommonDataService.UpdateShipper(data);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0 )
        {
            if (id <= 0)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteShippers(id);
                return RedirectToAction("Index");
            }

            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");


            return View(data);
        }
    }
}