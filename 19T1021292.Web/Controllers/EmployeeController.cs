using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 6;
        private const string EMPLOYYEE_SEARCH = "EmployyeeCondition";
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;

            var data = CommonDataService.ListOfEmployees(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.EmployyeeSearchOutput result = new Models.EmployyeeSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[EMPLOYYEE_SEARCH] = condition;

            return View(result);
        }
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            Models.PaginationSearchInput condition = Session[EMPLOYYEE_SEARCH] as Models.PaginationSearchInput;
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
        public ActionResult Create()
        {
            var data = new Employee()
            {
                EmployeeID = 0
            };

            ViewBag.Title = "Bổ sung nhân viên";
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

            var data = CommonDataService.GetEmployee(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Cập nhập nhân viên";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Employee data, string Birthday, HttpPostedFileBase uploadPhoto)//
        {
            DateTime? d = Converter.DMYStringToDateTime(Birthday);
            if (d == null)
            {
                ModelState.AddModelError("BirthDate", $"Ngày sinh {Birthday} không hợp lệ");
            }
            else
            {
                data.BirthDate = d.Value;
            }

            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.Email))
            {
                ModelState.AddModelError(nameof(data.Email), "Email không được để trống");
            }
            if (String.IsNullOrWhiteSpace(data.FirstName))
            {
                ModelState.AddModelError(nameof(data.FirstName), "Họ không được để trống");
            }
            if (String.IsNullOrWhiteSpace(data.LastName))
            {
                ModelState.AddModelError(nameof(data.LastName), "Tên không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.BirthDate.ToString()))
            {
                ModelState.AddModelError(nameof(data.BirthDate), "BirthDate không được để trống");
            }

            data.Notes = data.Notes ?? "";

            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string path = Server.MapPath("~/Images/Employees");
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"Images/Employees/{fileName}";
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.EmployeeID == 0 ? "Bổ sung một Nhân viên" : "Cập nhập nhân viên";
                return View("Edit", data);
            }
            if (data.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(data);
            }
            else
            {
                CommonDataService.UpdateEmployee(data);
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
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }

            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");


            return View(data);
        }
    }
}