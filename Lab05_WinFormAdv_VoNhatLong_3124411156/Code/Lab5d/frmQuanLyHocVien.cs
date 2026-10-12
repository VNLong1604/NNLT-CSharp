using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài tập nâng cao 1: Quản lý học viên (Lớp A, Lớp B) bằng MenuStrip + 2 ListBox chọn nhiều.
    /// Menu "Cập nhật": Nhập học viên mới / Chuyển sang lớp B / Chuyển sang lớp A / Xóa học viên.
    /// Menu "Kết thúc": hỏi xác nhận rồi đóng.
    /// </summary>
    public class frmQuanLyHocVien : Form
    {
        private ListBox lstA, lstB;

        public frmQuanLyHocVien()
        {
            Text = "Quản lý học viên";
            ClientSize = new Size(440, 270);

            // ----- MenuStrip -----
            MenuStrip ms = new MenuStrip();
            ms.AllowMerge = false;     // giữ menu bên trong form con, không trộn vào menu form chính

            ToolStripMenuItem mCapNhat = new ToolStripMenuItem("Cập nhật");
            mCapNhat.DropDownItems.Add("Nhập học viên mới", null, mnuNhapMoi_Click);
            mCapNhat.DropDownItems.Add("Chuyển sang lớp B", null, mnuChuyenB_Click);
            mCapNhat.DropDownItems.Add("Chuyển sang lớp A", null, mnuChuyenA_Click);
            mCapNhat.DropDownItems.Add("Xóa học viên", null, mnuXoa_Click);

            ToolStripMenuItem mKetThuc = new ToolStripMenuItem("&Kết thúc");
            mKetThuc.Click += mnuKetThuc_Click;

            ms.Items.Add(mCapNhat);
            ms.Items.Add(mKetThuc);
            Controls.Add(ms);

            // ----- 2 GroupBox chứa ListBox, cho phép chọn nhiều mục -----
            GroupBox gA = new GroupBox();
            gA.Text = "Lớp A";
            gA.SetBounds(30, 45, 180, 200);
            Controls.Add(gA);
            lstA = new ListBox();
            lstA.SetBounds(10, 20, 160, 170);
            lstA.SelectionMode = SelectionMode.MultiExtended;
            lstA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            gA.Controls.Add(lstA);

            GroupBox gB = new GroupBox();
            gB.Text = "Lớp B";
            gB.SetBounds(230, 45, 180, 200);
            Controls.Add(gB);
            lstB = new ListBox();
            lstB.SetBounds(10, 20, 160, 170);
            lstB.SelectionMode = SelectionMode.MultiExtended;
            lstB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
            gB.Controls.Add(lstB);
        }

        /// <summary>Được form nhập học viên gọi để thêm học viên mới vào đúng lớp.</summary>
        public void ThemHocVien(string lop, string hoTen)
        {
            if (lop == "Lớp A") lstA.Items.Add(hoTen);
            else lstB.Items.Add(hoTen);
        }

        // Mở form nhập học viên mới (dạng hộp thoại)
        private void mnuNhapMoi_Click(object sender, EventArgs e)
        {
            frmNhapHocVien f = new frmNhapHocVien(this);
            f.ShowDialog(this);
        }

        // Chuyển các mục đang chọn từ lớp "tu" sang lớp "den"
        private void Chuyen(ListBox tu, ListBox den)
        {
            if (tu.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn học viên trước!");
                return;
            }
            // Copy ra mảng tạm vì không được xóa phần tử khi đang duyệt SelectedItems
            object[] chon = new object[tu.SelectedItems.Count];
            tu.SelectedItems.CopyTo(chon, 0);
            foreach (object o in chon)
            {
                den.Items.Add(o);
                tu.Items.Remove(o);
            }
        }

        private void mnuChuyenA_Click(object sender, EventArgs e) { Chuyen(lstB, lstA); }   // B -> A
        private void mnuChuyenB_Click(object sender, EventArgs e) { Chuyen(lstA, lstB); }   // A -> B

        // Xóa tất cả học viên đang chọn ở cả 2 lớp
        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (lstA.SelectedItems.Count == 0 && lstB.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn học viên trước!");
                return;
            }
            XoaDangChon(lstA);
            XoaDangChon(lstB);
        }

        private void XoaDangChon(ListBox lst)
        {
            for (int i = lst.Items.Count - 1; i >= 0; i--)    // duyệt ngược để chỉ số không bị lệch
                if (lst.GetSelected(i)) lst.Items.RemoveAt(i);
        }

        // Kết thúc: hỏi xác nhận rồi mới dừng (ở đây đóng form quản lý học viên)
        private void mnuKetThuc_Click(object sender, EventArgs e)
        {
            if (UI.Confirm("Bạn có chắc muốn kết thúc chương trình?"))
                Close();
        }
    }

    /// <summary>Form "Nhập học viên mới": nhập Họ tên + chọn Lớp, bấm Cập nhật để thêm vào form chính.</summary>
    public class frmNhapHocVien : Form
    {
        private frmQuanLyHocVien chinh;      // tham chiếu tới form chính để thêm dữ liệu
        private TextBox txtHoTen;
        private ComboBox cboLop;

        public frmNhapHocVien(frmQuanLyHocVien formChinh)
        {
            chinh = formChinh;
            Text = "Nhập học viên mới";
            ClientSize = new Size(380, 160);
            StartPosition = FormStartPosition.CenterParent;

            UI.Lbl(this, "Họ và Tên", 20, 22, 85);
            txtHoTen = UI.Txt(this, 110, 22, 240);

            UI.Lbl(this, "Lớp", 20, 62, 85);
            cboLop = new ComboBox();
            cboLop.SetBounds(110, 62, 240, 24);
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            cboLop.SelectedIndex = 0;
            Controls.Add(cboLop);

            UI.Btn(this, "Cập nhật", 110, 105, 110, btnCapNhat_Click);
            UI.Btn(this, "Trở về", 230, 105, 110, (s, e) => Close());   // đóng form nhập, trở về form chính
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                UI.Warn("Vui lòng nhập họ tên!");     // yêu cầu nhập họ tên
                txtHoTen.Focus();                      // đặt con trỏ vào textbox Họ và Tên
                return;
            }
            // Phụ thuộc lớp đã chọn: cập nhật họ tên vào listbox tương ứng trên form chính
            chinh.ThemHocVien(cboLop.Text, txtHoTen.Text.Trim());
            txtHoTen.Clear();
            txtHoTen.Focus();
        }
    }
}
