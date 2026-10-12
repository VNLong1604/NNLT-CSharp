using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Bài 7 - Nâng cao 2: Quản lý Điểm (bảng Diem, khóa chính gồm MaSinhVien + MaMonHoc).
    ///  - Thêm: Mã sinh viên, Mã môn học, Điểm đều bắt buộc.
    ///  - Xóa : cần Mã sinh viên + Mã môn học; Điểm bỏ qua.
    ///  - Sửa : cả 3 bắt buộc; Điểm chỉ được nhập số (chặn ký tự khác ngay khi gõ + kiểm tra 0..10).
    /// </summary>
    public class frmQLDiem : Form
    {
        private TextBox txtMaSV, txtMaMH, txtDiem;

        public frmQLDiem()
        {
            Text = "Quản lý Điểm";
            ClientSize = new Size(340, 175);

            UI.Lbl(this, "Mã sv", 15, 15, 65);
            txtMaSV = UI.Txt(this, 90, 15, 225);
            UI.Lbl(this, "Mã mh", 15, 50, 65);
            txtMaMH = UI.Txt(this, 90, 50, 225);
            UI.Lbl(this, "Điểm", 15, 85, 65);
            txtDiem = UI.Txt(this, 90, 85, 225);
            txtDiem.KeyPress += txtDiem_KeyPress;     // chỉ cho nhập số

            UI.Btn(this, "Thêm", 20, 130, 90, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 130, 90, btnXoa_Click);
            UI.Btn(this, "Sửa", 230, 130, 90, btnSua_Click);
        }

        // Chặn các ký tự không phải số / dấu thập phân / phím điều khiển (Backspace...)
        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;
        }

        // Đọc điểm: chấp nhận cả dấu , và . làm dấu thập phân; phải trong khoảng 0..10
        private bool DocDiem(out double diem)
        {
            string s = txtDiem.Text.Trim().Replace(',', '.');
            if (s != "" && double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out diem)
                && diem >= 0 && diem <= 10)
                return true;
            diem = 0;
            UI.Warn("Điểm phải được nhập và là một số từ 0 đến 10!");
            txtDiem.Focus();
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sv = txtMaSV.Text.Trim(), mh = txtMaMH.Text.Trim();
            if (sv == "" || mh == "")
            {
                UI.Warn("Mã sinh viên, Mã môn học, Điểm không được để trống!");
                return;
            }
            double diem;
            if (!DocDiem(out diem)) return;
            Db.Run("INSERT INTO Diem(MaSinhVien, MaMonHoc, Diem) VALUES (@sv, @mh, @diem)",
                   "Thêm điểm thành công", null,
                   Db.P("@sv", sv), Db.P("@mh", mh), Db.PFloat("@diem", diem));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sv = txtMaSV.Text.Trim(), mh = txtMaMH.Text.Trim();
            if (sv == "" || mh == "")
            {
                UI.Warn("Mã sinh viên và Mã môn học không được để trống!");
                return;
            }
            Db.Run("DELETE FROM Diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                   "Xóa điểm thành công", "Không tìm thấy điểm của sinh viên theo môn học này!",
                   Db.P("@sv", sv), Db.P("@mh", mh));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sv = txtMaSV.Text.Trim(), mh = txtMaMH.Text.Trim();
            if (sv == "" || mh == "")
            {
                UI.Warn("Mã sinh viên và Mã môn học không được để trống!");
                return;
            }
            double diem;
            if (!DocDiem(out diem)) return;
            Db.Run("UPDATE Diem SET Diem = @diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                   "Sửa điểm thành công", "Không tìm thấy điểm của sinh viên theo môn học này!",
                   Db.PFloat("@diem", diem), Db.P("@sv", sv), Db.P("@mh", mh));
        }
    }
}
