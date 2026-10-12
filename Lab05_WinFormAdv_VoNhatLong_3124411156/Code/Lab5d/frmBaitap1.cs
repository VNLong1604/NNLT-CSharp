using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài tập tại lớp 1: Quản lý sinh viên bằng ListView.
    ///  - Load form: nạp dữ liệu vào ComboBox Dân tộc.
    ///  - Thêm (không trùng mã sinh viên) / Xóa / Sửa (không cho sửa Mã sinh viên).
    ///  - ContextMenuStrip: chuột phải vào ListView -> "Xóa".
    ///  - Hỏi xác nhận trước khi đóng form.
    /// </summary>
    public class frmBaitap1 : Form
    {
        private TextBox txtHoTen, txtMaSV;
        private RadioButton rdNam, rdNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lst;

        public frmBaitap1()
        {
            Text = "frmBaitap1";
            ClientSize = new Size(620, 475);

            UI.Lbl(this, "Họ và Tên", 50, 20, 100);
            txtHoTen = UI.Txt(this, 190, 20, 340);
            UI.Lbl(this, "Mã sinh viên", 50, 60, 100);
            txtMaSV = UI.Txt(this, 190, 60, 340);

            UI.Lbl(this, "Giới tính", 50, 100, 100);
            rdNam = new RadioButton { Text = "Nam", Left = 190, Top = 100, Width = 70, Checked = true };
            rdNu = new RadioButton { Text = "Nữ", Left = 270, Top = 100, Width = 70 };
            Controls.Add(rdNam);
            Controls.Add(rdNu);

            UI.Lbl(this, "Ngoại ngữ", 50, 140, 100);
            chkAnh = new CheckBox { Text = "Anh", Left = 190, Top = 140, Width = 70, Checked = true };
            chkPhap = new CheckBox { Text = "Pháp", Left = 270, Top = 140, Width = 70 };
            chkHoa = new CheckBox { Text = "Hoa", Left = 350, Top = 140, Width = 70 };
            Controls.Add(chkAnh);
            Controls.Add(chkPhap);
            Controls.Add(chkHoa);

            UI.Lbl(this, "Dân tộc", 50, 180, 100);
            cboDanToc = new ComboBox();
            cboDanToc.SetBounds(190, 180, 340, 24);
            cboDanToc.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cboDanToc);

            lst = new ListView();
            lst.SetBounds(15, 225, 590, 190);
            lst.View = View.Details;
            lst.GridLines = true;
            lst.FullRowSelect = true;
            lst.Columns.Add("Họ tên", 150);
            lst.Columns.Add("Mã sinh viên", 110);
            lst.Columns.Add("Giới tính", 80);
            lst.Columns.Add("Ngoại ngữ", 140);
            lst.Columns.Add("Dân tộc", 100);
            lst.SelectedIndexChanged += lst_SelectedIndexChanged;
            Controls.Add(lst);

            UI.Btn(this, "Thêm", 130, 430, 110, btnThem_Click);
            UI.Btn(this, "Xóa", 255, 430, 110, btnXoa_Click);
            UI.Btn(this, "Sửa", 380, 430, 110, btnSua_Click);

            // ContextMenuStrip: chuột phải vào ListView sẽ hiện menu "Xóa"
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Xóa", null, btnXoa_Click);
            lst.ContextMenuStrip = cms;

            Load += frmBaitap1_Load;
            FormClosing += frmBaitap1_FormClosing;
        }

        // Load form: thêm dữ liệu vào ComboBox dân tộc
        private void frmBaitap1_Load(object sender, EventArgs e)
        {
            cboDanToc.Items.AddRange(new object[] { "Kinh", "Hoa", "K’Me", "H’Mong", "Khác" });
            cboDanToc.SelectedIndex = 0;
        }

        // Hỏi xác nhận trước khi đóng form
        private void frmBaitap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UI.Confirm("Bạn có chắc muốn đóng form?")) e.Cancel = true;
        }

        private string LayGioiTinh() { return rdNam.Checked ? "Nam" : "Nữ"; }

        // Ghép các ngoại ngữ được tick thành chuỗi "Anh, Pháp"
        private string LayNgoaiNgu()
        {
            System.Collections.Generic.List<string> ds = new System.Collections.Generic.List<string>();
            if (chkAnh.Checked) ds.Add("Anh");
            if (chkPhap.Checked) ds.Add("Pháp");
            if (chkHoa.Checked) ds.Add("Hoa");
            return string.Join(", ", ds.ToArray());
        }

        private bool TrungMa(string ma)
        {
            foreach (ListViewItem it in lst.Items)
                if (string.Compare(it.SubItems[1].Text, ma, true) == 0) return true;
            return false;
        }

        // Thêm: không cho trùng mã sinh viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtHoTen.Text.Trim(), ma = txtMaSV.Text.Trim();
            if (ten == "" || ma == "")
            {
                UI.Warn("Vui lòng nhập Họ tên và Mã sinh viên!");
                return;
            }
            if (TrungMa(ma))
            {
                UI.Warn("Mã sinh viên đã tồn tại, không được thêm trùng!");
                txtMaSV.Focus();
                return;
            }
            // Mỗi phần tử của mảng là nội dung 1 cột (đúng thứ tự cột)
            lst.Items.Add(new ListViewItem(new[] { ten, ma, LayGioiTinh(), LayNgoaiNgu(), cboDanToc.Text }));

            txtHoTen.Clear();
            txtMaSV.Clear();
            txtHoTen.Focus();
        }

        // Xóa các dòng đang chọn (dùng chung cho nút Xóa và menu chuột phải)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn dòng cần xóa!");
                return;
            }
            if (!UI.Confirm("Bạn có chắc muốn xóa các dòng đã chọn?")) return;

            ListViewItem[] chon = new ListViewItem[lst.SelectedItems.Count];
            lst.SelectedItems.CopyTo(chon, 0);
            foreach (ListViewItem it in chon) it.Remove();

            txtHoTen.Clear();
            txtMaSV.Clear();
        }

        // Sửa: không cho sửa Mã sinh viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn dòng cần sửa!");
                return;
            }
            ListViewItem it = lst.SelectedItems[0];
            if (txtMaSV.Text.Trim() != it.SubItems[1].Text)
            {
                UI.Warn("Không được sửa Mã sinh viên!");
                txtMaSV.Text = it.SubItems[1].Text;     // trả lại mã cũ
                return;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                UI.Warn("Họ tên không được để trống!");
                return;
            }
            it.SubItems[0].Text = txtHoTen.Text.Trim();
            it.SubItems[2].Text = LayGioiTinh();
            it.SubItems[3].Text = LayNgoaiNgu();
            it.SubItems[4].Text = cboDanToc.Text;
        }

        // Chọn 1 dòng -> hiển thị thông tin lên các control
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0) return;
            ListViewItem it = lst.SelectedItems[0];
            txtHoTen.Text = it.SubItems[0].Text;
            txtMaSV.Text = it.SubItems[1].Text;
            rdNam.Checked = it.SubItems[2].Text == "Nam";
            rdNu.Checked = it.SubItems[2].Text == "Nữ";
            string nn = it.SubItems[3].Text;
            chkAnh.Checked = nn.Contains("Anh");
            chkPhap.Checked = nn.Contains("Pháp");
            chkHoa.Checked = nn.Contains("Hoa");
            cboDanToc.SelectedItem = it.SubItems[4].Text;
        }
    }
}
