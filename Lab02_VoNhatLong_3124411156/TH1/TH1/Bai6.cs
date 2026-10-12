using System;

namespace TH1
{
    // Bài 6: return giá trị - tìm giá trị lớn nhất của ba số nguyên
    class Bai6
    {
        public static int Max3(int a, int b, int c)
        {
            int max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            return max;
        }

        public static void Chay()
        {
            int a = TienIch.DocSoNguyen("a");
            int b = TienIch.DocSoNguyen("b");
            int c = TienIch.DocSoNguyen("c");

            Console.WriteLine("Gia tri lon nhat cua " + a + ", " + b + ", " + c
                              + " la: " + Max3(a, b, c));
        }
    }
}
