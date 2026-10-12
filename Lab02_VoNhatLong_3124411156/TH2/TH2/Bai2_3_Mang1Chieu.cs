using System;
using System.Collections.Generic;

namespace TH2
{
    
    public class DaySo
    {
        // Field
        private int[] a;

        public int Length
        {
            get { return a != null ? a.Length : 0; }
        }

    
    }

   
    public class Bai2_3_Mang1Chieu
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.3 (TRANG 2): LOP CHUA MANG 1 CHIEU ");

            Console.WriteLine("\n 1. Khoi tao va nhap day so ");
            DaySo ds = new DaySo();
            ds.Nhap();

            Console.Write("\nDay so vua nhap: ");
            ds.Xuat();

            Console.WriteLine("\n 2. Kiem tra Indexer ");
            if (ds.Length > 0)
            {
                int idx = TienIch.DocSoNguyenKhongAm(string.Format("Nhap chi so i muon truy cap (0 den {0}): ", ds.Length - 1));
                if (idx < ds.Length)
                {
                    Console.WriteLine("Phan tu tai vi tri [{0}] = {1}", idx, ds[idx]);
                }
                else
                {
                    Console.WriteLine("Chi so vuot qua gioi han!");
                }
            }

            Console.WriteLine("\n 3. Tim cac so chan trong day ");
            List<int> cacSoChan = ds.TimSoChan();
            if (cacSoChan.Count > 0)
            {
                Console.Write("Cac so chan tim duoc: ");
                foreach (int x in cacSoChan)
                {
                    Console.Write("{0} ", x);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Khong co so chan nao trong day!");
            }
        }
    }
}
