using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5c - Bài mẫu 1: chuyển phần tử qua lại giữa 2 ListBox.
    ///  >  : chuyển phần tử đang chọn sang phải      >> : chuyển tất cả sang phải
    ///  <  : chuyển phần tử đang chọn sang trái      << : chuyển tất cả sang trái
    ///  "Chuyển tùy ý": chuyển TẤT CẢ các item đang được chọn (chọn nhiều bằng Ctrl/Shift) ở listbox trái sang phải.
    /// Đóng form có xác nhận từ người dùng (sự kiện FormClosing).
    /// </summary>
    public class frmListBox : Form
    {
        private ListBox lst_Trai, lst_Phai;

        public frmListBox()
        {
            Text = "Sử dụng listbox";
            Font = new Font("Tahoma", 11F);
            ClientSize = new Size(520, 370);

            // ListBox trái: cho phép chọn nhiều để dùng nút "Chuyển tùy ý"
            lst_Trai = new ListBox();
            lst_Trai.Name = "lst_Trai";
            lst_Trai.SetBounds(15, 15, 170, 340);
            lst_Trai.SelectionMode = SelectionMode.MultiExtended;
            lst_Trai.Items.AddRange(new object[] { "Cốc", "Ổi", "Xoài", "Me", "Bưởi", "Cam" });

            lst_Phai = new ListBox();
            lst_Phai.Name = "lst_Phai";
            lst_Phai.SetBounds(335, 15, 170, 340);

            Controls.Add(lst_Trai);
            Controls.Add(lst_Phai);

            UI.Btn(this, ">", 195, 15, 130, btnQuaPhai_Click);
            UI.Btn(this, ">>", 195, 60, 130, btnQuaPhaiAll_Click);
            UI.Btn(this, "<", 195, 105, 130, btnQuaTrai_Click);
            UI.Btn(this, "<<", 195, 150, 130, btnQuaTraiAll_Click);
            UI.Btn(this, "Chuyển tùy ý", 195, 215, 130, btnChuyenTuyY_Click);

            FormClosing += frmListBox_FormClosing;
        }

        // Chuyển 1 item đang chọn từ trái sang phải
        private void btnQuaPhai_Click(object sender, EventArgs e)
        {
            if (lst_Trai.SelectedItem == null)
            {
                UI.Warn("Vui lòng chọn một phần tử ở danh sách bên trái.");
                return;
            }
            object item = lst_Trai.SelectedItem;
            lst_Phai.Items.Add(item);      // thêm sang phải
            lst_Trai.Items.Remove(item);   // xóa khỏi trái
        }

        // Chuyển tất cả item từ trái sang phải
        private void btnQuaPhaiAll_Click(object sender, EventArgs e)
        {
            lst_Phai.Items.AddRange(lst_Trai.Items);
            lst_Trai.Items.Clear();
        }

        // Chuyển 1 item đang chọn từ phải sang trái
        private void btnQuaTrai_Click(object sender, EventArgs e)
        {
            if (lst_Phai.SelectedItem == null)
            {
                UI.Warn("Vui lòng chọn một phần tử ở danh sách bên phải.");
                return;
            }
            object item = lst_Phai.SelectedItem;
            lst_Trai.Items.Add(item);
            lst_Phai.Items.Remove(item);
        }

        // Chuyển tất cả item từ phải sang trái
        private void btnQuaTraiAll_Click(object sender, EventArgs e)
        {
            lst_Trai.Items.AddRange(lst_Phai.Items);
            lst_Phai.Items.Clear();
        }

        // "Chuyển tùy ý": chọn item nào thì chuyển item đó (có thể chọn nhiều) sang phải
        private void btnChuyenTuyY_Click(object sender, EventArgs e)
        {
            if (lst_Trai.SelectedItems.Count == 0)
            {
                UI.Warn("Vui lòng chọn ít nhất một phần tử ở danh sách bên trái.");
                return;
            }
            // Sao chép các item đang chọn ra danh sách tạm,
            // vì không được xóa phần tử trong lúc đang duyệt SelectedItems.
            List<object> chon = new List<object>();
            foreach (object o in lst_Trai.SelectedItems) chon.Add(o);

            foreach (object o in chon)
            {
                lst_Phai.Items.Add(o);
                lst_Trai.Items.Remove(o);
            }
        }

        // Xác nhận khi đóng form: nếu chọn No thì hủy việc đóng (e.Cancel = true)
        private void frmListBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UI.Confirm("Bạn có chắc muốn đóng form?"))
                e.Cancel = true;
        }
    }
}
