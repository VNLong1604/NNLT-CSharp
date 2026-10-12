using System;

namespace TH2
{
    
    public class Bai1_5
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 1.5: XAY DUNG LOP DON THUC ");

            DonThuc p = new DonThuc();
            Console.WriteLine("Nhap thong tin don thuc P(x) = a * x^n:");
            p.Nhap();

            Console.WriteLine("\nDon thuc P(x) vua nhap: {0}", p);

            Console.WriteLine("\n (a) Tinh gia tri don thuc P(x) ");
            double x = TienIch.DocSoThuc("Nhap gia tri x: ");
            double giaTri = p.TinhGiaTri(x);
            Console.WriteLine("Gia tri cua P({0}) = {1}", x, giaTri);

            Console.WriteLine("\n (b) Dao ham cua don thuc P(x) ");
            DonThuc daoHam = p.DaoHam();
            Console.WriteLine("Dao ham P'(x) = {0}", daoHam);
        }
    }
}
