using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài mẫu 2: nạp dữ liệu vào ComboBox "Dân tộc" và hiển thị mục được chọn theo 2 cách:
    ///  Cách 1: bấm nút "Hiển thị" -> hiện lên Label.
    ///  Cách 2: hiện MessageBox ngay khi chọn (sự kiện SelectedIndexChanged).
    /// </summary>
    public class frmComboBox : Form
    {
        private ComboBox cbo_dt;
        private Label lbl_kq;

        public frmComboBox()
        {
            Text = "Cbo_Dantoc";
            ClientSize = new Size(360, 190);

            UI.Btn(this, "Load dữ liệu Combobox", 20, 15, 200, btn_loadDL_Click);
            UI.Lbl(this, "Dân tộc", 20, 65, 60);

            cbo_dt = new ComboBox();
            cbo_dt.Name = "cbo_dt";
            cbo_dt.SetBounds(90, 65, 230, 24);
            cbo_dt.DropDownStyle = ComboBoxStyle.DropDownList;   // chỉ cho chọn, không gõ
            cbo_dt.SelectedIndexChanged += cbo_dt_SelectedIndexChanged;
            Controls.Add(cbo_dt);

            UI.Btn(this, "Hiển thị", 90, 105, 110, btn_hienthi_Click);

            lbl_kq = UI.Lbl(this, "", 90, 145, 250);
            lbl_kq.ForeColor = Color.Red;
        }

        // Nạp 5 dân tộc vào combobox
        private void btn_loadDL_Click(object sender, EventArgs e)
        {
            string[] dt = { "Kinh", "Hoa", "K’Me", "H’Mong", "Khác" };
            cbo_dt.Items.Clear();                 // tránh nạp trùng nếu bấm nhiều lần
            foreach (string s in dt)
                cbo_dt.Items.Add(s);
        }

        // Cách 1: hiển thị dân tộc đã chọn lên Label
        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            string s = "Dân tộc được chọn: ";
            if (cbo_dt.SelectedIndex >= 0)
                lbl_kq.Text = s + cbo_dt.SelectedItem.ToString();
            else
                lbl_kq.Text = "Bạn chưa chọn dân tộc";
        }

        // Cách 2: hiển thị MessageBox ngay khi chọn
        private void cbo_dt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_dt.SelectedIndex >= 0)
                MessageBox.Show("Dân tộc được chọn: " + cbo_dt.SelectedItem.ToString());
        }
    }
}
