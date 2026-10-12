using System;
using System.Linq;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai21
    {
        public static void Run()
        {
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            Console.WriteLine("===== BÀI 2.1 =====");

            // Câu a
            Console.WriteLine("\nCâu a - Chia hết cho 4 và 3:");

            var ketQuaA = mangSo
                .Where(x => x % 4 == 0 && x % 3 == 0);

            foreach (var x in ketQuaA)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            // Câu b
            Console.WriteLine("\nCâu b - Nhỏ hơn hoặc bằng 3:");

            var ketQuaB = mangSo
                .Where(x => x <= 3);

            foreach (var x in ketQuaB)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            // Câu c
            Console.WriteLine("\nCâu c - Số chẵn chia đôi, số lẻ giữ nguyên:");

            var ketQuaC = mangSo
                .Select(x => x % 2 == 0 ? x / 2 : x);

            foreach (var x in ketQuaC)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }
    }
}