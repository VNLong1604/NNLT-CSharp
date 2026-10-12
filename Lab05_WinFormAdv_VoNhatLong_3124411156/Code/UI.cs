using System;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// Các hàm hỗ trợ tạo nhanh control và hộp thoại.
    /// Giao diện của các form trong bài được dựng bằng code (không dùng Designer)
    /// nên mỗi form nằm gọn trong 1 file .cs, dễ đọc và dễ nộp.
    /// </summary>
    public static class UI
    {
        /// <summary>Tạo Label tại vị trí (x, y) và thêm vào container cha.</summary>
        public static Label Lbl(Control parent, string text, int x, int y, int w = 100)
        {
            Label l = new Label();
            l.Text = text; l.Left = x; l.Top = y + 4; l.Width = w; l.Height = 20;
            parent.Controls.Add(l);
            return l;
        }

        /// <summary>Tạo TextBox tại vị trí (x, y) và thêm vào container cha.</summary>
        public static TextBox Txt(Control parent, int x, int y, int w = 150)
        {
            TextBox t = new TextBox();
            t.Left = x; t.Top = y; t.Width = w;
            parent.Controls.Add(t);
            return t;
        }

        /// <summary>Tạo Button, gắn sự kiện Click (nếu có) và thêm vào container cha.</summary>
        public static Button Btn(Control parent, string text, int x, int y, int w, EventHandler click)
        {
            Button b = new Button();
            b.Text = text; b.Left = x; b.Top = y; b.Width = w; b.Height = 30;
            if (click != null) b.Click += click;
            parent.Controls.Add(b);
            return b;
        }

        /// <summary>Hỏi Yes/No, trả về true nếu người dùng chọn Yes.</summary>
        public static bool Confirm(string msg, string title = "Xác nhận")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void Info(string msg, string title = "Thông báo")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warn(string msg, string title = "Cảnh báo")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
