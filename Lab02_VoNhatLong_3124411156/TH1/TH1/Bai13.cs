using System;

namespace TH1
{
    // Lớp sinh viên: mã sinh viên, họ tên, địa chỉ, sinh viên năm thứ mấy
    class SinhVien
    {
        public string MaSV;
        public string HoTen;
        public string DiaChi;
        public int NamThu;

        public void Nhap()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();

            int n;
            Console.Write("Sinh vien nam thu may: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.Write("Khong hop le, nhap lai nam thu (so nguyen >= 1): ");
            }
            NamThu = n;
        }

        public void Xuat()
        {
            Console.WriteLine("Ma sinh vien: " + MaSV);
            Console.WriteLine("Ho ten:       " + HoTen);
            Console.WriteLine("Dia chi:      " + DiaChi);
            Console.WriteLine("Sinh vien nam thu: " + NamThu);
        }
    }

    // Bài 13: nhập xuất thông tin sinh viên
    class Bai13
    {
        public static void Chay()
        {
            SinhVien sv = new SinhVien();
            sv.Nhap();

            Console.WriteLine();
            Console.WriteLine("--- Thong tin sinh vien ---");
            sv.Xuat();
        }
    }
}
