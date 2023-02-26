using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DomainModels;
namespace _19T1021292.DataLayers
{
    /// <summary>
    ///  định nghĩa các phép xử lý dữ liệu chung
    /// </summary>
    public interface ICommonDAL<T> where T: class
    {/// <summary>
     /// tìm kiếm và lấy danh sách dưới dạng phân trang
     /// </summary>
     /// <param name="page">trang cần hiển thị</param>
     /// <param name="pagesize">số dòng hiển thị trên 1 trang (bằng 0 nếu không phân trang)</param>
     /// <param name="searchvalue">giá trị cần tìm (chuỗi rỗng nếu không tìm kiếm, tức là truy vấn toàn bộ dữ liệu)</param>
     /// <returns></returns>
        IList<T> List(int page = 1, int pagesize = 0, string searchvalue = "", int rowCount = 0);
        /// <summary>
        /// đếm số dòng dữ liệu
        /// </summary>
        /// <param name="searchvalue">giá trị cần tìm (chuỗi rỗng nếu không tìm kiếm, tức là truy vấn toàn bộ dữ liệu)</param>
        /// <returns></returns>
        int Count(String searchvalue = "");
        /// <summary>
        /// lấy một dòng dữ liệu vào id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Getn(int id);
        /// <summary>
        /// bổ sung dữ liệu vào cơ sở dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ID của dữ liệu vừa bổ sung</returns>
        int Add(T data);
        /// <summary>
        /// cập nhâp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// kiểm tra xem hiện có dữ liệu khác liên quan đến dữ liệu có mã là id hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Inused(int id);
    }
}
