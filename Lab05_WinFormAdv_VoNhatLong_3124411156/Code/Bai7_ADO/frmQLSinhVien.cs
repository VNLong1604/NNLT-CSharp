using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Bài 7 - Nâng cao 1: Quản lý Sinh viên (bảng SinhVien).
    ///  - Thêm: Mã lớp, Mã sinh viên, Tên sinh viên, Ngày sinh đều bắt buộc.
    ///  - Xóa : cần Mã sinh viên + Tên sinh viên (xóa dòng khớp cả 2); Mã lớp, Ngày sinh bỏ qua.
    ///  - Sửa : cần Mã sinh viên; Mã lớp / Tên / Ngày sinh nhập trường nào thì đổi trường đó, ít nhất 1 trường.
    /// Ngày sinh nhập bằng MaskedTextBox dạng dd/MM/yyyy.
    /// </summary>
    public class frmQLSinhVien : Form
    {
        private TextBox txtMaLop, txtMaSV, txtHoTen;
        private MaskedTextBox mtbNgaySinh;

        public frmQLSinhVien()
        {
            Text = "Quản lý sinh viên";
            ClientSize = new Size(340, 215);

            UI.Lbl(this, "Mã lớp", 15, 15, 70);
            txtMaLop = UI.Txt(this, 95, 15, 220);
            UI.Lbl(this, "Mã sv", 15, 50, 70);
            txtMaSV = UI.Txt(this, 95, 50, 220);
            UI.Lbl(this, "Họ tên", 15, 85, 70);
            txtHoTen = UI.Txt(this, 95, 85, 220);
            UI.Lbl(this, "Ngày sinh", 15, 120, 70);

            mtbNgaySinh = new MaskedTextBox();
            mtbNgaySinh.Mask = "00/00/0000";                                      // dd/MM/yyyy
            mtbNgaySinh.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;     // Text chỉ còn các chữ số: ddMMyyyy
            mtbNgaySinh.SetBounds(95, 120, 220, 24);
            Controls.Add(mtbNgaySinh);

            UI.Btn(this, "Thêm", 20, 165, 90, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 165, 90, btnXoa_Click);
            UI.Btn(this, "Sửa", 230, 165, 90, btnSua_Click);
        }

        /// <summary>
        /// Đọc ngày sinh từ MaskedTextBox.
        /// Trả về false nếu có nhập nhưng sai định dạng/ngày không tồn tại; coNgay = false nếu để trống.
        /// </summary>
        private bool DocNgay(out bool coNgay, out DateTime ngay)
        {
            string s = mtbNgaySinh.Text.Trim();       // chỉ còn chữ số, ví dụ "15012003"
            ngay = DateTime.MinValue;
            coNgay = s.Length > 0;
            if (!coNgay) return true;
            if (DateTime.TryParseExact(s, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay))
                return true;
            UI.Warn("Ngày sinh không hợp lệ! Nhập theo dạng ngày/tháng/năm (ví dụ 15/01/2003).");
            mtbNgaySinh.Focus();
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string lop = txtMaLop.Text.Trim(), ma = txtMaSV.Text.Trim(), ten = txtHoTen.Text.Trim();
            bool coNgay; DateTime ngay;
            if (!DocNgay(out coNgay, out ngay)) return;

            if (lop == "" || ma == "" || ten == "" || !coNgay)
            {
                UI.Warn("Mã lớp, Mã sinh viên, Tên sinh viên, Ngày sinh không được để trống!");
                return;
            }
            Db.Run("INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES (@ma, @ten, @ns, @lop)",
                   "Thêm sinh viên thành công", null,
                   Db.P("@ma", ma), Db.P("@ten", ten), Db.PDate("@ns", ngay), Db.P("@lop", lop));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim(), ten = txtHoTen.Text.Trim();
            if (ma == "" || ten == "")
            {
                UI.Warn("Mã sinh viên và Tên sinh viên không được để trống!");
                return;
            }
            // Xóa sinh viên có mã VÀ tên trùng với thông tin vừa nhập
            Db.Run("DELETE FROM SinhVien WHERE MaSinhVien = @ma AND HoTen = @ten",
                   "Xóa sinh viên thành công", "Không có sinh viên nào trùng cả mã và tên đã nhập!",
                   Db.P("@ma", ma), Db.P("@ten", ten));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string lop = txtMaLop.Text.Trim(), ma = txtMaSV.Text.Trim(), ten = txtHoTen.Text.Trim();
            bool coNgay; DateTime ngay;
            if (!DocNgay(out coNgay, out ngay)) return;

            if (ma == "")
            {
                UI.Warn("Mã sinh viên không được để trống!");
                return;
            }
            if (lop == "" && ten == "" && !coNgay)
            {
                UI.Warn("Phải nhập ít nhất một trong các trường: Mã lớp, Tên sinh viên, Ngày sinh!");
                return;
            }

            // Chỉ đưa vào mệnh đề SET những trường có nhập dữ liệu
            List<string> set = new List<string>();
            List<SqlParameter> ps = new List<SqlParameter>();
            if (lop != "") { set.Add("MaLop = @lop"); ps.Add(Db.P("@lop", lop)); }
            if (ten != "") { set.Add("HoTen = @ten"); ps.Add(Db.P("@ten", ten)); }
            if (coNgay) { set.Add("NgaySinh = @ns"); ps.Add(Db.PDate("@ns", ngay)); }
            ps.Add(Db.P("@ma", ma));

            Db.Run("UPDATE SinhVien SET " + string.Join(", ", set.ToArray()) + " WHERE MaSinhVien = @ma",
                   "Sửa sinh viên thành công", "Không tìm thấy sinh viên có mã này!",
                   ps.ToArray());
        }
    }
}
