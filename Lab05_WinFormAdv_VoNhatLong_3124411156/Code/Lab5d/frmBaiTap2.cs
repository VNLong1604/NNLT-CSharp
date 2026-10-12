using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài tập tại lớp 2: Quản lý thông tin tài khoản ngân hàng.
    ///  - Thêm: nút đổi thành "Hủy", bật nút Lưu, xóa trắng textbox, đặt con trỏ vào Số tài khoản.
    ///  - Lưu: lưu dữ liệu từ textbox vào ListView (STT tự động, Tổng tiền tự tính).
    ///  - Xóa: xóa dòng đang chọn (chỉ bật khi có dòng được chọn).
    ///  - Click 1 khách hàng trong ListView: hiển thị thông tin lên các textbox.
    /// Số tiền của mỗi dòng được lưu dạng decimal trong item.Tag để tính tổng chính xác.
    /// </summary>
    public class frmBaiTap2 : Form
    {
        private TextBox txtSoTK, txtTen, txtDiaChi, txtTien, txtTong;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lst;
        private bool dangThem = false;   // true: đang ở chế độ thêm mới (nút Thêm đang hiện chữ "Hủy")

        public frmBaiTap2()
        {
            Text = "frmBaiTap2";
            ClientSize = new Size(660, 460);

            Label tieuDe = new Label();
            tieuDe.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            tieuDe.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            tieuDe.ForeColor = Color.Blue;
            tieuDe.TextAlign = ContentAlignment.MiddleCenter;
            tieuDe.SetBounds(0, 12, 660, 40);
            Controls.Add(tieuDe);

            Label l1 = UI.Lbl(this, "Số tài khoản", 20, 70, 205);
            Label l2 = UI.Lbl(this, "Tên khách hàng", 20, 105, 205);
            Label l3 = UI.Lbl(this, "Địa chỉ khách hàng", 20, 140, 205);
            Label l4 = UI.Lbl(this, "Số tiền trong tài khoản", 20, 175, 205);
            foreach (Label l in new Label[] { l1, l2, l3, l4 }) l.TextAlign = ContentAlignment.MiddleRight;

            txtSoTK = UI.Txt(this, 235, 70, 395);
            txtTen = UI.Txt(this, 235, 105, 395);
            txtDiaChi = UI.Txt(this, 235, 140, 395);
            txtTien = UI.Txt(this, 235, 175, 395);
            txtTien.TextAlign = HorizontalAlignment.Right;

            btnThem = UI.Btn(this, "Thêm", 235, 215, 95, btnThem_Click);
            btnLuu = UI.Btn(this, "Lưu", 340, 215, 95, btnLuu_Click);
            btnXoa = UI.Btn(this, "Xóa", 445, 215, 95, btnXoa_Click);
            btnThoat = UI.Btn(this, "Thoát", 550, 215, 80, (s, e) => Close());

            lst = new ListView();
            lst.SetBounds(20, 255, 610, 150);
            lst.View = View.Details;
            lst.GridLines = true;
            lst.FullRowSelect = true;
            lst.MultiSelect = false;
            lst.Columns.Add("STT", 45);
            lst.Columns.Add("Số tài khoản", 120);
            lst.Columns.Add("Tên khách hàng", 170);
            lst.Columns.Add("Địa chỉ", 125);
            lst.Columns.Add("Số tiền", 130, HorizontalAlignment.Right);
            lst.SelectedIndexChanged += lst_SelectedIndexChanged;
            Controls.Add(lst);

            UI.Lbl(this, "Tổng tiền", 400, 420, 80).TextAlign = ContentAlignment.MiddleRight;
            txtTong = UI.Txt(this, 490, 420, 140);
            txtTong.ReadOnly = true;
            txtTong.TextAlign = HorizontalAlignment.Right;
            txtTong.Text = "0";

            // Trạng thái ban đầu khi load form: Lưu và Xóa bị vô hiệu hóa
            SetMode(false);
            btnXoa.Enabled = false;
        }

        // Chuyển giữa chế độ "Thêm" và "Hủy"
        private void SetMode(bool them)
        {
            dangThem = them;
            btnThem.Text = them ? "Hủy" : "Thêm";
            btnLuu.Enabled = them;
        }

        private void XoaTrang()
        {
            txtSoTK.Clear(); txtTen.Clear(); txtDiaChi.Clear(); txtTien.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!dangThem)
            {
                // Bấm "Thêm": đổi chữ thành "Hủy", bật Lưu, xóa trắng textbox, đặt con trỏ vào Số tài khoản
                SetMode(true);
                lst.SelectedItems.Clear();
                btnXoa.Enabled = false;
                XoaTrang();
                txtSoTK.Focus();
            }
            else
            {
                // Bấm "Hủy": quay về trạng thái ban đầu
                SetMode(false);
                XoaTrang();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string so = txtSoTK.Text.Trim(), ten = txtTen.Text.Trim(), dc = txtDiaChi.Text.Trim();
            if (so == "" || ten == "")
            {
                UI.Warn("Số tài khoản và Tên khách hàng không được để trống!");
                return;
            }
            foreach (ListViewItem it in lst.Items)
                if (it.SubItems[1].Text == so)
                {
                    UI.Warn("Số tài khoản đã tồn tại!");
                    txtSoTK.Focus();
                    return;
                }
            decimal tien;
            if (!decimal.TryParse(txtTien.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
                                  CultureInfo.InvariantCulture, out tien) || tien < 0)
            {
                UI.Warn("Số tiền phải là một số không âm!");
                txtTien.Focus();
                return;
            }

            // STT tự động = số dòng hiện có + 1
            ListViewItem item = new ListViewItem(new[]
            {
                (lst.Items.Count + 1).ToString(), so, ten, dc, tien.ToString("N0", CultureInfo.InvariantCulture)
            });
            item.Tag = tien;                  // lưu giá trị số để tính tổng
            lst.Items.Add(item);

            TinhTong();
            SetMode(false);
            XoaTrang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0) return;
            if (!UI.Confirm("Bạn có chắc muốn xóa khách hàng này?")) return;

            lst.SelectedItems[0].Remove();
            DanhLaiSTT();          // đánh lại STT sau khi xóa
            TinhTong();
            XoaTrang();
            btnXoa.Enabled = false;
        }

        private void DanhLaiSTT()
        {
            for (int i = 0; i < lst.Items.Count; i++)
                lst.Items[i].SubItems[0].Text = (i + 1).ToString();
        }

        private void TinhTong()
        {
            decimal tong = 0;
            foreach (ListViewItem it in lst.Items) tong += (decimal)it.Tag;
            txtTong.Text = tong.ToString("N0", CultureInfo.InvariantCulture);
        }

        // Click 1 khách hàng: hiển thị lên textbox; Xóa được bật khi có dòng chọn
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0)
            {
                btnXoa.Enabled = false;
                return;
            }
            SetMode(false);                    // đang xem dữ liệu -> thoát chế độ thêm
            ListViewItem it = lst.SelectedItems[0];
            txtSoTK.Text = it.SubItems[1].Text;
            txtTen.Text = it.SubItems[2].Text;
            txtDiaChi.Text = it.SubItems[3].Text;
            txtTien.Text = ((decimal)it.Tag).ToString("0.##", CultureInfo.InvariantCulture);
            btnXoa.Enabled = true;
        }
    }
}
