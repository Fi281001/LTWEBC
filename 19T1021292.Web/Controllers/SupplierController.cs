using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;


namespace _19T1021292.Web.Controllers
{
    public class SupplierController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SUPPLIER_SEARCH = "SupplierCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /* public ActionResult Index(int page = 1, string searchValue= "")
         {
             int rowCount = 0;
             var data = CommonDataService.ListOfSuppliers(page, PAGE_SIZE, searchValue, out rowCount);

             int pageCount = rowCount / PAGE_SIZE;
             if (rowCount % PAGE_SIZE > 0)
                 pageCount += 1;
             ViewBag.Page = page;
             ViewBag.RowCount = rowCount;
             ViewBag.SearchValue = searchValue;
             ViewBag.PageCout = pageCount;
             return View(data);// truyền dữ liệu bằng model
         }*/
        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;

            var data = CommonDataService.ListOfSuppliers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.SupplierSearchOutput result = new Models.SupplierSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[SUPPLIER_SEARCH] = condition;

            return View(result);
        }
       public ActionResult Index()
        {
            Models.PaginationSearchInput condition = Session[SUPPLIER_SEARCH] as Models.PaginationSearchInput;
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

            var data = new Supplier()
            {
                SupplierID = 0
            };

            ViewBag.Title = "Bổ sung nhà cung cấp";
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

            var data = CommonDataService.GetSupplier(id);
            if( data == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Cập nhập nhà cung cấp";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Supplier data)//
        {
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.SupplierName))
            {
                ModelState.AddModelError(nameof(data.SupplierName), "Tên không được để trống");
            }
            if (String.IsNullOrWhiteSpace(data.ContacName))
            {
                ModelState.AddModelError(nameof(data.ContacName), "Tên giao dịch không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.Country))
            {
                ModelState.AddModelError(nameof(data.Country), "vui lòng chọn quốc gia");
            }

            data.Address = data.Address ?? "";
            data.Phone = data.Phone ?? "";
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";

            if(ModelState.IsValid == false)
            {
                ViewBag.Title = data.SupplierID == 0 ? "Bổ sung một nhà cung cấp" : "Cập nhập nhà cung cấp";
                return View("Edit",data);
            }

            if(data.SupplierID == 0)
            {
                CommonDataService.AddSupplier(data);
            }
            else
            {
                CommonDataService.UpdateSupplier(data);
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

            if(Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteSupplier(id);
                return RedirectToAction("Index");
            }

            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");


            return View(data);
        }
    }
}
