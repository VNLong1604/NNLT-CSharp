using System;

namespace TH2
{
    
    public class SanPham : IComparable
    {
        private string maSP;
        private string tenSP;
        private double gia;

        public string MaSP { get { return maSP; } set { maSP = value; } }
        public string TenSP { get { return tenSP; } set { tenSP = value; } }
        public double Gia { get { return gia; } set { gia = value >= 0 ? value : 0; } }

        public SanPham()
        {
            maSP = string.Empty;
            tenSP = string.Empty;
            gia = 0;
        }

        public SanPham(string maSP, string tenSP, double gia)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.gia = gia;
        }

        public void Nhap()
        {
            maSP = TienIch.DocChuoi("Nhap ma SP: ");
            tenSP = TienIch.DocChuoi("Nhap ten SP: ");
            gia = TienIch.DocSoThucKhongAm("Nhap gia san pham: ");
        }

        public void Xuat()
        {
            Console.WriteLine("Ma SP: {0,-10} | Ten: {1,-20} | Gia: {2,12:N0} VND", maSP, tenSP, gia);
        }

        // So sanh theo gia tang dan
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            SanPham other = obj as SanPham;
            if (other == null)
            {
                throw new ArgumentException("Doi tuong khong phai SanPham!");
            }
            return this.gia.CompareTo(other.gia);
        }
    }

    
    public static class SapXepInterface
    {
        
        public static void SapXep(IComparable[] arr)
        {
            if (arr == null) return;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] != null && arr[j] != null && arr[i].CompareTo(arr[j]) > 0)
                    {
                        IComparable temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

    public class Bai3_2
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 3.2: SAP XEP MANG TONG QUAT BANG INTERFACE (MO PHONG ARRAY.SORT) ");

            int n = TienIch.DocSoNguyenDuong("Nhap so luong san pham: ");
            SanPham[] danhSach = new SanPham[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Nhap san pham thu {0} ", i + 1);
                danhSach[i] = new SanPham();
                danhSach[i].Nhap();
            }

            Console.WriteLine("\n DANH SACH SAN PHAM TRUOC KHI SAP XEP ");
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }

            // Goi phuong thuc sap xep mo phong bang IComparable[]
            SapXepInterface.SapXep(danhSach);

            Console.WriteLine("\n DANH SACH SAN PHAM SAU KHI SAP XEP TANG DAN THEO GIA (SapXepInterface.SapXep) ");
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }
        }
    }
}
