using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02

{
    public partial class Form1 : Form
    {
        // Tổng số lượt khách đã thanh toán
        private int tongSoLuotNguoi = 0;

        // Tổng số tiền đã thanh toán
        private decimal tongSoTien = 0;

        public Form1()
        {
            InitializeComponent();
        }

       
        // FORM LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            // Đưa con trỏ vào ô họ và tên
            txtHoTen.Focus();

            // Ban đầu các nút này bị mờ
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;

            // Giá trị ban đầu
            txtThanhTien.Text = "0 VND";
            txtSoLuotNguoi.Text = "0";
            txtTongSoTien.Text = "0 VND";

            // Mặc định số ngày ở là 1
            txtSoNgay.Text = "1";
        }

       
        // KIỂM TRA DỮ LIỆU
        private bool KiemTraDuLieu()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Tên khách hàng không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show(
                    "Địa chỉ không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDiaChi.Focus();
                return false;
            }

            // Kiểm tra số ngày
            int soNgay;

            if (!int.TryParse(txtSoNgay.Text, out soNgay))
            {
                MessageBox.Show(
                    "Số ngày ở phải là số!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoNgay.Focus();
                return false;
            }

            if (soNgay <= 0)
            {
                MessageBox.Show(
                    "Số ngày ở phải lớn hơn 0!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoNgay.Focus();
                return false;
            }

            // Kiểm tra loại phòng
            if (!rdoPhongDon.Checked &&
                !rdoPhongDoi.Checked &&
                !rdoPhongBa.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại phòng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // KIỂM TRA ĐỂ ENABLE NÚT THANH TOÁN       
        private void KiemTraTrangThaiThanhToan(object sender, EventArgs e)
        {
            bool coHoTen = !string.IsNullOrWhiteSpace(txtHoTen.Text);

            bool coDiaChi = !string.IsNullOrWhiteSpace(txtDiaChi.Text);

            bool soNgayHopLe = false;

            int soNgay;

            if (int.TryParse(txtSoNgay.Text, out soNgay))
            {
                if (soNgay > 0)
                {
                    soNgayHopLe = true;
                }
            }

            bool coLoaiPhong =
                rdoPhongDon.Checked ||
                rdoPhongDoi.Checked ||
                rdoPhongBa.Checked;

            // Khi nhập đầy đủ thông tin thì nút Thanh toán sáng
            btnThanhToan.Enabled =
                coHoTen &&
                coDiaChi &&
                soNgayHopLe &&
                coLoaiPhong;
        }

        
        // TÍNH TIỀN
        private decimal TinhTien()
        {
            int soNgay = int.Parse(txtSoNgay.Text);

            decimal giaPhong = 0;

            
            // GIÁ PHÒNG
            if (rdoPhongDon.Checked)
            {
                giaPhong = 300000;
            }
            else if (rdoPhongDoi.Checked)
            {
                giaPhong = 350000;
            }
            else if (rdoPhongBa.Checked)
            {
                giaPhong = 400000;
            }

            // Tiền phòng
            decimal tienPhong = giaPhong * soNgay;

             
            // TIỆN NGHI 
            decimal tienTienNghi = 0;

            if (chkTivi.Checked)
            {
                tienTienNghi += 10000;
            }

            if (chkInternet.Checked)
            {
                tienTienNghi += 10000;
            }

            if (chkMayNuocNong.Checked)
            {
                tienTienNghi += 10000;
            }

            
            // DỊCH VỤ     
            decimal tienDichVu = 0;

            // Karaoke: 50.000
            if (chkKaraoke.Checked)
            {
                tienDichVu += 50000;
            }

            // Ăn sáng: 15.000/ngày
            if (chkAnSang.Checked)
            {
                tienDichVu += 15000 * soNgay;
            }

          
            // TỔNG TIỀN    
            decimal thanhTien =
                tienPhong +
                tienTienNghi +
                tienDichVu;

            return thanhTien;
        }

        
        // BUTTON THANH TOÁN
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
            {
                return;
            }

            // Tính tiền
            decimal thanhTien = TinhTien();

            // Hiển thị thành tiền
            txtThanhTien.Text =
                thanhTien.ToString("N0") + " VND";

            // Cộng vào tổng
            tongSoLuotNguoi++;
            tongSoTien += thanhTien;

            // Sau khi thanh toán
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;

            // Không cho thanh toán lại cùng một khách
            btnThanhToan.Enabled = false;

            MessageBox.Show(
                "Thanh toán thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        
        // BUTTON NHẬP MỚI
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            // Xóa họ tên
            txtHoTen.Clear();

            // Xóa địa chỉ
            txtDiaChi.Clear();

            // Số ngày về 1
            txtSoNgay.Text = "1";

            // Bỏ chọn loại phòng
            rdoPhongDon.Checked = false;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;

            // Bỏ chọn tiện nghi
            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;

            // Bỏ chọn dịch vụ
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            // Thành tiền về 0
            txtThanhTien.Text = "0 VND";

            // Trạng thái nút
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;

            // Nếu vẫn còn khách chưa tổng kết
            // thì nút Tổng kết vẫn sáng
            btnTongKet.Enabled = tongSoLuotNguoi > 0;

            // Đưa con trỏ về ô họ tên
            txtHoTen.Focus();
        }

        
        // BUTTON TỔNG KẾT      
       private void btnTongKet_Click(object sender, EventArgs e)
        {
            // Hiển thị tổng số lượt người
            txtSoLuotNguoi.Text =
                tongSoLuotNguoi.ToString();

            // Hiển thị tổng số tiền
            txtTongSoTien.Text =
                tongSoTien.ToString("N0") + " VND";

            MessageBox.Show(
                "Đã tổng kết thông tin thanh toán!",
                "Tổng kết",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Reset biến tổng
            tongSoLuotNguoi = 0;
            tongSoTien = 0;

            // Tổng kết bị mờ
            btnTongKet.Enabled = false;

            // Nhập mới bị mờ
            btnNhapMoi.Enabled = false;

            // Đưa Form về trạng thái nhập khách mới
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Text = "1";

            rdoPhongDon.Checked = false;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;

            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            txtThanhTien.Text = "0 VND";

            // Chưa nhập đủ nên thanh toán mờ
            btnThanhToan.Enabled = false;

            txtHoTen.Focus();
        }

        
        // BUTTON THOÁT
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
