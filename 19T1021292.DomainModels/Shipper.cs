using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021292.DomainModels
{
   public class Shipper
    {/// <summary>
    /// mã shipper
    /// </summary>
        public int ShipperID { get; set; }
        /// <summary>
        /// tên shipper
        /// </summary>
        public string ShipperName { get; set; }
        /// <summary>
        /// số dth shipper
        /// </summary>
        public string Phone { get; set; }
    }
}
