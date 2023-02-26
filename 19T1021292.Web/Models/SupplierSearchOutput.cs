using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021292.DomainModels;

namespace _19T1021292.Web.Models
{
    /// <summary>
    /// lưu kết quả tìm kiếm, phan trang đối với nahf cung cấp
    /// </summary>
    public class SupplierSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Supplier> Data { get; set; }
    }
}