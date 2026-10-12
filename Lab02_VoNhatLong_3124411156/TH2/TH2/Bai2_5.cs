using System;
using System.Collections.Generic;

namespace TH2
{
    
    public class NhanVienPhongBan
    {
        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        public const double TIEN_PHAT_NGAY_VANG = 100000.0;

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public double MucLuong
        {
            get { return mucLuong; }
            set { mucLuong = value >= 0 ? value : 0; }
        }

        public int SoNgayVang
        {
            get { return soNgayVang; }
            set { soNgayVang = value >= 0 ? value : 0; }
        }

        public NhanVienPhongBan()
        {
            hoTen = string.Empty;
            mucLuong = 0;
            soNgayVang = 0;
        }

        public NhanVienPhongBan(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = mucLuong;
            this.soNgayVang = soNgayVang;
        }

        public void Nhap()
        {
            hoTen = TienIch.DocChuoi("Nhap ho ten: ");
            mucLuong = TienIch.DocSoThucKhongAm("Nhap muc luong co ban: ");
            soNgayVang = TienIch.DocSoNguyenKhongAm("Nhap so ngay vang: ");
        }

        // Tinh luong thuc linh cua nhan vien (Luong - SoNgayVang * 100.000)
        public double TinhLuongThucLinh()
        {
            double luong = mucLuong - (soNgayVang * TIEN_PHAT_NGAY_VANG);
            return luong > 0 ? luong : 0;
        }

        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0,-20} | Muc luong: {1,12:N0} | Vang: {2,2} ngay | Thuc linh: {3,12:N0} VND",
                hoTen, mucLuong, soNgayVang, TinhLuongThucLinh());
        }
    }

    /// <summary>
    /// Lop PhongBan quan ly danh sach n nhan vien va tinh tong luong
    /// </summary>
    public class PhongBan
    {
        private string tenPhong;
        private List<NhanVienPhongBan> dsNhanVien;

        public PhongBan()
        {
            tenPhong = "Phong Ban";
            dsNhanVien = new List<NhanVienPhongBan>();
        }

        public void Nhap()
        {
            tenPhong = TienIch.DocChuoi("Nhap ten phong ban: ");
            int n = TienIch.DocSoNguyenDuong("Nhap so luong nhan vien trong phong: ");
            dsNhanVien.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Nhap nhan vien thu {0} ", i + 1);
                NhanVienPhongBan nv = new NhanVienPhongBan();
                nv.Nhap();
                dsNhanVien.Add(nv);
            }
        }

        // Tinh tong luong cua phong ban
        public double TinhTongLuong()
        {
            double tong = 0;
            foreach (NhanVienPhongBan nv in dsNhanVien)
            {
                tong += nv.TinhLuongThucLinh();
            }
            return tong;
        }

        public void Xuat()
        {
            Console.WriteLine("\n BANG LUONG PHONG BAN: {0} ", tenPhong.ToUpper());
            if (dsNhanVien.Count == 0)
            {
                Console.WriteLine("(Chua co nhan vien)");
                return;
            }
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                Console.Write("{0,2}. ", i + 1);
                dsNhanVien[i].Xuat();
            }
            Console.WriteLine("TONG LUONG TOAN PHONG BAN: {0:N0} VND", TinhTongLuong());
        }
    }

    
    public class Bai2_5
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.5: TINH LUONG NHAN VIEN PHONG BAN ");

            PhongBan pb = new PhongBan();
            pb.Nhap();
            pb.Xuat();
        }
    }
}
