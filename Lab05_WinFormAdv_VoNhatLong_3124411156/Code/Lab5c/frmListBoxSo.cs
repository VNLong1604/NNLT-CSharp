using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài về nhà 2: Xử lý ListBox các số tự nhiên (chọn nhiều phần tử).
    /// Các phần tử được lưu trong ListBox dưới dạng kiểu long.
    /// Các phép tính dùng checked để báo lỗi tràn số thay vì cho ra kết quả sai.
    /// </summary>
    public class frmListBoxSo : Form
    {
        private TextBox txtN;
        private ListBox lst;

        public frmListBoxSo()
        {
            Text = "frmListbox";
            ClientSize = new Size(560, 420);

            Label tieuDe = new Label();
            tieuDe.Text = "LISTBOX";
            tieuDe.Font = new Font("Tahoma", 20F, FontStyle.Bold);
            tieuDe.ForeColor = Color.DarkOrange;
            tieuDe.TextAlign = ContentAlignment.MiddleCenter;
            tieuDe.SetBounds(15, 5, 530, 40);
            Controls.Add(tieuDe);

            GroupBox g1 = new GroupBox();
            g1.Text = "Listbox";
            g1.SetBounds(15, 50, 200, 300);
            Controls.Add(g1);

            txtN = UI.Txt(g1, 15, 25, 170);
            Button btnNhap = UI.Btn(g1, "&Nhập", 15, 55, 170, btnNhap_Click);
            AcceptButton = btnNhap;

            lst = new ListBox();
            lst.SetBounds(15, 95, 170, 190);
            lst.SelectionMode = SelectionMode.MultiExtended;
            g1.Controls.Add(lst);

            GroupBox g2 = new GroupBox();
            g2.Text = "Xử lý Listbox";
            g2.SetBounds(230, 50, 315, 300);
            Controls.Add(g2);

            int y = 25, d = 38;
            UI.Btn(g2, "Tổng các phần tử trong List", 15, y, 285, btnTong_Click);
            UI.Btn(g2, "Xóa Phần tử đầu và cuối", 15, y + d, 285, btnXoaDauCuoi_Click);
            UI.Btn(g2, "Xóa Phần tử đang chọn", 15, y + 2 * d, 285, btnXoaChon_Click);
            UI.Btn(g2, "Tăng mỗi phần tử lên 2", 15, y + 3 * d, 285, btnTang2_Click);
            UI.Btn(g2, "Thay bằng bình phương", 15, y + 4 * d, 285, btnBinhPhuong_Click);
            UI.Btn(g2, "Chọn số chẵn", 15, y + 5 * d, 285, (s, e) => ChonTheoDieuKien(true));
            UI.Btn(g2, "Chọn số lẻ", 15, y + 6 * d, 285, (s, e) => ChonTheoDieuKien(false));

            UI.Btn(this, "KẾT THÚC", 15, 365, 530, (s, e) =>
            {
                if (UI.Confirm("Bạn có chắc muốn kết thúc?")) Close();
            });
        }

        // Thêm số tự nhiên N từ textbox vào listbox
        private void btnNhap_Click(object sender, EventArgs e)
        {
            long n;
            // Kiểm tra là số tự nhiên; giới hạn 1 tỉ để phép bình phương không tràn kiểu long
            if (!long.TryParse(txtN.Text.Trim(), out n) || n < 0 || n > 1000000000)
            {
                UI.Warn("Vui lòng nhập một số tự nhiên hợp lệ (0 đến 1.000.000.000)!");
                txtN.SelectAll();
                txtN.Focus();
                return;
            }
            lst.Items.Add(n);
            txtN.Clear();
            txtN.Focus();
        }

        private bool ListRong()
        {
            if (lst.Items.Count == 0)
            {
                UI.Warn("Danh sách đang rỗng!");
                return true;
            }
            return false;
        }

        // Tính tổng các phần tử và hiển thị bằng MessageBox
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (ListRong()) return;
            try
            {
                long tong = 0;
                foreach (object o in lst.Items) tong = checked(tong + (long)o);
                MessageBox.Show("Tổng các phần tử trong ListBox là: " + tong);
            }
            catch (OverflowException) { UI.Warn("Kết quả vượt quá giới hạn kiểu số!"); }
        }

        // Xóa phần tử đầu và cuối
        private void btnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (ListRong()) return;
            lst.Items.RemoveAt(lst.Items.Count - 1);          // xóa cuối trước để chỉ số đầu không đổi
            if (lst.Items.Count > 0) lst.Items.RemoveAt(0);   // xóa đầu (nếu còn)
        }

        // Xóa các phần tử đang chọn (duyệt từ cuối về đầu)
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndices.Count == 0)
            {
                UI.Warn("Vui lòng chọn phần tử cần xóa!");
                return;
            }
            for (int i = lst.Items.Count - 1; i >= 0; i--)
                if (lst.GetSelected(i)) lst.Items.RemoveAt(i);
        }

        // Tăng giá trị mỗi phần tử lên 2
        private void btnTang2_Click(object sender, EventArgs e)
        {
            if (ListRong()) return;
            try
            {
                long[] moi = new long[lst.Items.Count];
                for (int i = 0; i < moi.Length; i++) moi[i] = checked((long)lst.Items[i] + 2);
                for (int i = 0; i < moi.Length; i++) lst.Items[i] = moi[i];
            }
            catch (OverflowException) { UI.Warn("Kết quả vượt quá giới hạn kiểu số!"); }
        }

        // Thay mỗi phần tử bằng bình phương của chính nó
        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            if (ListRong()) return;
            try
            {
                long[] moi = new long[lst.Items.Count];
                for (int i = 0; i < moi.Length; i++)
                {
                    long v = (long)lst.Items[i];
                    moi[i] = checked(v * v);
                }
                for (int i = 0; i < moi.Length; i++) lst.Items[i] = moi[i];
            }
            catch (OverflowException) { UI.Warn("Kết quả vượt quá giới hạn kiểu số! (hãy bớt các số quá lớn)"); }
        }

        // Chọn các phần tử là số chẵn (chan = true) hoặc số lẻ (chan = false)
        private void ChonTheoDieuKien(bool chan)
        {
            if (ListRong()) return;
            lst.ClearSelected();
            for (int i = 0; i < lst.Items.Count; i++)
            {
                bool laChan = (long)lst.Items[i] % 2 == 0;
                if (laChan == chan) lst.SetSelected(i, true);
            }
        }
    }
}
