using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Bài 7 - Bài mẫu: Quản lý Khoa (Thêm / Xóa / Sửa trên bảng Khoa của CSDL QLSinhVien).
    /// Form này viết đầy đủ từng bước theo tài liệu để thấy rõ quy trình dùng SqlConnection + SqlCommand:
    ///   1. Khai báo thư viện System.Data.SqlClient
    ///   2. Khai báo & khởi tạo SqlConnection với chuỗi kết nối
    ///   3. Kiểm tra State, mở kết nối
    ///   4. Tạo SqlCommand với câu lệnh SQL, gọi ExecuteNonQuery()
    ///   5. Đóng kết nối, thông báo kết quả
    /// Khác tài liệu: dùng tham số (@MaKhoa, @TenKhoa) thay vì nối chuỗi để không bị lỗi khi dữ liệu có dấu ' và tránh SQL Injection.
    /// </summary>
    public class frmQLKhoa : Form
    {
        private TextBox txtMaKhoa, txtTenKhoa;
        private SqlConnection conn;     // đối tượng kết nối (cách 1: Windows Authentication, xem Db.ConnString)

        public frmQLKhoa()
        {
            Text = "Quản lý Khoa";
            ClientSize = new Size(340, 140);

            UI.Lbl(this, "Mã khoa", 15, 15, 65);
            txtMaKhoa = UI.Txt(this, 90, 15, 225);
            UI.Lbl(this, "Tên khoa", 15, 50, 65);
            txtTenKhoa = UI.Txt(this, 90, 50, 225);

            UI.Btn(this, "Thêm", 20, 95, 90, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 95, 90, btnXoa_Click);
            UI.Btn(this, "Sửa", 230, 95, 90, btnSua_Click);

            // Bước 3: khởi tạo thông số cấu hình cho đối tượng kết nối
            conn = new SqlConnection(Db.ConnString);
        }

        /// <summary>Thực thi câu lệnh INSERT/UPDATE/DELETE theo đúng quy trình trong tài liệu.</summary>
        private void ThucThi(string sql, string thanhCong, string khongThay, params SqlParameter[] ps)
        {
            try
            {
                // Kiểm tra kết nối trước khi mở
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Khai báo command mới (chuỗi truy vấn + kết nối)
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                // Gọi ExecuteNonQuery để gửi command; trả về số dòng bị ảnh hưởng
                int soDong = cmd.ExecuteNonQuery();

                // Hiển thị thông báo
                if (soDong == 0 && khongThay != null) MessageBox.Show(khongThay);
                else MessageBox.Show(thanhCong);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất bại: " + Db.Explain(ex));
            }
            finally
            {
                // Kiểm tra kết nối trước khi đóng
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Thêm: INSERT INTO Khoa
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "" || txtTenKhoa.Text.Trim() == "")
            {
                UI.Warn("Vui lòng nhập Mã khoa và Tên khoa!");
                return;
            }
            string insertString = "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES (@MaKhoa, @TenKhoa)";
            ThucThi(insertString, "Thêm thành công", null,
                Db.P("@MaKhoa", txtMaKhoa.Text.Trim()), Db.P("@TenKhoa", txtTenKhoa.Text.Trim()));
        }

        // Xóa: DELETE ... WHERE MaKhoa = ... (chỉ cần Mã khoa)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "")
            {
                UI.Warn("Vui lòng nhập Mã khoa cần xóa!");
                return;
            }
            string deleteString = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";
            ThucThi(deleteString, "Xóa thành công", "Không tìm thấy khoa có mã này!",
                Db.P("@MaKhoa", txtMaKhoa.Text.Trim()));
        }

        // Sửa: UPDATE Khoa SET TenKhoa = ... WHERE MaKhoa = ...
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "" || txtTenKhoa.Text.Trim() == "")
            {
                UI.Warn("Vui lòng nhập Mã khoa và Tên khoa mới!");
                return;
            }
            string updateString = "UPDATE Khoa SET TenKhoa = @TenKhoa WHERE MaKhoa = @MaKhoa";
            ThucThi(updateString, "Sửa thành công", "Không tìm thấy khoa có mã này!",
                Db.P("@TenKhoa", txtTenKhoa.Text.Trim()), Db.P("@MaKhoa", txtMaKhoa.Text.Trim()));
        }
    }
}
