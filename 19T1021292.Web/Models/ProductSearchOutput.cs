using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021292.DomainModels;
namespace _19T1021292.Web.Models
{
    public class ProductSearchOutput : PaginationSearchOutput
    {
        public List<Product> Data { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }
}