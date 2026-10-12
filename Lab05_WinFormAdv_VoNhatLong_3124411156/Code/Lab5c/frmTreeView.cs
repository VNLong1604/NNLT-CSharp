using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài mẫu 3: Quản lý Phòng ban - Nhân viên bằng TreeView + ComboBox.
    ///  - Load form: nạp 4 phòng ban vào TreeView và ComboBox.
    ///  - Thêm phòng ban (kiểm tra trùng), xóa phòng ban (có xác nhận).
    ///  - Thêm nhân viên vào đúng phòng ban đang chọn trong ComboBox (node con của TreeView).
    /// </summary>
    public class frmTreeView : Form
    {
        private TreeView trv_DS;
        private TextBox txt_Phongban, txt_maso, txt_hoten, txt_diachi;
        private ComboBox cbo_phongban;

        public frmTreeView()
        {
            Text = "Phòng ban - Nhân viên";
            Font = new Font("Times New Roman", 11F);
            ClientSize = new Size(760, 470);

            // ----- Bên trái: nhóm Phòng ban -----
            GroupBox grp = new GroupBox();
            grp.Text = "Phòng ban";
            grp.SetBounds(10, 5, 250, 455);
            Controls.Add(grp);

            trv_DS = new TreeView();
            trv_DS.Name = "trv_DS";
            trv_DS.SetBounds(10, 25, 230, 320);
            grp.Controls.Add(trv_DS);

            UI.Lbl(grp, "Phòng ban", 10, 358, 80);
            txt_Phongban = UI.Txt(grp, 95, 358, 145);
            UI.Btn(grp, "Thêm phòng ban", 95, 392, 145, btn_ThemPB_Click);
            UI.Btn(grp, "Xóa phòng ban", 95, 422, 145, btn_XoaPB_Click);

            // ----- Bên phải: hồ sơ nhân viên -----
            Label tieuDe = new Label();
            tieuDe.Text = "HỒ SƠ NHÂN VIÊN";
            tieuDe.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            tieuDe.ForeColor = Color.Blue;
            tieuDe.SetBounds(280, 15, 400, 32);
            Controls.Add(tieuDe);

            UI.Lbl(this, "Mã số", 280, 70, 60);
            txt_maso = UI.Txt(this, 345, 70, 100);
            UI.Lbl(this, "Họ tên", 465, 70, 55);
            txt_hoten = UI.Txt(this, 525, 70, 215);

            UI.Lbl(this, "Địa chỉ", 280, 115, 60);
            txt_diachi = UI.Txt(this, 345, 115, 395);

            UI.Lbl(this, "Phòng ban", 280, 160, 70);
            cbo_phongban = new ComboBox();
            cbo_phongban.Name = "cbo_phongban";
            cbo_phongban.SetBounds(355, 160, 385, 24);
            cbo_phongban.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cbo_phongban);

            UI.Btn(this, "Thêm", 355, 205, 90, btn_ThemNV_Click);
            UI.Btn(this, "Thoát", 455, 205, 90, (s, e) => Close());

            Load += TreeView_Load;
            FormClosing += (s, e) =>
            {
                if (!UI.Confirm("Bạn có chắc muốn đóng form?")) e.Cancel = true;
            };
        }

        // Form Load: nạp sẵn 4 phòng ban vào TreeView và ComboBox
        private void TreeView_Load(object sender, EventArgs e)
        {
            string[] pb = { "Giám đốc", "Tổ chức hành chính", "Kế hoạch", "Kế Toán" };
            foreach (string s in pb)
            {
                trv_DS.Nodes.Add(s);          // thêm node vào treeview
                cbo_phongban.Items.Add(s);    // thêm item vào combobox
            }
            cbo_phongban.SelectedIndex = 0;   // chọn mục đầu tiên
        }

        /// <summary>Trả về true nếu phòng ban s CHƯA tồn tại (so sánh không phân biệt hoa/thường).</summary>
        private bool kiemtra(string s)
        {
            foreach (TreeNode n in trv_DS.Nodes)
                if (string.Compare(n.Text, s, true) == 0)
                    return false;
            return true;
        }

        // Thêm phòng ban mới vào TreeView và ComboBox
        private void btn_ThemPB_Click(object sender, EventArgs e)
        {
            string ten = txt_Phongban.Text.Trim();
            if (ten == "")
            {
                UI.Warn("Vui lòng nhập tên phòng ban.");
                txt_Phongban.Focus();
                return;
            }
            if (kiemtra(ten))
            {
                trv_DS.Nodes.Add(ten);
                cbo_phongban.Items.Add(ten);
            }
            else
                UI.Warn("Phòng ban đã tồn tại!");

            txt_Phongban.Text = "";
            txt_Phongban.Focus();
        }

        // Xóa phòng ban đang chọn trong TreeView (có xác nhận)
        private void btn_XoaPB_Click(object sender, EventArgs e)
        {
            TreeNode node = trv_DS.SelectedNode;
            if (node == null || node.Parent != null)   // phải chọn node phòng ban (node gốc)
            {
                UI.Warn("Vui lòng chọn một phòng ban trong TreeView để xóa.");
                return;
            }
            if (UI.Confirm("Bạn có chắc muốn xóa phòng ban \"" + node.Text + "\" (gồm cả nhân viên bên trong)?", "Thông báo"))
            {
                cbo_phongban.Items.Remove(node.Text);   // xóa khỏi combobox
                trv_DS.Nodes.Remove(node);              // xóa khỏi treeview
                if (cbo_phongban.Items.Count > 0) cbo_phongban.SelectedIndex = 0;
            }
        }

        // Thêm nhân viên vào phòng ban đang chọn trong combobox
        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            string ma = txt_maso.Text.Trim();
            string ten = txt_hoten.Text.Trim();
            if (ma == "" || ten == "")
            {
                UI.Warn("Vui lòng nhập Mã số và Họ tên.");
                return;
            }
            if (cbo_phongban.SelectedIndex < 0)
            {
                UI.Warn("Vui lòng chọn phòng ban.");
                return;
            }

            // Kiểm tra trùng mã số nhân viên (mã số được lưu trong Tag của node nhân viên)
            foreach (TreeNode pb in trv_DS.Nodes)
                foreach (TreeNode nv in pb.Nodes)
                    if (string.Compare((string)nv.Tag, ma, true) == 0)
                    {
                        UI.Warn("Mã số nhân viên đã tồn tại!");
                        return;
                    }

            // Tìm node phòng ban có nội dung trùng với item đang chọn trong combobox
            int index = -1;
            foreach (TreeNode node in trv_DS.Nodes)
                if (node.Text == cbo_phongban.Text)
                {
                    index = node.Index;
                    break;
                }
            if (index < 0) return;

            TreeNode nvMoi = trv_DS.Nodes[index].Nodes.Add(ten + " (" + ma + ")");
            nvMoi.Tag = ma;
            trv_DS.ExpandAll();   // mở rộng treeview

            txt_maso.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_maso.Focus();
        }
    }
}
