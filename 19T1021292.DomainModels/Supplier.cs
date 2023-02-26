using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021292.DomainModels
{
    /// <summary>
    /// nhà cung cấp
    /// </summary>
    public class Supplier
    {/// <summary>
    /// mã nhà cung cấp
    /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// ten nhà cung cấp
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// tên giao dich
        /// </summary>
        public string ContacName { get; set; }
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
        /// phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }


    }
}
