using System;
using System.Collections.Generic;

namespace TH1
{
    // Lớp mảng hai chiều A[n x m] với các phương thức thành viên của Bài 17
    class MaTran
    {
        private int[,] A;
        private int n, m;

        // Sinh ngẫu nhiên trong đoạn [10, 100]
        public void SinhNgauNhien(int n, int m)
        {
            this.n = n;
            this.m = m;
            A = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = rnd.Next(10, 101); // cận trên không tính nên dùng 101
                }
            }
        }

        // In mảng ra màn hình
        public void In()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
        }

        // Trả về hai mảng: các số chẵn và các số lẻ
        public void TachChanLe(out int[] chan, out int[] le)
        {
            List<int> c = new List<int>();
            List<int> l = new List<int>();
            foreach (int v in A)
            {
                if (v % 2 == 0) c.Add(v);
                else l.Add(v);
            }
            chan = c.ToArray();
            le = l.ToArray();
        }
    }

    // Bài 17: mảng hai chiều
    class Bai17
    {
        public static void Chay()
        {
            int n = TienIch.DocSoDuong("so dong n (n >= 1)");
            int m = TienIch.DocSoDuong("so cot m (m >= 1)");

            MaTran mt = new MaTran();
            mt.SinhNgauNhien(n, m);

            Console.WriteLine();
            Console.WriteLine("Mang A[" + n + "x" + m + "] (gia tri trong doan [10, 100]):");
            mt.In();

            int[] chan, le;
            mt.TachChanLe(out chan, out le);

            Console.WriteLine();
            TienIch.InMang("Mang cac so chan:", chan);
            TienIch.InMang("Mang cac so le:  ", le);
        }
    }
}
