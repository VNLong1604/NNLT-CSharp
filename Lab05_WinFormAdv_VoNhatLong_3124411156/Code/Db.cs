using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Lớp dùng chung cho Bài 7 (ADO.NET): chứa chuỗi kết nối và hàm thực thi câu lệnh
    /// Thêm/Xóa/Sửa bằng SqlConnection + SqlCommand.ExecuteNonQuery().
    /// </summary>
    public static class Db
    {
        // ===== SỬA CHUỖI KẾT NỐI CHO PHÙ HỢP MÁY CỦA BẠN =====
        // Cách 1: Windows Authentication. Thay ".\SQLEXPRESS" bằng tên server của bạn
        // (xem trong cửa sổ Connect to Server của SQL Server Management Studio).
        public static readonly string ConnString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True";

        // Cách 2: SQL Server Authentication (bỏ comment và điền thông tin nếu dùng)
        // public static readonly string ConnString =
        //     @"Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVien;User ID=sa;Password=mat_khau";

        /// <summary>Tạo tham số cho câu lệnh SQL (chuỗi sẽ được truyền dạng NVARCHAR, hỗ trợ tiếng Việt).</summary>
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <summary>Tạo tham số kiểu ngày.</summary>
        public static SqlParameter PDate(string name, DateTime value)
        {
            SqlParameter p = new SqlParameter(name, SqlDbType.Date);
            p.Value = value;
            return p;
        }

        /// <summary>Tạo tham số kiểu số thực (dùng cho cột Diem).</summary>
        public static SqlParameter PFloat(string name, double value)
        {
            SqlParameter p = new SqlParameter(name, SqlDbType.Float);
            p.Value = value;
            return p;
        }

        /// <summary>
        /// Thực thi 1 câu lệnh INSERT/UPDATE/DELETE và thông báo kết quả cho người dùng.
        /// Dùng tham số (@...) thay vì nối chuỗi để tránh lỗi cú pháp và tấn công SQL Injection.
        /// </summary>
        /// <param name="okMsg">Thông báo khi thành công.</param>
        /// <param name="notFoundMsg">Thông báo khi không có dòng nào bị ảnh hưởng (null = bỏ qua).</param>
        public static void Run(string sql, string okMsg, string notFoundMsg, params SqlParameter[] ps)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                // Kiểm tra trạng thái kết nối trước khi mở
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                int rows = cmd.ExecuteNonQuery();   // trả về số dòng bị ảnh hưởng

                if (rows == 0 && notFoundMsg != null) UI.Warn(notFoundMsg);
                else UI.Info(okMsg);
            }
            catch (SqlException ex)
            {
                UI.Warn(Explain(ex), "Thất bại");
            }
            catch (Exception ex)
            {
                UI.Warn(ex.Message, "Thất bại");
            }
            finally
            {
                // Luôn đóng kết nối (kể cả khi có lỗi)
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        /// <summary>Đổi mã lỗi SQL Server thành câu thông báo dễ hiểu.</summary>
        public static string Explain(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                case 2601:
                    return "Dữ liệu bị trùng khóa chính (mã đã tồn tại).";
                case 547:
                    return "Vi phạm ràng buộc khóa ngoại: mã tham chiếu không tồn tại, hoặc dữ liệu đang được bảng khác sử dụng.";
                case 2:
                case 53:
                case 18456:
                case 4060:
                    return "Không kết nối được cơ sở dữ liệu QLSinhVien. Hãy kiểm tra lại chuỗi kết nối trong file Db.cs.\n\nChi tiết: " + ex.Message;
                default:
                    return ex.Message;
            }
        }
    }
}
