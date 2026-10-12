using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài về nhà 1: Đồng hồ đếm ngược 30:00 bằng Timer (Interval = 1000 ms).
    /// Nút "Bắt đầu" -> chạy; trong khi chạy nút đổi thành "Dừng"; dừng giữa chừng thì đổi thành "Tiếp tục".
    /// Khi về 00:00: dừng Timer, báo "Hết giờ" và trả đồng hồ về 30:00.
    /// </summary>
    public class frmDongHo : Form
    {
        private const int TONG_GIAY = 30 * 60;     // 30 phút
        private int conLai = TONG_GIAY;
        private Label lblGio;
        private Button btnBatDau;
        private Timer timer1;

        public frmDongHo()
        {
            Text = "Đồng hồ";
            ClientSize = new Size(260, 120);

            lblGio = new Label();
            lblGio.Font = new Font("Courier New", 16F, FontStyle.Bold);
            lblGio.TextAlign = ContentAlignment.MiddleCenter;
            lblGio.SetBounds(0, 12, 260, 36);
            Controls.Add(lblGio);

            btnBatDau = UI.Btn(this, "Bắt đầu", 80, 62, 100, btnBatDau_Click);

            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            HienThi();
            FormClosed += (s, e) => timer1.Stop();
        }

        // Hiển thị thời gian còn lại dạng mm:ss
        private void HienThi()
        {
            lblGio.Text = (conLai / 60).ToString("00") + ":" + (conLai % 60).ToString("00");
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
                btnBatDau.Text = "Dừng";
            }
            else
            {
                timer1.Stop();
                btnBatDau.Text = "Tiếp tục";
            }
        }

        // Mỗi giây giảm 1 giây
        private void timer1_Tick(object sender, EventArgs e)
        {
            conLai--;
            HienThi();
            if (conLai <= 0)
            {
                timer1.Stop();
                btnBatDau.Text = "Bắt đầu";
                UI.Info("Hết giờ!");
                conLai = TONG_GIAY;      // đặt lại 30:00 cho lần sau
                HienThi();
            }
        }
    }
}
