using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _19T1021292.DataLayers.SQLServer
{/// <summary>
/// lấy cơ sở cho các lớp cài đặt chức năng xử lý dữ liệu trên sql server
/// </summary>
   public abstract class _BaseDAL
    {
        /// <summary>
        /// chuỗi tham số kết nối sql
        /// </summary>
        protected string _connectionString;
        /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="connectionsString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// tao và kết nối tới SQL
        /// </summary>
        /// <returns></returns>
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
