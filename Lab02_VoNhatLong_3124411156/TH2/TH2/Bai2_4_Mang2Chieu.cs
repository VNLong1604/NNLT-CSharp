using System;
using System.Collections.Generic;

namespace TH2
{
   
    public class Mang2Chieu
    {
        // Field
        private int[,] a;
        private int dong;
        private int cot;

        public int SoDong
        {
            get { return dong; }
        }

        public int SoCot
        {
            get { return cot; }
        }

        
    }

    
    public class Bai2_4_Mang2Chieu
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.4 (TRANG 2): LOP CHUA MANG 2 CHIEU ");

            Console.WriteLine("\n 1. Nhap mang 2 chieu ");
            Mang2Chieu m = new Mang2Chieu();
            m.Nhap();

            Console.WriteLine("\n Mang 2 chieu vua nhap ");
            m.Xuat();

            Console.WriteLine("\n 2. Kiem tra Indexer tai vi tri (i, j) ");
            if (m.SoDong > 0 && m.SoCot > 0)
            {
                int i = TienIch.DocSoNguyenKhongAm(string.Format("Nhap chi so dong i (0 den {0}): ", m.SoDong - 1));
                int j = TienIch.DocSoNguyenKhongAm(string.Format("Nhap chi so cot j (0 den {0}): ", m.SoCot - 1));
                if (i < m.SoDong && j < m.SoCot)
                {
                    Console.WriteLine("Phan tu tai vi tri [{0}, {1}] = {2}", i, j, m[i, j]);
                }
                else
                {
                    Console.WriteLine("Toa do nam ngoai pham vi mang!");
                }
            }

            Console.WriteLine("\n 3. Tim cac so nguyen to trong mang 2 chieu ");
            List<int> dsSNT = m.TimSoNguyenTo();
            if (dsSNT.Count > 0)
            {
                Console.Write("Cac so nguyen to tim thay: ");
                foreach (int x in dsSNT)
                {
                    Console.Write("{0} ", x);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Khong co so nguyen to nao trong mang!");
            }
        }
    }
}
