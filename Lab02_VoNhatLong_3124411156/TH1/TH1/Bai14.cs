using System;
using System.Globalization;

namespace TH1
{
    // Lớp nhân viên: họ tên, mức lương, số ngày vắng
    class NhanVien
    {
        public const double TienTruMoiNgayVang = 100000; // 100.000 VND

        public string HoTen;
        public double MucLuong;
        public int SoNgayVang;

        public double TinhLuong()
        {
            return MucLuong - SoNgayVang * TienTruMoiNgayVang;
        }
    }

    // Bài 14: tính lương một nhân viên
    class Bai14
    {
        public static void Chay()
        {
            NhanVien nv = new NhanVien();

            Console.Write("Nhap ho ten nhan vien: ");
            nv.HoTen = Console.ReadLine();
            nv.MucLuong = TienIch.DocSoThucLap("muc luong (VND, vi du 10000000)");
            nv.SoNgayVang = TienIch.DocSoNguyen("ngay vang");

            CultureInfo vn = new CultureInfo("vi-VN");
            double luong = nv.TinhLuong();

            Console.WriteLine();
            Console.WriteLine("Nhan vien: " + nv.HoTen);
            Console.WriteLine("Muc luong: " + nv.MucLuong.ToString("N0", vn) + " VND");
            Console.WriteLine("So ngay vang: " + nv.SoNgayVang
                              + " (tru " + NhanVien.TienTruMoiNgayVang.ToString("N0", vn) + " VND/ngay)");
            Console.WriteLine("Luong thuc nhan: " + luong.ToString("N0", vn) + " VND");
        }
    }
}
