using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài tập tại lớp 1: Ước số.
    ///  - Nhập số (kiểm tra hợp lệ) -> "Cập nhật" thêm vào ComboBox (không trùng).
    ///  - Chọn 1 số trong ComboBox -> liệt kê các ước số vào ListBox.
    ///  - 3 nút tính: tổng các ước số, số lượng ước số chẵn, số lượng ước số nguyên tố (hiện bằng MessageBox).
    ///  - Thoát có xác nhận. HotKey: ký tự sau dấu & trong Text của button (Alt + ký tự).
    /// </summary>
    public class frmUocSo : Form
    {
        private TextBox txtSo;
        private ComboBox cboSo;
        private ListBox lstUoc;

        public frmUocSo()
        {
            Text = "Combobox";
            ClientSize = new Size(640, 330);

            GroupBox grpNhap = new GroupBox();
            grpNhap.Text = "Nhập Số";
            grpNhap.SetBounds(15, 10, 290, 130);
            Controls.Add(grpNhap);

            txtSo = UI.Txt(grpNhap, 15, 30, 100);
            Button btnCapNhat = UI.Btn(grpNhap, "&Cập nhật", 125, 28, 100, btnCapNhat_Click);
            AcceptButton = btnCapNhat;   // nhấn Enter = Cập nhật

            cboSo = new ComboBox();
            cboSo.SetBounds(15, 80, 210, 24);
            cboSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;
            grpNhap.Controls.Add(cboSo);

            GroupBox grpUoc = new GroupBox();
            grpUoc.Text = "Danh sách các ước số";
            grpUoc.SetBounds(325, 10, 300, 130);
            Controls.Add(grpUoc);

            lstUoc = new ListBox();
            lstUoc.SetBounds(15, 25, 270, 90);
            grpUoc.Controls.Add(lstUoc);

            // Ký tự đứng sau dấu & là HotKey của button
            UI.Btn(this, "&Tổng các ước số", 325, 155, 300, btnTong_Click);
            UI.Btn(this, "&Số lượng các ước số chẵn", 325, 195, 300, btnChan_Click);
            UI.Btn(this, "Số lượng các ước số &nguyên tố", 325, 235, 300, btnNguyenTo_Click);
            UI.Btn(this, "Th&oát", 225, 275, 90, btnThoat_Click);
        }

        // Thêm số vừa nhập vào combobox
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int n;
            // Kiểm tra dữ liệu nhập: phải là số nguyên dương
            if (!int.TryParse(txtSo.Text.Trim(), out n) || n <= 0)
            {
                UI.Warn("Vui lòng nhập một số nguyên dương hợp lệ!");
                txtSo.SelectAll();
                txtSo.Focus();
                return;
            }
            // Kiểm tra trùng trong combobox
            if (cboSo.Items.Contains(n))
            {
                UI.Warn("Số " + n + " đã tồn tại trong danh sách!");
            }
            else
            {
                cboSo.Items.Add(n);
            }
            txtSo.Clear();     // xóa textbox
            txtSo.Focus();     // đặt con trỏ lại textbox
        }

        // Chọn 1 số trong combobox -> liệt kê các ước số
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUoc.Items.Clear();
            if (cboSo.SelectedIndex < 0) return;
            int n = (int)cboSo.SelectedItem;

            List<int> uoc = new List<int>();
            for (int i = 1; (long)i * i <= n; i++)      // chỉ duyệt đến căn bậc hai của n
            {
                if (n % i == 0)
                {
                    uoc.Add(i);
                    if (i != n / i) uoc.Add(n / i);     // ước đối xứng
                }
            }
            uoc.Sort();
            foreach (int u in uoc) lstUoc.Items.Add(u);
        }

        private bool CoDuLieu()
        {
            if (lstUoc.Items.Count == 0)
            {
                UI.Warn("Vui lòng chọn một số trong combobox trước!");
                return false;
            }
            return true;
        }

        // Tổng các ước số (dựa vào listbox)
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (!CoDuLieu()) return;
            long tong = 0;
            foreach (object o in lstUoc.Items) tong += (int)o;
            MessageBox.Show("Tổng các ước số của " + cboSo.Text + " là: " + tong);
        }

        // Số lượng ước số chẵn
        private void btnChan_Click(object sender, EventArgs e)
        {
            if (!CoDuLieu()) return;
            int dem = 0;
            foreach (object o in lstUoc.Items) if ((int)o % 2 == 0) dem++;
            MessageBox.Show("Số lượng ước số chẵn của " + cboSo.Text + " là: " + dem);
        }

        // Số lượng ước số nguyên tố
        private void btnNguyenTo_Click(object sender, EventArgs e)
        {
            if (!CoDuLieu()) return;
            int dem = 0;
            foreach (object o in lstUoc.Items) if (LaNguyenTo((int)o)) dem++;
            MessageBox.Show("Số lượng ước số nguyên tố của " + cboSo.Text + " là: " + dem);
        }

        private static bool LaNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; (long)i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        // Thoát có xác nhận
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (UI.Confirm("Bạn có chắc muốn thoát?")) Close();
        }
    }
}
