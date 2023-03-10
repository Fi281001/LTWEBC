using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021292.DomainModels;
using _19T1021292.DataLayers;
using System.Configuration;
namespace _19T1021292.BusinessLayer
{
    /// <summary>
    /// cung cấp các chức năng nghiệp vu xử lý dữ liệu chung lien quan đến quốc gia nhà cung cấp khách hàng người gaiao hàng nhân viên loại hàng
    /// </summary>
    public static class CommonDataService
    {
        private static readonly ICountryDAL countryDB;
        private static readonly ICommonDAL<Supplier> suplierDB;
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Shipper> shipperDB;
        private static readonly ICommonDAL<Employee> employyeeDB;
      
        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            countryDB = new DataLayers.SQLServer.CountryDAL(connectionstring);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionstring);
            suplierDB = new DataLayers.SQLServer.SupplierDAL(connectionstring);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionstring);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionstring);
            employyeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionstring);
            
        }
        #region xử lý liên quan đến quốc gia
        // lấy danh sách quốc gia
          public static List<Country> ListOfCoutries()
        {
            return countryDB.List().ToList();
        }
        #endregion

        #region xử lý nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân rang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đâu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = suplierDB.Count(searchValue);

            return suplierDB.List(page, pageSize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue = "")
        {
            return suplierDB.List(1, 0, searchValue).ToList();
        }

        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return suplierDB.Getn(supplierID);
        }

        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return suplierDB.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return suplierDB.Update(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            return suplierDB.Delete(supplierID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierID)
        {
            return suplierDB.Inused(supplierID);
        }

        #endregion

        #region xử lý khách hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân rang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đâu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);

            return customerDB.List(page, pageSize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(string searchValue = "")
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }

        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int CustomerID)
        {
            return customerDB.Getn(CustomerID);
        }

        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomers(Customer data)
        {
            return customerDB.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomers(int CustomerID)
        {
            return customerDB.Delete(CustomerID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomers(int CustomerID)
        {
            return customerDB.Inused(CustomerID);
        }

        #endregion


        #region xử lý category
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân rang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đâu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);

            return categoryDB.List(page, pageSize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(string searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }

        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int CategoryID)
        {
            return categoryDB.Getn(CategoryID);
        }

        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int CategoryID)
        {
            return categoryDB.Delete(CategoryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int CategoryID)
        {
            return categoryDB.Inused(CategoryID);
        }

        #endregion

        #region xử lý employye
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân rang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đâu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employyeeDB.Count(searchValue);

            return employyeeDB.List(page, pageSize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue = "")
        {
            return employyeeDB.List(1, 0, searchValue).ToList();
        }
       
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int EmployeeID)
        {
            return employyeeDB.Getn(EmployeeID);
        }

        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employyeeDB.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employyeeDB.Update(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int EmployeeID)
        {
            return employyeeDB.Delete(EmployeeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static bool InUsedCEmployee(int EmployeeID)
        {
            return employyeeDB.Inused(EmployeeID);
        }

        #endregion

        #region xử lý Shipper
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân rang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đâu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShipperes(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);

            return shipperDB.List(page, pageSize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không phân trang)</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShipperes(string searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }

        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int ShipperID)
        {
            return shipperDB.Getn(ShipperID);
        }

        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteShippers(int ShipperID)
        {
            return shipperDB.Delete(ShipperID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int ShipperID)
        {
            return shipperDB.Inused(ShipperID);
        }

        #endregion
    }
}
