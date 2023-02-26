using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021292.DomainModels
{
    public class Customer
    {/// <summary>
    /// ma khách hàng
    /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// tên giao dịch
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// thành phố
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// quốc gia
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// code
        /// </summary>
        public string PostalCode { set; get; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get;  set; }

    }
}
