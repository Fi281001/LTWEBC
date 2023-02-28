using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using _19T1021292.DomainModels;

namespace _19T1021292.Web
{
    /// <summary>
    /// lớp cung cấp các hàm chuyển đổi dữ liệu
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// chuyển chuyển ngày dạng dd/mm/yyyy sang giá trị ngày và trả về
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? DMYStringToDateTime(string s, string format = "d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }

        }
        public static UserAccount CookieToUserAccount(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccount>(value);
        }
    }
}