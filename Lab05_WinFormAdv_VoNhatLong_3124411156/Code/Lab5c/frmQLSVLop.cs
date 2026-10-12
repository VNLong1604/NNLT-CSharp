using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài tập tại lớp 2: Quản lý sinh viên theo lớp bằng TreeView.
    /// Cấu trúc cây:  Danh sách lớp (gốc, Level 0)
    ///                 └ Lớp (Level 1)
    ///                     └ "MaSV, Họ tên" (Level 2, Tag = string[]{ma, ten, diachi})
    ///                         └ Địa chỉ (Level 3)
    /// </summary>
    public class frmQLSVLop : Form
    {
        private TreeView trv;
        private TreeNode root;
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen, txtDiaChi, txtTenLop;
        private CheckBox chkThemLop;
        private GroupBox grpLop;

        public frmQLSVLop()
        {
            Text = "Quản lý sinh viên";
            ClientSize = new Size(780, 450);

            // ----- TreeView bên trái -----
            trv = new TreeView();
            trv.SetBounds(10, 10, 300, 430);
            trv.AfterSelect += trv_AfterSelect;
            Controls.Add(trv);

            // Nạp sẵn một số lớp
            root = trv.Nodes.Add("Danh sách lớp");
            string[] lop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            cboLop = new ComboBox();
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(410, 16, 340, 24);
            foreach (string l in lop)
            {
                root.Nodes.Add(l);
                cboLop.Items.Add(l);
            }
            cboLop.SelectedIndex = 0;
            root.Expand();

            // ----- Bên phải -----
            UI.Lbl(this, "Chọn Lớp", 330, 16, 75);
            Controls.Add(cboLop);

            GroupBox grpSV = new GroupBox();
            grpSV.Text = "Thông tin sinh viên";
            grpSV.SetBounds(330, 50, 430, 230);
            Controls.Add(grpSV);
            UI.Lbl(grpSV, "Mã SV:", 15, 35, 70);
            txtMaSV = UI.Txt(grpSV, 95, 35, 315);
            UI.Lbl(grpSV, "Họ Tên:", 15, 80, 70);
            txtHoTen = UI.Txt(grpSV, 95, 80, 315);
            UI.Lbl(grpSV, "Địa Chỉ:", 15, 125, 70);
            txtDiaChi = UI.Txt(grpSV, 95, 125, 315);
            UI.Btn(grpSV, "Cập Nhật", 95, 175, 140, btnCapNhat_Click);
            UI.Btn(grpSV, "Xóa", 255, 175, 140, btnXoa_Click);

            // Checkbox "Thêm lớp": bật/tắt hiển thị nhóm "Thông tin lớp"
            chkThemLop = new CheckBox();
            chkThemLop.Text = "Thêm lớp";
            chkThemLop.SetBounds(330, 295, 120, 24);
            chkThemLop.CheckedChanged += (s, e) => grpLop.Visible = chkThemLop.Checked;
            Controls.Add(chkThemLop);

            grpLop = new GroupBox();
            grpLop.Text = "Thông tin lớp";
            grpLop.SetBounds(330, 325, 430, 75);
            grpLop.Visible = false;                      // ban đầu ẩn
            Controls.Add(grpLop);
            UI.Lbl(grpLop, "Tên lớp", 15, 28, 70);
            txtTenLop = UI.Txt(grpLop, 95, 28, 170);
            UI.Btn(grpLop, "Thêm lớp", 285, 26, 125, btnThemLop_Click);
        }

        // ---------- Hàm hỗ trợ ----------
        private TreeNode TimLop(string ten)
        {
            foreach (TreeNode n in root.Nodes)
                if (n.Text == ten) return n;
            return null;
        }

        // Kiểm tra mã sinh viên đã tồn tại ở bất kỳ lớp nào chưa
        private bool MaSVTonTai(string ma)
        {
            foreach (TreeNode lop in root.Nodes)
                foreach (TreeNode sv in lop.Nodes)
                    if (string.Compare(((string[])sv.Tag)[0], ma, true) == 0)
                        return true;
            return false;
        }

        // Từ node đang chọn, trả về node sinh viên (Level 2) - hoặc null nếu không phải sinh viên
        private TreeNode NodeSinhVien(TreeNode n)
        {
            if (n == null) return null;
            if (n.Level == 2) return n;
            if (n.Level == 3) return n.Parent;   // chọn node địa chỉ thì lấy node sinh viên cha
            return null;
        }

        // ---------- Sự kiện ----------
        // Click node sinh viên -> hiển thị thông tin lên các textbox
        private void trv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sv = NodeSinhVien(e.Node);
            if (sv == null) return;
            string[] t = (string[])sv.Tag;
            txtMaSV.Text = t[0];
            txtHoTen.Text = t[1];
            txtDiaChi.Text = t[2];
            cboLop.SelectedItem = sv.Parent.Text;
        }

        // Thêm sinh viên vào lớp đang chọn trong combobox
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string dc = txtDiaChi.Text.Trim();

            // Kiểm tra dữ liệu: không để trống, không trùng mã sinh viên
            if (ma == "" || ten == "" || dc == "")
            {
                UI.Warn("Vui lòng nhập đầy đủ Mã SV, Họ Tên, Địa Chỉ!");
                return;
            }
            if (MaSVTonTai(ma))
            {
                UI.Warn("Mã sinh viên đã tồn tại!");
                txtMaSV.Focus();
                return;
            }
            TreeNode lop = TimLop(cboLop.Text);
            if (lop == null)
            {
                UI.Warn("Vui lòng chọn lớp!");
                return;
            }

            TreeNode sv = lop.Nodes.Add(ma + ", " + ten);       // node sinh viên
            sv.Tag = new string[] { ma, ten, dc };               // lưu dữ liệu để hiển thị lại khi click
            sv.Nodes.Add(dc);                                    // node con: địa chỉ
            lop.Expand();
            sv.Expand();

            txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
            txtMaSV.Focus();
        }

        // Xóa node sinh viên đang chọn (có xác nhận)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TreeNode sv = NodeSinhVien(trv.SelectedNode);
            if (sv == null)
            {
                UI.Warn("Chỉ được xóa node là sinh viên. Vui lòng chọn một sinh viên trên TreeView!");
                return;
            }
            if (UI.Confirm("Bạn có chắc muốn xóa sinh viên \"" + sv.Text + "\"?"))
            {
                sv.Remove();
                txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
            }
        }

        // Thêm lớp mới vào TreeView và ComboBox (kiểm tra trùng tên lớp)
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string ten = txtTenLop.Text.Trim();
            if (ten == "")
            {
                UI.Warn("Vui lòng nhập tên lớp!");
                txtTenLop.Focus();
                return;
            }
            foreach (TreeNode n in root.Nodes)
                if (string.Compare(n.Text, ten, true) == 0)
                {
                    UI.Warn("Tên lớp đã tồn tại!");
                    txtTenLop.Focus();
                    return;
                }
            root.Nodes.Add(ten);
            cboLop.Items.Add(ten);
            cboLop.SelectedItem = ten;
            root.Expand();
            txtTenLop.Clear();
            txtTenLop.Focus();
        }
    }
}
