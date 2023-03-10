using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021292.Web.Models
{
    /// <summary>
    /// lấy cơ sở dùng để biểu diễn kết quả tìm kiếm dưới dạng phân trang
    /// </summary>
    public abstract class PaginationSearchOutput
    {
        /// <summary>
        /// trang đang được hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// số dòng trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// giá trị tìm kiếm
        /// </summary>
        public string SearchValue { set; get; }
        /// <summary>
        /// số dòng dẽ liệu tìm được
        /// </summary>
        public int RowCount { get; set; }

        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 1;
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }
       
    }
}