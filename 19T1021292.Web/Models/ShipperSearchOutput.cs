using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Models
{
    public class ShipperSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Shipper> Data { get; set; }
    }
}