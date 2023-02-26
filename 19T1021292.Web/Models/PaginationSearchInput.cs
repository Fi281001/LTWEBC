using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021292.Web.Models
{
    /// <summary>
    /// lưu trữ thông tin đầu vào để tìm kiếm và phân trnag (đơn giản)
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// trang cần hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// số dòng trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// giá trị cần tìm
        /// </summary>
        public string SearchValue { get; set; }
    }
}