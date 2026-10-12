using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Bài 7 - Về nhà 1: Quản lý Lớp (bảng Lop).
    ///  - Thêm: Mã khoa, Mã lớp, Tên lớp đều bắt buộc.
    ///  - Xóa : chỉ cần Mã lớp.
    ///  - Sửa : cần Mã lớp; Mã khoa, Tên lớp phải có ít nhất 1 trường, trường nào có dữ liệu mới đổi.
    /// </summary>
    public class frmQLLop : Form
    {
        private TextBox txtMaKhoa, txtMaLop, txtTenLop;

        public frmQLLop()
        {
            Text = "frmLop";
            ClientSize = new Size(340, 175);

            UI.Lbl(this, "Mã khoa", 15, 15, 65);
            txtMaKhoa = UI.Txt(this, 90, 15, 225);
            UI.Lbl(this, "Mã lớp", 15, 50, 65);
            txtMaLop = UI.Txt(this, 90, 50, 225);
            UI.Lbl(this, "Tên lớp", 15, 85, 65);
            txtTenLop = UI.Txt(this, 90, 85, 225);

            UI.Btn(this, "Thêm", 20, 130, 90, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 130, 90, btnXoa_Click);
            UI.Btn(this, "Sửa", 230, 130, 90, btnSua_Click);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string khoa = txtMaKhoa.Text.Trim(), lop = txtMaLop.Text.Trim(), ten = txtTenLop.Text.Trim();
            if (khoa == "" || lop == "" || ten == "")
            {
                UI.Warn("Mã khoa, Mã lớp, Tên lớp không được để trống!");
                return;
            }
            Db.Run("INSERT INTO Lop(MaLop, TenLop, MaKhoa) VALUES (@lop, @ten, @khoa)",
                   "Thêm lớp thành công", null,
                   Db.P("@lop", lop), Db.P("@ten", ten), Db.P("@khoa", khoa));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string lop = txtMaLop.Text.Trim();
            if (lop == "")
            {
                UI.Warn("Mã lớp không được để trống!");
                return;
            }
            Db.Run("DELETE FROM Lop WHERE MaLop = @lop",
                   "Xóa lớp thành công", "Không tìm thấy lớp có mã này!",
                   Db.P("@lop", lop));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string khoa = txtMaKhoa.Text.Trim(), lop = txtMaLop.Text.Trim(), ten = txtTenLop.Text.Trim();
            if (lop == "")
            {
                UI.Warn("Mã lớp không được để trống!");
                return;
            }
            if (khoa == "" && ten == "")
            {
                UI.Warn("Mã khoa, Tên lớp phải có ít nhất một trường có dữ liệu!");
                return;
            }

            List<string> set = new List<string>();
            List<SqlParameter> ps = new List<SqlParameter>();
            if (khoa != "") { set.Add("MaKhoa = @khoa"); ps.Add(Db.P("@khoa", khoa)); }
            if (ten != "") { set.Add("TenLop = @ten"); ps.Add(Db.P("@ten", ten)); }
            ps.Add(Db.P("@lop", lop));

            Db.Run("UPDATE Lop SET " + string.Join(", ", set.ToArray()) + " WHERE MaLop = @lop",
                   "Sửa lớp thành công", "Không tìm thấy lớp có mã này!",
                   ps.ToArray());
        }
    }
}
