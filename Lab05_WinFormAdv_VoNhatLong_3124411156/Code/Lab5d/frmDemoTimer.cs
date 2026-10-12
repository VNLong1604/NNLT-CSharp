using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài mẫu 1: Demo Timer.
    /// Mỗi giây sự kiện Tick phát sinh, trình xử lý lấy giờ hệ thống và hiển thị lên Label.
    /// Lưu ý: tài liệu mẫu dùng "new DateTime()" sẽ luôn ra 01/01/0001; phải dùng DateTime.Now để lấy giờ hệ thống.
    /// </summary>
    public class frmDemoTimer : Form
    {
        private Label label1;
        private Timer timer1;

        public frmDemoTimer()
        {
            Text = "Demo Timer";
            ClientSize = new Size(300, 150);

            label1 = new Label();
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.ForeColor = Color.Red;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            Controls.Add(label1);

            timer1 = new Timer();
            timer1.Interval = 1000;          // 1000 ms = 1 giây giữa 2 lần Tick
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;           // bật Timer -> bắt đầu phát sinh sự kiện Tick

            timer1_Tick(null, null);         // hiển thị ngay giờ hiện tại, khỏi chờ 1 giây đầu
            FormClosed += (s, e) => timer1.Stop();   // dừng timer khi đóng form
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian hệ thống
            DateTime now = DateTime.Now;
            label1.Text = now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
