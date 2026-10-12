using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Bài 7 - Tại lớp 1: Quản lý Môn học (bảng MonHoc).
    ///  - Thêm: Mã môn học, Tên môn học không được để trống.
    ///  - Xóa : chỉ cần Mã môn học (Tên môn học bỏ qua).
    ///  - Sửa : Mã môn học, Tên môn học không được để trống; đổi tên theo mã.
    /// Việc mở/đóng kết nối và ExecuteNonQuery nằm trong Db.Run (xem Db.cs).
    /// </summary>
    public class frmQLMonHoc : Form
    {
        private TextBox txtMaMH, txtTenMH;

        public frmQLMonHoc()
        {
            Text = "Quản lý môn học";
            ClientSize = new Size(340, 140);

            UI.Lbl(this, "Mã mh", 15, 15, 65);
            txtMaMH = UI.Txt(this, 90, 15, 225);
            UI.Lbl(this, "Tên mh", 15, 50, 65);
            txtTenMH = UI.Txt(this, 90, 50, 225);

            UI.Btn(this, "Thêm", 20, 95, 90, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 95, 90, btnXoa_Click);
            UI.Btn(this, "Sửa", 230, 95, 90, btnSua_Click);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim(), ten = txtTenMH.Text.Trim();
            if (ma == "" || ten == "")
            {
                UI.Warn("Mã môn học và Tên môn học không được để trống!");
                return;
            }
            Db.Run("INSERT INTO MonHoc(MaMonHoc, TenMonHoc) VALUES (@ma, @ten)",
                   "Thêm môn học thành công", null,
                   Db.P("@ma", ma), Db.P("@ten", ten));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim();
            if (ma == "")
            {
                UI.Warn("Mã môn học không được để trống!");
                return;
            }
            Db.Run("DELETE FROM MonHoc WHERE MaMonHoc = @ma",
                   "Xóa môn học thành công", "Không tìm thấy môn học có mã này!",
                   Db.P("@ma", ma));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim(), ten = txtTenMH.Text.Trim();
            if (ma == "" || ten == "")
            {
                UI.Warn("Mã môn học và Tên môn học không được để trống!");
                return;
            }
            Db.Run("UPDATE MonHoc SET TenMonHoc = @ten WHERE MaMonHoc = @ma",
                   "Sửa môn học thành công", "Không tìm thấy môn học có mã này!",
                   Db.P("@ten", ten), Db.P("@ma", ma));
        }
    }
}
