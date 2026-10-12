namespace Bai02
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.txtSoNgay = new System.Windows.Forms.TextBox();

            this.grpLoaiPhong = new System.Windows.Forms.GroupBox();
            this.rdoPhongDon = new System.Windows.Forms.RadioButton();
            this.rdoPhongDoi = new System.Windows.Forms.RadioButton();
            this.rdoPhongBa = new System.Windows.Forms.RadioButton();

            this.grpTienNghi = new System.Windows.Forms.GroupBox();
            this.chkTivi = new System.Windows.Forms.CheckBox();
            this.chkInternet = new System.Windows.Forms.CheckBox();
            this.chkMayNuocNong = new System.Windows.Forms.CheckBox();

            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.chkKaraoke = new System.Windows.Forms.CheckBox();
            this.chkAnSang = new System.Windows.Forms.CheckBox();

            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.btnTongKet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.lblThanhTienText = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();

            this.lblThongTinTongKet = new System.Windows.Forms.Label();
            this.lblSoLuotNguoi = new System.Windows.Forms.Label();
            this.txtSoLuotNguoi = new System.Windows.Forms.TextBox();
            this.lblTongSoTien = new System.Windows.Forms.Label();
            this.txtTongSoTien = new System.Windows.Forms.TextBox();

            this.grpLoaiPhong.SuspendLayout();
            this.grpTienNghi.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            this.SuspendLayout();

            
            // FORM
            

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(700, 345);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Name = "Form1";
            this.Text = "Khách sạn Thanh Thanh - Trả phòng";

            this.Load += new System.EventHandler(this.Form1_Load);

            
            // TIÊU ĐỀ
            

            this.lblTieuDe.AutoSize = true;

            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Arial",
                    16F,
                    System.Drawing.FontStyle.Bold);

            this.lblTieuDe.ForeColor =
                System.Drawing.Color.DarkOrange;

            this.lblTieuDe.Location =
                new System.Drawing.Point(130, 8);

            this.lblTieuDe.Name = "lblTieuDe";

            this.lblTieuDe.Size =
                new System.Drawing.Size(445, 25);

            this.lblTieuDe.Text =
                "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";

           
            // HỌ VÀ TÊN
            

            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location =
                new System.Drawing.Point(30, 65);

            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size =
                new System.Drawing.Size(75, 15);

            this.lblHoTen.Text = "Họ và tên:";

            // TextBox họ tên

            this.txtHoTen.Location =
                new System.Drawing.Point(105, 61);

            this.txtHoTen.Name = "txtHoTen";

            this.txtHoTen.Size =
                new System.Drawing.Size(195, 23);

            this.txtHoTen.TabIndex = 0;

            this.txtHoTen.TextChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // =====================================================
            // ĐỊA CHỈ
            // =====================================================

            this.lblDiaChi.AutoSize = true;

            this.lblDiaChi.Location =
                new System.Drawing.Point(48, 98);

            this.lblDiaChi.Name = "lblDiaChi";

            this.lblDiaChi.Size =
                new System.Drawing.Size(51, 15);

            this.lblDiaChi.Text = "Địa chỉ:";

            // TextBox địa chỉ

            this.txtDiaChi.Location =
                new System.Drawing.Point(105, 94);

            this.txtDiaChi.Name = "txtDiaChi";

            this.txtDiaChi.Size =
                new System.Drawing.Size(300, 23);

            this.txtDiaChi.TabIndex = 1;

            this.txtDiaChi.TextChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // =====================================================
            // SỐ NGÀY
            // =====================================================

            this.lblSoNgay.AutoSize = true;

            this.lblSoNgay.Location =
                new System.Drawing.Point(30, 132);

            this.lblSoNgay.Name = "lblSoNgay";

            this.lblSoNgay.Size =
                new System.Drawing.Size(75, 15);

            this.lblSoNgay.Text = "Số ngày ở:";

            // TextBox số ngày

            this.txtSoNgay.Location =
                new System.Drawing.Point(105, 128);

            this.txtSoNgay.Name = "txtSoNgay";

            this.txtSoNgay.Size =
                new System.Drawing.Size(80, 23);

            this.txtSoNgay.TabIndex = 2;

            this.txtSoNgay.TextChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // =====================================================
            // GROUPBOX LOẠI PHÒNG
            // =====================================================

            this.grpLoaiPhong.Controls.Add(
                this.rdoPhongBa);

            this.grpLoaiPhong.Controls.Add(
                this.rdoPhongDoi);

            this.grpLoaiPhong.Controls.Add(
                this.rdoPhongDon);

            this.grpLoaiPhong.Location =
                new System.Drawing.Point(25, 165);

            this.grpLoaiPhong.Name =
                "grpLoaiPhong";

            this.grpLoaiPhong.Size =
                new System.Drawing.Size(120, 125);

            this.grpLoaiPhong.Text =
                "Loại phòng";

            // Phòng đơn

            this.rdoPhongDon.AutoSize = true;

            this.rdoPhongDon.Location =
                new System.Drawing.Point(10, 22);

            this.rdoPhongDon.Name =
                "rdoPhongDon";

            this.rdoPhongDon.Size =
                new System.Drawing.Size(82, 19);

            this.rdoPhongDon.Text =
                "Phòng đơn";

            this.rdoPhongDon.UseVisualStyleBackColor =
                true;

            this.rdoPhongDon.CheckedChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // Phòng đôi

            this.rdoPhongDoi.AutoSize = true;

            this.rdoPhongDoi.Location =
                new System.Drawing.Point(10, 52);

            this.rdoPhongDoi.Name =
                "rdoPhongDoi";

            this.rdoPhongDoi.Size =
                new System.Drawing.Size(81, 19);

            this.rdoPhongDoi.Text =
                "Phòng đôi";

            this.rdoPhongDoi.UseVisualStyleBackColor =
                true;

            this.rdoPhongDoi.CheckedChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // Phòng ba

            this.rdoPhongBa.AutoSize = true;

            this.rdoPhongBa.Location =
                new System.Drawing.Point(10, 82);

            this.rdoPhongBa.Name =
                "rdoPhongBa";

            this.rdoPhongBa.Size =
                new System.Drawing.Size(77, 19);

            this.rdoPhongBa.Text =
                "Phòng ba";

            this.rdoPhongBa.UseVisualStyleBackColor =
                true;

            this.rdoPhongBa.CheckedChanged +=
                new System.EventHandler(
                    this.KiemTraTrangThaiThanhToan);

            // =====================================================
            // GROUPBOX TIỆN NGHI
            // =====================================================

            this.grpTienNghi.Controls.Add(
                this.chkMayNuocNong);

            this.grpTienNghi.Controls.Add(
                this.chkInternet);

            this.grpTienNghi.Controls.Add(
                this.chkTivi);

            this.grpTienNghi.Location =
                new System.Drawing.Point(150, 165);

            this.grpTienNghi.Name =
                "grpTienNghi";

            this.grpTienNghi.Size =
                new System.Drawing.Size(125, 125);

            this.grpTienNghi.Text =
                "Tiện nghi";

            // Tivi

            this.chkTivi.AutoSize = true;

            this.chkTivi.Location =
                new System.Drawing.Point(10, 22);

            this.chkTivi.Name =
                "chkTivi";

            this.chkTivi.Size =
                new System.Drawing.Size(48, 19);

            this.chkTivi.Text =
                "Tivi";

            this.chkTivi.UseVisualStyleBackColor =
                true;

            // Internet

            this.chkInternet.AutoSize = true;

            this.chkInternet.Location =
                new System.Drawing.Point(10, 52);

            this.chkInternet.Name =
                "chkInternet";

            this.chkInternet.Size =
                new System.Drawing.Size(70, 19);

            this.chkInternet.Text =
                "Internet";

            this.chkInternet.UseVisualStyleBackColor =
                true;

            // Máy nước nóng

            this.chkMayNuocNong.AutoSize = true;

            this.chkMayNuocNong.Location =
                new System.Drawing.Point(10, 82);

            this.chkMayNuocNong.Name =
                "chkMayNuocNong";

            this.chkMayNuocNong.Size =
                new System.Drawing.Size(108, 19);

            this.chkMayNuocNong.Text =
                "Máy nước nóng";

            this.chkMayNuocNong.UseVisualStyleBackColor =
                true;

            // =====================================================
            // GROUPBOX DỊCH VỤ
            // =====================================================

            this.grpDichVu.Controls.Add(
                this.chkAnSang);

            this.grpDichVu.Controls.Add(
                this.chkKaraoke);

            this.grpDichVu.Location =
                new System.Drawing.Point(280, 165);

            this.grpDichVu.Name =
                "grpDichVu";

            this.grpDichVu.Size =
                new System.Drawing.Size(125, 125);

            this.grpDichVu.Text =
                "Dịch vụ";

            // Karaoke

            this.chkKaraoke.AutoSize = true;

            this.chkKaraoke.Location =
                new System.Drawing.Point(10, 22);

            this.chkKaraoke.Name =
                "chkKaraoke";

            this.chkKaraoke.Size =
                new System.Drawing.Size(75, 19);

            this.chkKaraoke.Text =
                "Karaoke";

            this.chkKaraoke.UseVisualStyleBackColor =
                true;

            // Ăn sáng

            this.chkAnSang.AutoSize = true;

            this.chkAnSang.Location =
                new System.Drawing.Point(10, 52);

            this.chkAnSang.Name =
                "chkAnSang";

            this.chkAnSang.Size =
                new System.Drawing.Size(75, 19);

            this.chkAnSang.Text =
                "Ăn sáng";

            this.chkAnSang.UseVisualStyleBackColor =
                true;

            // =====================================================
            // THANH TOÁN
            // =====================================================

            this.btnThanhToan.Location =
                new System.Drawing.Point(425, 65);

            this.btnThanhToan.Name =
                "btnThanhToan";

            this.btnThanhToan.Size =
                new System.Drawing.Size(88, 28);

            this.btnThanhToan.Text =
                "Thanh toán";

            this.btnThanhToan.UseVisualStyleBackColor =
                true;

            this.btnThanhToan.Click +=
                new System.EventHandler(
                    this.btnThanhToan_Click);

            // =====================================================
            // NHẬP MỚI
            // =====================================================

            this.btnNhapMoi.Location =
                new System.Drawing.Point(520, 65);

            this.btnNhapMoi.Name =
                "btnNhapMoi";

            this.btnNhapMoi.Size =
                new System.Drawing.Size(88, 28);

            this.btnNhapMoi.Text =
                "Nhập mới";

            this.btnNhapMoi.UseVisualStyleBackColor =
                true;

            this.btnNhapMoi.Click +=
                new System.EventHandler(
                    this.btnNhapMoi_Click);

            // =====================================================
            // THÀNH TIỀN
            // =====================================================

            this.lblThanhTienText.AutoSize = true;

            this.lblThanhTienText.Location =
                new System.Drawing.Point(425, 108);

            this.lblThanhTienText.Name =
                "lblThanhTienText";

            this.lblThanhTienText.Size =
                new System.Drawing.Size(65, 15);

            this.lblThanhTienText.Text =
                "Thành tiền:";

            // TextBox thành tiền

            this.txtThanhTien.Location =
                new System.Drawing.Point(500, 104);

            this.txtThanhTien.Name =
                "txtThanhTien";

            this.txtThanhTien.ReadOnly = true;

            this.txtThanhTien.Size =
                new System.Drawing.Size(175, 23);

            this.txtThanhTien.TabIndex = 10;

            // =====================================================
            // TỔNG KẾT BUTTON
            // =====================================================

            this.btnTongKet.Location =
                new System.Drawing.Point(425, 140);

            this.btnTongKet.Name =
                "btnTongKet";

            this.btnTongKet.Size =
                new System.Drawing.Size(88, 28);

            this.btnTongKet.Text =
                "Tổng kết";

            this.btnTongKet.UseVisualStyleBackColor =
                true;

            this.btnTongKet.Click +=
                new System.EventHandler(
                    this.btnTongKet_Click);

            // =====================================================
            // THÔNG TIN TỔNG KẾT
            // =====================================================

            this.lblThongTinTongKet.AutoSize = true;

            this.lblThongTinTongKet.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblThongTinTongKet.Location =
                new System.Drawing.Point(425, 178);

            this.lblThongTinTongKet.Name =
                "lblThongTinTongKet";

            this.lblThongTinTongKet.Size =
                new System.Drawing.Size(126, 15);

            this.lblThongTinTongKet.Text =
                "Thông tin tổng kết";

            // =====================================================
            // SỐ LƯỢT NGƯỜI
            // =====================================================

            this.lblSoLuotNguoi.AutoSize = true;

            this.lblSoLuotNguoi.Location =
                new System.Drawing.Point(425, 205);

            this.lblSoLuotNguoi.Name =
                "lblSoLuotNguoi";

            this.lblSoLuotNguoi.Size =
                new System.Drawing.Size(83, 15);

            this.lblSoLuotNguoi.Text =
                "Số lượt người:";

            // TextBox số lượt người

            this.txtSoLuotNguoi.Location =
                new System.Drawing.Point(515, 201);

            this.txtSoLuotNguoi.Name =
                "txtSoLuotNguoi";

            this.txtSoLuotNguoi.ReadOnly = true;

            this.txtSoLuotNguoi.Size =
                new System.Drawing.Size(160, 23);

            this.txtSoLuotNguoi.TabIndex = 11;

            // =====================================================
            // TỔNG SỐ TIỀN
            // =====================================================

            this.lblTongSoTien.AutoSize = true;

            this.lblTongSoTien.Location =
                new System.Drawing.Point(425, 235);

            this.lblTongSoTien.Name =
                "lblTongSoTien";

            this.lblTongSoTien.Size =
                new System.Drawing.Size(73, 15);

            this.lblTongSoTien.Text =
                "Tổng số tiền:";

            // TextBox tổng tiền

            this.txtTongSoTien.Location =
                new System.Drawing.Point(515, 231);

            this.txtTongSoTien.Name =
                "txtTongSoTien";

            this.txtTongSoTien.ReadOnly = true;

            this.txtTongSoTien.Size =
                new System.Drawing.Size(160, 23);

            this.txtTongSoTien.TabIndex = 12;

            // =====================================================
            // THOÁT
            // =====================================================

            this.btnThoat.Location =
                new System.Drawing.Point(425, 270);

            this.btnThoat.Name =
                "btnThoat";

            this.btnThoat.Size =
                new System.Drawing.Size(88, 28);

            this.btnThoat.Text =
                "Thoát";

            this.btnThoat.UseVisualStyleBackColor =
                true;

            this.btnThoat.Click +=
                new System.EventHandler(
                    this.btnThoat_Click);

            // =====================================================
            // ADD CONTROLS TO FORM
            // =====================================================

            this.Controls.Add(this.lblTieuDe);

            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);

            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtDiaChi);

            this.Controls.Add(this.lblSoNgay);
            this.Controls.Add(this.txtSoNgay);

            this.Controls.Add(this.grpLoaiPhong);
            this.Controls.Add(this.grpTienNghi);
            this.Controls.Add(this.grpDichVu);

            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnNhapMoi);

            this.Controls.Add(this.lblThanhTienText);
            this.Controls.Add(this.txtThanhTien);

            this.Controls.Add(this.btnTongKet);

            this.Controls.Add(this.lblThongTinTongKet);

            this.Controls.Add(this.lblSoLuotNguoi);
            this.Controls.Add(this.txtSoLuotNguoi);

            this.Controls.Add(this.lblTongSoTien);
            this.Controls.Add(this.txtTongSoTien);

            this.Controls.Add(this.btnThoat);

            this.grpLoaiPhong.ResumeLayout(false);
            this.grpLoaiPhong.PerformLayout();

            this.grpTienNghi.ResumeLayout(false);
            this.grpTienNghi.PerformLayout();

            this.grpDichVu.ResumeLayout(false);
            this.grpDichVu.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;

        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;

        private System.Windows.Forms.Label lblSoNgay;
        private System.Windows.Forms.TextBox txtSoNgay;

        private System.Windows.Forms.GroupBox grpLoaiPhong;
        private System.Windows.Forms.RadioButton rdoPhongDon;
        private System.Windows.Forms.RadioButton rdoPhongDoi;
        private System.Windows.Forms.RadioButton rdoPhongBa;

        private System.Windows.Forms.GroupBox grpTienNghi;
        private System.Windows.Forms.CheckBox chkTivi;
        private System.Windows.Forms.CheckBox chkInternet;
        private System.Windows.Forms.CheckBox chkMayNuocNong;

        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.CheckBox chkKaraoke;
        private System.Windows.Forms.CheckBox chkAnSang;

        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.Button btnTongKet;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.Label lblThanhTienText;
        private System.Windows.Forms.TextBox txtThanhTien;

        private System.Windows.Forms.Label lblThongTinTongKet;
        private System.Windows.Forms.Label lblSoLuotNguoi;
        private System.Windows.Forms.TextBox txtSoLuotNguoi;

        private System.Windows.Forms.Label lblTongSoTien;
        private System.Windows.Forms.TextBox txtTongSoTien;

        
    }
}

