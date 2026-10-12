using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài mẫu 2: ListView hiển thị Mã SV, Họ tên với 3 nút Thêm / Xóa / Sửa.
    /// Có kiểm tra trùng mã số sinh viên trước khi thêm (theo ghi chú của đề).
    /// </summary>
    public class frmListViewSV : Form
    {
        private TextBox txtmssv, txthoten;
        private ListView lstv1;

        public frmListViewSV()
        {
            Text = "ListView";
            ClientSize = new Size(480, 340);

            UI.Btn(this, "Thêm", 15, 10, 110, btnthem_Click);
            UI.Btn(this, "Xóa", 140, 10, 110, btnxoa_Click);
            UI.Btn(this, "Sửa", 265, 10, 110, btnsua_Click);

            UI.Lbl(this, "Mã SV", 40, 55, 80);
            txtmssv = UI.Txt(this, 130, 55, 330);
            UI.Lbl(this, "Họ tên", 40, 90, 80);
            txthoten = UI.Txt(this, 130, 90, 330);

            lstv1 = new ListView();
            lstv1.SetBounds(15, 130, 450, 195);
            lstv1.View = View.Details;          // Bước 1: chế độ hiển thị Details
            lstv1.Columns.Add("MÃ SỐ SV", 120); // Bước 2: thiết kế cột
            lstv1.Columns.Add("HỌ VÀ TÊN", 300);
            lstv1.GridLines = true;             // Bước 3: GridLines, FullRowSelect
            lstv1.FullRowSelect = true;
            lstv1.SelectedIndexChanged += lstv1_SelectedIndexChanged;
            Controls.Add(lstv1);
        }

        // Kiểm tra mã sinh viên đã có trong danh sách chưa (bỏ qua item "boQua" khi sửa)
        private bool TrungMa(string ma, ListViewItem boQua)
        {
            foreach (ListViewItem it in lstv1.Items)
                if (it != boQua && string.Compare(it.Text, ma, true) == 0)
                    return true;
            return false;
        }

        // Nút Thêm
        private void btnthem_Click(object sender, EventArgs e)
        {
            string ma = txtmssv.Text.Trim(), ten = txthoten.Text.Trim();
            if (ma == "" || ten == "")
            {
                UI.Warn("Vui lòng nhập Mã SV và Họ tên!");
                return;
            }
            if (TrungMa(ma, null))
            {
                UI.Warn("Mã số sinh viên đã tồn tại!");
                txtmssv.Focus();
                return;
            }

            // Có 3 cách thêm dòng vào ListView (theo tài liệu):
            // cách 1: lstv1.Items.Add(ma).SubItems.Add(ten);
            // cách 2: tạo ListViewItem + ListViewSubItem rồi Add từng bước
            // cách 3 (dùng ở đây): tạo ListViewItem từ mảng chuỗi, mỗi phần tử là 1 cột
            ListViewItem item1 = new ListViewItem(new[] { ma, ten });
            lstv1.Items.Add(item1);

            txtmssv.Clear();
            txthoten.Clear();
            txtmssv.Focus();
        }

        // Nút Xóa: xóa các dòng đang chọn
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (lstv1.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn dòng cần xóa!");
                return;
            }
            // Sao chép ra mảng tạm rồi mới xóa, tránh sửa tập hợp đang duyệt
            ListViewItem[] chon = new ListViewItem[lstv1.SelectedItems.Count];
            lstv1.SelectedItems.CopyTo(chon, 0);
            foreach (ListViewItem l in chon)
                l.Remove();
            txtmssv.Clear();
            txthoten.Clear();
        }

        // Nút Sửa: cập nhật dòng đang chọn bằng nội dung trong textbox
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (lstv1.FocusedItem != null && lstv1.SelectedItems.Count > 0)
            {
                ListViewItem item = lstv1.FocusedItem;
                string ma = txtmssv.Text.Trim(), ten = txthoten.Text.Trim();
                if (ma == "" || ten == "")
                {
                    UI.Warn("Vui lòng nhập Mã SV và Họ tên!");
                    return;
                }
                if (TrungMa(ma, item))
                {
                    UI.Warn("Mã số sinh viên đã tồn tại ở dòng khác!");
                    return;
                }
                item.SubItems[0].Text = ma;     // cột 0: Mã SV
                item.SubItems[1].Text = ten;    // cột 1: Họ tên
            }
            else
                UI.Warn("Vui lòng chọn dòng cần sửa!");
        }

        // Click một dòng -> hiển thị lên textbox để sửa
        private void lstv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv1.SelectedItems.Count > 0)
            {
                txtmssv.Text = lstv1.SelectedItems[0].SubItems[0].Text;
                txthoten.Text = lstv1.SelectedItems[0].SubItems[1].Text;
            }
        }
    }
}
