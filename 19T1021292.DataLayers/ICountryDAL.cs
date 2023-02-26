using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DomainModels;
namespace _19T1021292.DataLayers
{   /// <summary>
/// định nghãi phép xử lý dữ liệu liên quan đến quốc gia
/// </summary>
    public interface ICountryDAL
    {
        /// <summary>
        /// lấy danh sách chức năng
        /// </summary>
        /// <returns></returns>
        IList<Country> List();
    }
}
