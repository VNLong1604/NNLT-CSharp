using System;
using System.Text;

namespace TH2
{
    
    public class DaThuc
    {
        // Field: mang gom n+1 don thuc
        private DonThuc[] donThucs;
        private int bac;

        public int Bac
        {
            get { return bac; }
        }

       
    }

    
    public class Bai2_3_DaThuc
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.3 (TRANG 3): LOP DA THUC ");

            Console.WriteLine("\n 1. Nhap da thuc P(x) ");
            DaThuc dt = new DaThuc();
            dt.Nhap();

            Console.Write("\nDa thuc vua nhap: ");
            dt.Xuat();

            Console.WriteLine("\n 2. Kiem tra Indexer truy cap don thuc thu i ");
            int idx = TienIch.DocSoNguyenKhongAm(string.Format("Nhap chi so don thuc thu i muon xem (0 den {0}): ", dt.Bac));
            if (idx <= dt.Bac)
            {
                Console.WriteLine("Don thuc thu {0} la: {1}", idx, dt[idx]);
            }
            else
            {
                Console.WriteLine("Chi so vuot qua bac cua da thuc!");
            }

            Console.WriteLine("\n 3. Tinh gia tri da thuc voi gia tri x ");
            double x = TienIch.DocSoThuc("Nhap gia tri x tu ban phim: ");
            double kq = dt.TinhGiaTri(x);
            Console.WriteLine("Gia tri P({0}) = {1}", x, kq);
        }
    }
}
