using System;
using System.Collections.Generic;

namespace TH1
{
    // Lớp mảng một chiều với các phương thức thành viên của Bài 15
    class MangSo
    {
        private int[] a;

        // Nhập mảng gồm n phần tử
        public void Nhap(int n)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                int v;
                Console.Write("a[" + i + "] = ");
                while (!int.TryParse(Console.ReadLine(), out v))
                {
                    Console.Write("Khong hop le, nhap lai a[" + i + "] = ");
                }
                a[i] = v;
            }
        }

        // In mảng ra màn hình
        public void In()
        {
            Console.WriteLine(string.Join(" ", a));
        }

        // Tìm phần tử lớn nhất và nhỏ nhất
        public void TimMaxMin(out int max, out int min)
        {
            max = a[0];
            min = a[0];
            foreach (int v in a)
            {
                if (v > max) max = v;
                if (v < min) min = v;
            }
        }

        // Trả về mảng các số nguyên tố (dùng lại hàm của Bài 7)
        public int[] TimNguyenTo()
        {
            List<int> ds = new List<int>();
            foreach (int v in a)
            {
                if (Bai7.LaSoNguyenTo(v)) ds.Add(v);
            }
            return ds.ToArray();
        }
    }

    // Bài 15: mảng một chiều
    class Bai15
    {
        public static void Chay()
        {
            int n = TienIch.DocSoDuong("so phan tu n (n >= 1)");

            MangSo ms = new MangSo();
            ms.Nhap(n);

            Console.WriteLine();
            Console.Write("Mang vua nhap: ");
            ms.In();

            int max, min;
            ms.TimMaxMin(out max, out min);
            Console.WriteLine("Phan tu lon nhat: " + max);
            Console.WriteLine("Phan tu nho nhat: " + min);

            TienIch.InMang("Cac so nguyen to trong mang:", ms.TimNguyenTo());
        }
    }
}
