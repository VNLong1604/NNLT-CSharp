using System;

namespace TH2
{
    
    public class SinhVien31 : IComparable
    {
        private string maSV;
        private string hoTen;
        private double diemTB;

        public string MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public double DiemTB
        {
            get { return diemTB; }
            set { diemTB = value; }
        }

        public SinhVien31()
        {
            maSV = string.Empty;
            hoTen = string.Empty;
            diemTB = 0;
        }

        public SinhVien31(string maSV, string hoTen, double diemTB)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diemTB = diemTB;
        }

        public void Nhap()
        {
            maSV = TienIch.DocChuoi("Nhap ma SV: ");
            hoTen = TienIch.DocChuoi("Nhap ho ten: ");
            while (true)
            {
                diemTB = TienIch.DocSoThucKhongAm("Nhap diem trung binh (0 - 10): ");
                if (diemTB >= 0 && diemTB <= 10)
                {
                    break;
                }
                Console.WriteLine("Loi: Diem trung binh phai tu 0 den 10!");
            }
        }

        public void Xuat()
        {
            Console.WriteLine("Ma SV: {0,-10} | Ho ten: {1,-20} | Diem TB: {2,4:F1}", maSV, hoTen, diemTB);
        }

        // Cai dat phuong thuc CompareTo cua interface IComparable
        // Sap xep tang dan theo DiemTB; neu trung diem thi so sanh ho ten
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            SinhVien31 other = obj as SinhVien31;
            if (other == null)
            {
                throw new ArgumentException("Doi tuong khong phai la SinhVien31!");
            }

            int compareDiem = this.diemTB.CompareTo(other.diemTB);
            if (compareDiem != 0)
            {
                return compareDiem;
            }
            return string.Compare(this.hoTen, other.hoTen, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Bai 3.1: Dung phuong thuc tinh Array.Sort(...) de sap xep cac doi tuong cua mot lop
    /// </summary>
    public class Bai3_1
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 3.1: DUNG PHUONG THUC TINH ARRAY.SORT(...) ");

            int n = TienIch.DocSoNguyenDuong("Nhap so luong sinh vien: ");
            SinhVien31[] danhSach = new SinhVien31[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Nhap sinh vien thu {0} ", i + 1);
                danhSach[i] = new SinhVien31();
                danhSach[i].Nhap();
            }

            Console.WriteLine("\n DANH SACH SINH VIEN TRUOC KHI SAP XEP ");
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }

            // Goi phuong thuc tinh Array.Sort(...) theo yeu cau de bai
            Array.Sort(danhSach);

            Console.WriteLine("\n DANH SACH SINH VIEN SAU KHI SAP XEP TANG DAN THEO DIEM TB (Array.Sort) ");
            for (int i = 0; i < danhSach.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Xuat();
            }
        }
    }
}
