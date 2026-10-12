using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualBasic;   // Interaction.InputBox

namespace Lab05
{
    /// <summary>
    /// 5c - Bài tập nâng cao 1: Xử lý chuỗi trên ListBox.
    ///  - Tạo 50 tên ngẫu nhiên từ 3 mảng HO, TENLOT, TEN.
    ///  - Xóa phần tử đang chọn / có tên là "Sơn" / có họ là "Lê" / xóa tất cả.
    ///  - Đổi phần tử đang chọn thành CHỮ HOA / chữ thường / Viết Hoa Đầu Mỗi Từ.
    ///  - Double click vào tên: mở InputBox để đổi tên.
    /// </summary>
    public class frmXuLyChuoi : Form
    {
        private static readonly string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        private static readonly string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        private static readonly string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };

        private ListBox lstTen;
        private Random rnd = new Random();

        public frmXuLyChuoi()
        {
            Text = "frmChuoi";
            ClientSize = new Size(640, 440);

            UI.Btn(this, "Nhập tên ngẫu nhiên", 20, 12, 200, btnNgauNhien_Click);

            lstTen = new ListBox();
            lstTen.SetBounds(20, 60, 200, 360);
            lstTen.SelectionMode = SelectionMode.MultiExtended;     // chọn nhiều phần tử
            lstTen.MouseDoubleClick += lstTen_MouseDoubleClick;
            Controls.Add(lstTen);

            int x = 240, w = 370, y = 60, d = 52;
            UI.Btn(this, "Xóa Phần tử đang chọn", x, y, w, btnXoaChon_Click);
            UI.Btn(this, "Xóa phần tử có tên là Sơn", x, y + d, w, btnXoaTenSon_Click);
            UI.Btn(this, "Xóa Phần tử có họ là Lê", x, y + 2 * d, w, btnXoaHoLe_Click);
            UI.Btn(this, "Chuyển PT đang chọn thành chữ HOA", x, y + 3 * d, w, btnHoa_Click);
            UI.Btn(this, "Chuyển PT đang chọn thành chữ thường", x, y + 4 * d, w, btnThuong_Click);
            UI.Btn(this, "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ", x, y + 5 * d, w, btnHoaDau_Click);
            UI.Btn(this, "Xóa tất cả các Phần tử", x, y + 6 * d, w, (s, e) => lstTen.Items.Clear());
        }

        // Thêm 50 tên ngẫu nhiên: Họ + Tên lót + Tên
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                string ten = HO[rnd.Next(HO.Length)] + " "
                           + TENLOT[rnd.Next(TENLOT.Length)] + " "
                           + TEN[rnd.Next(TEN.Length)];
                lstTen.Items.Add(ten);
            }
        }

        // Xóa các phần tử đang chọn (duyệt từ cuối về đầu để chỉ số không bị lệch)
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            if (lstTen.SelectedIndices.Count == 0)
            {
                UI.Warn("Vui lòng chọn phần tử cần xóa!");
                return;
            }
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
                if (lstTen.GetSelected(i)) lstTen.Items.RemoveAt(i);
        }

        // Xóa phần tử có TÊN (từ cuối cùng) là "Sơn"
        private void btnXoaTenSon_Click(object sender, EventArgs e)
        {
            XoaTheoDieuKien(s =>
            {
                string[] p = s.Split(' ');
                return string.Compare(p[p.Length - 1], "Sơn", true) == 0;
            }, "Không có phần tử nào có tên là Sơn!");
        }

        // Xóa phần tử có HỌ (từ đầu tiên) là "Lê"
        private void btnXoaHoLe_Click(object sender, EventArgs e)
        {
            XoaTheoDieuKien(s => string.Compare(s.Split(' ')[0], "Lê", true) == 0,
                            "Không có phần tử nào có họ là Lê!");
        }

        private void XoaTheoDieuKien(Func<string, bool> dieuKien, string khongCo)
        {
            int dem = 0;
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
                if (dieuKien(lstTen.Items[i].ToString()))
                {
                    lstTen.Items.RemoveAt(i);
                    dem++;
                }
            if (dem == 0) UI.Info(khongCo);
        }

        private void btnHoa_Click(object sender, EventArgs e)
        {
            DoiChuoiDangChon(s => s.ToUpper());
        }

        private void btnThuong_Click(object sender, EventArgs e)
        {
            DoiChuoiDangChon(s => s.ToLower());
        }

        private void btnHoaDau_Click(object sender, EventArgs e)
        {
            // ToTitleCase chỉ viết hoa chữ cái đầu của mỗi từ khi phần còn lại là chữ thường
            DoiChuoiDangChon(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower()));
        }

        // Áp dụng hàm biến đổi cho các phần tử đang chọn và giữ nguyên trạng thái chọn
        private void DoiChuoiDangChon(Func<string, string> bienDoi)
        {
            if (lstTen.SelectedIndices.Count == 0)
            {
                UI.Warn("Vui lòng chọn phần tử cần chuyển đổi!");
                return;
            }
            List<int> chon = new List<int>();
            foreach (int i in lstTen.SelectedIndices) chon.Add(i);

            lstTen.BeginUpdate();
            foreach (int i in chon)
                lstTen.Items[i] = bienDoi(lstTen.Items[i].ToString());
            foreach (int i in chon)
                lstTen.SetSelected(i, true);      // chọn lại sau khi gán
            lstTen.EndUpdate();
        }

        // Double click vào tên -> mở InputBox để đổi tên
        private void lstTen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idx = lstTen.IndexFromPoint(e.Location);
            if (idx < 0) return;
            string cu = lstTen.Items[idx].ToString();
            string moi = Interaction.InputBox("Nhập tên mới:", "Đổi tên", cu);
            if (!string.IsNullOrWhiteSpace(moi))        // bấm Cancel hoặc để trống thì giữ nguyên
                lstTen.Items[idx] = moi.Trim();
        }
    }
}
