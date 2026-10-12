using System;
using System.Collections.Generic;

namespace TH2
{
    
    public class DayPhanSo
    {
        // Field
        private List<PhanSo> danhSach;

        public int SoLuong
        {
            get { return danhSach.Count; }
        }

        // Constructor mac nhien
        public DayPhanSo()
        {
            danhSach = new List<PhanSo>();
        }

        // Constructor voi so luong n phan so
        public DayPhanSo(int n)
        {
            danhSach = new List<PhanSo>();
            for (int i = 0; i < n; i++)
            {
                danhSach.Add(new PhanSo());
            }
        }

        // Indexer
        public PhanSo this[int i]
        {
            get
            {
                if (i < 0 || i >= danhSach.Count)
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua so luong phan so!");
                }
                return danhSach[i];
            }
            set
            {
                if (i < 0 || i >= danhSach.Count)
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua so luong phan so!");
                }
                danhSach[i] = value;
            }
        }

        // Nhap n phan so
        public void Nhap()
        {
            int n = TienIch.DocSoNguyenDuong("Nhap so luong phan so n: ");
            danhSach.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap phan so thu {0}:", i + 1);
                PhanSo ps = new PhanSo();
                ps.Nhap();
                danhSach.Add(ps);
            }
        }

        // Xuat day phan so
        public void Xuat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("(Day phan so trong)");
                return;
            }
            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.Write(danhSach[i]);
                if (i < danhSach.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        // Tinh tong n phan so (su dung toan tu + da overload o lop PhanSo)
        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1);
            foreach (PhanSo ps in danhSach)
            {
                tong = tong + ps;
            }
            tong.ChuanHoaDauVaRutGon();
            return tong;
        }
    }

    /// <summary>
    /// Bai 2.4 (Trang 3): Day phan so va tinh tong
    /// </summary>
    public class Bai2_4_DayPhanSo
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.4 (TRANG 3): DAY PHAN SO ");

            DayPhanSo day = new DayPhanSo();
            day.Nhap();

            Console.WriteLine("\n Day phan so vua nhap ");
            day.Xuat();

            Console.WriteLine("\n Tinh tong cua n phan so trong day ");
            PhanSo tong = day.TinhTong();
            Console.WriteLine("Tong cua {0} phan so la: {1}", day.SoLuong, tong);
        }
    }
}
