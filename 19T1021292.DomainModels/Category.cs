using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021292.DomainModels
{
    public class Category
    {/// <summary>
    ///  mã category
    /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// mô tả
        /// </summary>
        public string Description { get; set; }

    }
}
