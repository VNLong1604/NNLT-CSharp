using System;

namespace TH1
{
    // Bài 3: nhập hai số nguyên x, y, tính x^y
    class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            double kq = Math.Pow(x, y);
            Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + kq);
        }
    }
}
