using System;

namespace TH1
{
    // Bài 4: như Bài 3, báo lỗi khi x hay y không phải số nguyên
    class Bai4
    {
        public static void Chay()
        {
            int x, y;

            Console.Write("Nhap so nguyen x: ");
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Loi: x khong phai la so nguyen!");
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            if (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Loi: y khong phai la so nguyen!");
                return;
            }

            double kq = Math.Pow(x, y);
            Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + kq);
        }
    }
}
