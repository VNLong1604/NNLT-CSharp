using System;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Form chính (MDI) có MenuStrip, gắn tất cả bài tập của Lab 5c, 5d và Bài 7.
    /// Chọn mục menu -> tạo form tương ứng và hiển thị bên trong form chính
    /// (đáp ứng "Bài tập về nhà - Bài 2" của Lab 5d).
    /// </summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "Lab 05 - Lập trình Windows Form nâng cao";
            IsMdiContainer = true;                       // cho phép hiển thị form con bên trong
            WindowState = FormWindowState.Maximized;

            MenuStrip ms = new MenuStrip();
            MainMenuStrip = ms;

            // ---------- Lab 5c ----------
            ToolStripMenuItem m5c = new ToolStripMenuItem("Lab 5c");
            Them(m5c, "Mẫu 1 - ListBox chuyển qua lại", () => new frmListBox());
            Them(m5c, "Mẫu 2 - ComboBox dân tộc", () => new frmComboBox());
            Them(m5c, "Mẫu 3 - TreeView phòng ban - nhân viên", () => new frmTreeView());
            Them(m5c, "Tại lớp 1 - Ước số", () => new frmUocSo());
            Them(m5c, "Tại lớp 2 - Quản lý sinh viên (TreeView)", () => new frmQLSVLop());
            Them(m5c, "Nâng cao 1 - Xử lý chuỗi", () => new frmXuLyChuoi());
            Them(m5c, "Về nhà 1 - Từ điển Anh - Việt", () => new frmTuDien());
            Them(m5c, "Về nhà 2 - ListBox số tự nhiên", () => new frmListBoxSo());
            Them(m5c, "Về nhà 3 - Danh bạ", () => new frmDanhBa());

            // ---------- Lab 5d ----------
            ToolStripMenuItem m5d = new ToolStripMenuItem("Lab 5d");
            Them(m5d, "Mẫu 1 - Timer đồng hồ", () => new frmDemoTimer());
            Them(m5d, "Mẫu 2 - ListView sinh viên", () => new frmListViewSV());
            Them(m5d, "Mẫu 3 - Lưu / Mở file text", () => new frmSaveOpenFile());
            Them(m5d, "Tại lớp 1 - Quản lý sinh viên (ListView)", () => new frmBaitap1());
            Them(m5d, "Tại lớp 2 - Quản lý tài khoản ngân hàng", () => new frmBaiTap2());
            Them(m5d, "Nâng cao 1 - Quản lý học viên", () => new frmQuanLyHocVien());
            Them(m5d, "Về nhà 1 - Đồng hồ đếm ngược", () => new frmDongHo());

            // ---------- Bài 7: ADO.NET ----------
            ToolStripMenuItem m7 = new ToolStripMenuItem("Bài 7 - ADO.NET");
            Them(m7, "Mẫu - Quản lý Khoa", () => new frmQLKhoa());
            Them(m7, "Tại lớp 1 - Quản lý Môn học", () => new frmQLMonHoc());
            Them(m7, "Nâng cao 1 - Quản lý Sinh viên", () => new frmQLSinhVien());
            Them(m7, "Nâng cao 2 - Quản lý Điểm", () => new frmQLDiem());
            Them(m7, "Về nhà 1 - Quản lý Lớp", () => new frmQLLop());

            ToolStripMenuItem mThoat = new ToolStripMenuItem("Thoát");
            mThoat.Click += (s, e) =>
            {
                if (UI.Confirm("Bạn có chắc muốn thoát chương trình?")) Close();
            };

            ms.Items.AddRange(new ToolStripItem[] { m5c, m5d, m7, mThoat });
            Controls.Add(ms);
        }

        /// <summary>Thêm 1 mục vào menu; khi click sẽ tạo form bằng factory và hiển thị như form con MDI.</summary>
        private void Them(ToolStripMenuItem parent, string text, Func<Form> factory)
        {
            parent.DropDownItems.Add(text, null, (s, e) =>
            {
                Form f = factory();
                f.MdiParent = this;
                f.Show();
            });
        }
    }
}
