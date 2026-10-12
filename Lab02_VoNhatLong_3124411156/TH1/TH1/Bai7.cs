using System;

namespace TH1
{
    // Bài 7: phương thức bool - kiểm tra n có phải số nguyên tố không
    class Bai7
    {
        public static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static void Chay()
        {
            int n = TienIch.DocSoNguyen("n");

            if (LaSoNguyenTo(n))
                Console.WriteLine(n + " la so nguyen to");
            else
                Console.WriteLine(n + " khong phai la so nguyen to");
        }
    }
}
