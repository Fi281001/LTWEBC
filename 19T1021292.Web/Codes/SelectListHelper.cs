using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021292.BusinessLayer;
using _19T1021292.DomainModels;
using System.Web.Mvc;
namespace _19T1021292.Web
{
    /// <summary>
    /// danh sách quốc gia
    /// </summary>
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text ="--Chọn quốc gia--",
            });

            foreach(var item in CommonDataService.ListOfCoutries())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CountryName,
                    Text = item.CountryName
                });
            }

            return list;
        }
    }
}