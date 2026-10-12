using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài về nhà 1: Từ điển Anh - Việt và Việt - Anh (TabControl, mỗi tab 1 từ điển).
    ///  - Gõ vào ComboBox: chương trình dò đến từ khớp nhất (AutoComplete + chọn dòng trong ListBox).
    ///  - Nhấn Enter hoặc double click vào từ: hiển thị nghĩa vào TextBox bên phải.
    ///  - Danh sách từ được lưu sẵn trong SortedDictionary.
    /// </summary>
    public class frmTuDien : Form
    {
        public frmTuDien()
        {
            Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            ClientSize = new Size(560, 470);

            TabControl tab = new TabControl();
            tab.SetBounds(15, 15, 530, 400);
            Controls.Add(tab);

            TabPage tpAV = new TabPage("ANH - VIỆT");
            TabPage tpVA = new TabPage("VIỆT - ANH");
            tab.TabPages.Add(tpAV);
            tab.TabPages.Add(tpVA);

            // Danh sách từ lưu sẵn (key = từ cần tra, value = nghĩa)
            SortedDictionary<string, string> anhViet = TaoTuDien(
                "student", "Sinh viên, học sinh", "teacher", "Giáo viên", "worker", "Công nhân",
                "hat", "Cái mũ", "head", "Cái đầu", "mouse", "Con chuột; chuột máy tính",
                "cat", "Con mèo", "dog", "Con chó", "snake", "Con rắn", "lamb", "Con cừu non",
                "loan", "Khoản vay", "frog", "Con ếch", "sheep", "Con cừu", "book", "Quyển sách",
                "computer", "Máy tính", "school", "Trường học", "house", "Ngôi nhà",
                "water", "Nước", "apple", "Quả táo", "love", "Tình yêu");

            SortedDictionary<string, string> vietAnh = TaoTuDien(
                "sinh viên", "student", "giáo viên", "teacher", "công nhân", "worker",
                "mũ", "hat", "đầu", "head", "chuột", "mouse", "mèo", "cat", "chó", "dog",
                "rắn", "snake", "ếch", "frog", "cừu", "sheep", "sách", "book",
                "máy tính", "computer", "trường học", "school", "nhà", "house",
                "nước", "water", "táo", "apple", "tình yêu", "love");

            TaoTab(tpAV, "Tiếng Anh", "Tiếng Việt", anhViet);
            TaoTab(tpVA, "Tiếng Việt", "Tiếng Anh", vietAnh);

            UI.Btn(this, "Th&oát", 445, 425, 100, (s, e) =>
            {
                if (UI.Confirm("Bạn có chắc muốn thoát?")) Close();
            });
        }

        // Tạo từ điển (không phân biệt hoa/thường) từ danh sách xen kẽ: từ, nghĩa, từ, nghĩa, ...
        private static SortedDictionary<string, string> TaoTuDien(params string[] cap)
        {
            SortedDictionary<string, string> d =
                new SortedDictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            for (int i = 0; i + 1 < cap.Length; i += 2) d[cap[i]] = cap[i + 1];
            return d;
        }

        // Dựng giao diện cho 1 tab từ điển
        private void TaoTab(TabPage tp, string nhanNguon, string nhanDich, SortedDictionary<string, string> tuDien)
        {
            UI.Lbl(tp, nhanNguon, 15, 10, 200);
            UI.Lbl(tp, nhanDich, 270, 10, 200);

            ComboBox cbo = new ComboBox();
            cbo.SetBounds(15, 40, 230, 24);
            foreach (string k in tuDien.Keys) cbo.Items.Add(k);
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;   // gợi ý + tự điền khi gõ
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            tp.Controls.Add(cbo);

            ListBox lst = new ListBox();
            lst.SetBounds(15, 70, 230, 290);
            foreach (string k in tuDien.Keys) lst.Items.Add(k);
            tp.Controls.Add(lst);

            TextBox txtNghia = new TextBox();
            txtNghia.SetBounds(270, 40, 235, 320);
            txtNghia.Multiline = true;
            txtNghia.ReadOnly = true;
            tp.Controls.Add(txtNghia);

            // Hàm tra từ: hiển thị nghĩa lên textbox
            Action<string> tra = (tu) =>
            {
                string nghia;
                if (tu != null && tuDien.TryGetValue(tu.Trim(), out nghia))
                    txtNghia.Text = nghia;
                else
                    txtNghia.Text = "(Không tìm thấy từ trong từ điển)";
            };

            // Gõ vào combobox -> dò đến từ bắt đầu bằng các ký tự đã gõ gần nhất
            cbo.TextChanged += (s, e) =>
            {
                string t = cbo.Text.Trim();
                if (t.Length == 0) { lst.SelectedIndex = -1; return; }
                for (int i = 0; i < lst.Items.Count; i++)
                    if (lst.Items[i].ToString().StartsWith(t, StringComparison.CurrentCultureIgnoreCase))
                    {
                        lst.SelectedIndex = i;      // cuộn đến và chọn từ khớp
                        return;
                    }
                lst.SelectedIndex = -1;
            };

            // Nhấn Enter trong combobox -> tra từ
            cbo.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tra(cbo.Text);
                    e.SuppressKeyPress = true;     // không phát tiếng "bíp" của Windows
                }
            };

            // Double click vào từ trong danh sách -> tra từ
            lst.DoubleClick += (s, e) =>
            {
                if (lst.SelectedItem != null)
                {
                    cbo.Text = lst.SelectedItem.ToString();
                    tra(lst.SelectedItem.ToString());
                }
            };
        }
    }
}
