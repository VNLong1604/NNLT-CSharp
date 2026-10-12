using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài về nhà 3: Danh bạ.
    /// Khi load form, TreeView chứa các node A..Z. Thêm người mới: đưa vào node tương ứng
    /// với chữ cái đầu của First Name (bỏ dấu tiếng Việt, ví dụ "Bình" -> B, "Đức" -> D).
    /// Mỗi mục hiển thị dạng "First Name, Last Name".
    /// </summary>
    public class frmDanhBa : Form
    {
        private TreeView trv;
        private TextBox txtFirst, txtLast;

        public frmDanhBa()
        {
            Text = "frmBTVN2";
            ClientSize = new Size(640, 420);

            trv = new TreeView();
            trv.SetBounds(10, 10, 240, 400);
            Controls.Add(trv);

            // Khi load form: tạo node từ A đến Z
            for (char c = 'A'; c <= 'Z'; c++)
                trv.Nodes.Add(c.ToString(), c.ToString());   // (key, text) để sau này tìm node theo chữ cái

            GroupBox g = new GroupBox();
            g.SetBounds(265, 15, 360, 150);
            Controls.Add(g);
            UI.Lbl(g, "First Name", 15, 28, 80);
            txtFirst = UI.Txt(g, 110, 28, 230);
            UI.Lbl(g, "Last Name", 15, 68, 80);
            txtLast = UI.Txt(g, 110, 68, 230);
            Button btnAdd = UI.Btn(g, "Add", 250, 105, 90, btnAdd_Click);
            AcceptButton = btnAdd;

            UI.Btn(this, "Exit", 530, 180, 95, (s, e) => Close());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string first = txtFirst.Text.Trim();
            string last = txtLast.Text.Trim();
            if (first == "" || last == "")
            {
                UI.Warn("Vui lòng nhập đầy đủ First Name và Last Name!");
                (first == "" ? txtFirst : txtLast).Focus();
                return;
            }

            string chu = BoDau(first).Substring(0, 1).ToUpper();    // chữ cái đầu đã bỏ dấu
            if (chu[0] < 'A' || chu[0] > 'Z')
            {
                UI.Warn("First Name phải bắt đầu bằng một chữ cái!");
                return;
            }

            TreeNode nodeChu = trv.Nodes[chu];    // tìm node theo key (chữ cái)

            TreeNode moi = nodeChu.Nodes.Add(first + ", " + last);
            nodeChu.Expand();
            trv.SelectedNode = moi;

            txtFirst.Clear();
            txtLast.Clear();
            txtFirst.Focus();
        }

        // Bỏ dấu tiếng Việt: tách ký tự gốc và dấu (FormD) rồi loại các dấu; xử lý riêng Đ/đ
        private static string BoDau(string s)
        {
            s = s.Replace('Đ', 'D').Replace('đ', 'd');
            string d = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in d)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString();
        }
    }
}
