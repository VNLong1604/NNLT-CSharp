using System;
using System.Globalization;

namespace TH1
{
    // Các hàm nhập/xuất dùng chung cho nhiều bài
    static class TienIch
    {
        // Đọc 1 số thực, chấp nhận cả dấu . và dấu ,
        public static bool DocSoThuc(string ten, out double giaTri)
        {
            Console.Write("Nhap " + ten + ": ");
            string s = Console.ReadLine().Replace(',', '.');
            return double.TryParse(s, NumberStyles.Float,
                                   CultureInfo.InvariantCulture, out giaTri);
        }

        // Đọc số nguyên, nhập sai thì bắt nhập lại
        public static int DocSoNguyen(string ten)
        {
            int v;
            Console.Write("Nhap so nguyen " + ten + ": ");
            while (!int.TryParse(Console.ReadLine(), out v))
            {
                Console.Write("Khong hop le, nhap lai so nguyen " + ten + ": ");
            }
            return v;
        }

        // Đọc số nguyên dương (>= 1), nhập sai thì bắt nhập lại
        public static int DocSoDuong(string ten)
        {
            int v;
            Console.Write("Nhap " + ten + ": ");
            while (!int.TryParse(Console.ReadLine(), out v) || v < 1)
            {
                Console.Write("Khong hop le, nhap lai " + ten + ": ");
            }
            return v;
        }

        // Đọc số thực, nhập sai thì bắt nhập lại
        public static double DocSoThucLap(string ten)
        {
            double v;
            while (!DocSoThuc(ten, out v))
            {
                Console.WriteLine("Gia tri khong hop le, nhap lai!");
            }
            return v;
        }

        // In một mảng số nguyên kèm tiêu đề
        public static void InMang(string tieuDe, int[] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine(tieuDe + " (khong co phan tu nao)");
            else
                Console.WriteLine(tieuDe + " " + string.Join(" ", arr));
        }
    }
}
