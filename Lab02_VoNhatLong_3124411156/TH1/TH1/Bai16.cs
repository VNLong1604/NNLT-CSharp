using System;

namespace TH1
{
    // Bài 16: nhập mảng họ tên của n người, sắp xếp tăng dần
    class Bai16
    {
        public static void Chay()
        {
            int n = TienIch.DocSoDuong("so nguoi n (n >= 1)");
            string[] ds = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap ho ten nguoi thu " + (i + 1) + ": ");
                ds[i] = Console.ReadLine();
            }

            Array.Sort(ds, StringComparer.CurrentCultureIgnoreCase);

            Console.WriteLine();
            Console.WriteLine("Danh sach sau khi sap xep tang dan:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + ". " + ds[i]);
            }
        }
    }
}
