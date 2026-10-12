using System;

namespace TH2
{
    // Dinh nghia delegate so sanh 2 doi tuong kieu T
    public delegate int SoSanhDelegate<T>(T a, T b);

   
    public class HocVien33
    {
        private string hoTen;
        private double diem;

        public string HoTen { get { return hoTen; } set { hoTen = value; } }
        public double Diem { get { return diem; } set { diem = value; } }

        public HocVien33()
        {
            hoTen = string.Empty;
            diem = 0;
        }

        public HocVien33(string hoTen, double diem)
        {
            this.hoTen = hoTen;
            this.diem = diem;
        }

        public void Nhap()
        {
            hoTen = TienIch.DocChuoi("Nhap ho ten: ");
            while (true)
            {
                diem = TienIch.DocSoThucKhongAm("Nhap diem (0 - 10): ");
                if (diem >= 0 && diem <= 10) break;
                Console.WriteLine("Loi: Diem phai tu 0 den 10!");
            }
        }

        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0,-20} | Diem: {1,4:F1}", hoTen, diem);
        }

        // Cac ham so sanh phu hop voi signature cua SoSanhDelegate<HocVien33>
        public static int SoSanhTheoTenTangDan(HocVien33 a, HocVien33 b)
        {
            return string.Compare(a.hoTen, b.hoTen, StringComparison.OrdinalIgnoreCase);
        }

        public static int SoSanhTheoDiemGiamDan(HocVien33 a, HocVien33 b)
        {
            // Giam dan: diem cao hon xep truoc
            return b.diem.CompareTo(a.diem);
        }
    }

    
    public static class SapXepDelegateHelper
    {
     
        public static void SapXep<T>(T[] arr, SoSanhDelegate<T> soSanh)
        {
            if (arr == null || soSanh == null) return;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (soSanh(arr[i], arr[j]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

   
    public class Bai3_3
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 3.3: SAP XEP MANG TONG QUAT BANG DELEGATE ");

            int n = TienIch.DocSoNguyenDuong("Nhap so luong hoc vien: ");
            HocVien33[] danhSach = new HocVien33[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Nhap hoc vien thu {0} ", i + 1);
                danhSach[i] = new HocVien33();
                danhSach[i].Nhap();
            }

            Console.WriteLine("\n DANH SACH HOC VIEN BAN DAU ");
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }

            // 1. Sap xep theo Ten tang dan bang delegate
            Console.WriteLine("\n 1. SAP XEP THEO HO TEN TANG DAN (Su dung delegate) ");
            SapXepDelegateHelper.SapXep(danhSach, HocVien33.SoSanhTheoTenTangDan);
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }

            // 2. Sap xep theo Diem giam dan bang delegate
            Console.WriteLine("\n 2. SAP XEP THEO DIEM GIAM DAN (Su dung delegate) ");
            SapXepDelegateHelper.SapXep(danhSach, HocVien33.SoSanhTheoDiemGiamDan);
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }
        }
    }
}
