using System;

namespace TH2
{
    
    public class SinhVien
    {
        // Field
        private string _hoTen;
        private int _namSinh;

        // Property
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public int NamSinh
        {
            get { return _namSinh; }
            set
            {
                if (value <= 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Nam sinh khong hop le!");
                }
                _namSinh = value;
            }
        }

        // Default Constructor
        public SinhVien()
        {
            _hoTen = string.Empty;
            _namSinh = DateTime.Now.Year;
        }

        // Parameter Constructor
        public SinhVien(string hoTen, int namSinh)
        {
            _hoTen = hoTen;
            _namSinh = namSinh;
        }

        // Copy Constructor
        public SinhVien(SinhVien other)
        {
            if (other != null)
            {
                _hoTen = other._hoTen;
                _namSinh = other._namSinh;
            }
        }

        // Method nhap thong tin
        public void Nhap()
        {
            _hoTen = TienIch.DocChuoi("Nhap ho ten sinh vien: ");
            int currentYear = DateTime.Now.Year;
            while (true)
            {
                _namSinh = TienIch.DocSoNguyenDuong("Nhap nam sinh: ");
                if (_namSinh <= currentYear)
                {
                    break;
                }
                Console.WriteLine("Loi: Nam sinh phai nho hon hoac bang nam hien tai ({0})!", currentYear);
            }
        }

        // Method tinh tuoi
        public int TinhTuoi()
        {
            return DateTime.Now.Year - _namSinh;
        }

        // Method xuat thong tin
        public void Xuat()
        {
            Console.WriteLine("Ho ten sinh vien: {0}", _hoTen);
            Console.WriteLine("Nam sinh: {0}", _namSinh);
            Console.WriteLine("Tuoi: {0}", TinhTuoi());
        }
    }

    public class Bai1_1
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 1.1: TINH TUOI 1 SINH VIEN ");
            SinhVien sv = new SinhVien();
            sv.Nhap();
            Console.WriteLine("\n THONG TIN SINH VIEN ");
            sv.Xuat();
        }
    }
}
