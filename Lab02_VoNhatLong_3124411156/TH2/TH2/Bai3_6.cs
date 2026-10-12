using System;
using System.Collections.Generic;

namespace TH2
{
   
    public abstract class ThiSinh
    {
        protected string sbd;
        protected string hoten;
        protected double bai1;
        protected double bai2;
        protected double bai3;

        public string Sbd { get { return sbd; } set { sbd = value; } }
        public string HoTen { get { return hoten; } set { hoten = value; } }
        public double Bai1 { get { return bai1; } set { bai1 = value; } }
        public double Bai2 { get { return bai2; } set { bai2 = value; } }
        public double Bai3 { get { return bai3; } set { bai3 = value; } }

        public double TongDiem
        {
            get { return TinhTongDiem(); }
        }

        public ThiSinh()
        {
            sbd = string.Empty;
            hoten = string.Empty;
            bai1 = 0;
            bai2 = 0;
            bai3 = 0;
        }

        public ThiSinh(string sbd, string hoten, double b1, double b2, double b3)
        {
            this.sbd = sbd;
            this.hoten = hoten;
            this.bai1 = b1;
            this.bai2 = b2;
            this.bai3 = b3;
        }

        private double NhapDiemBaiThi(string tenBai)
        {
            while (true)
            {
                double d = TienIch.DocSoThucKhongAm(string.Format("Nhap diem {0} (0 - 10): ", tenBai));
                if (d >= 0 && d <= 10)
                {
                    return d;
                }
                Console.WriteLine("Loi: Diem thi phai nam trong khoang tu 0 den 10!");
            }
        }

        public virtual void Nhap()
        {
            sbd = TienIch.DocChuoi("Nhap so bao danh (SBD): ");
            hoten = TienIch.DocChuoi("Nhap ho ten thi sinh: ");
            bai1 = NhapDiemBaiThi("bai 1");
            bai2 = NhapDiemBaiThi("bai 2");
            bai3 = NhapDiemBaiThi("bai 3");
        }

        // Phuong thuc truu tuong tinh tong diem cua tung doi tuong thi sinh
        public abstract double TinhTongDiem();

        public virtual void Xuat()
        {
            Console.Write("SBD: {0,-8} | Ho ten: {1,-18} | B1: {2,4:F1} | B2: {3,4:F1} | B3: {4,4:F1} | ",
                sbd, hoten, bai1, bai2, bai3);
        }
    }

    public class ThiSinhChuyen : ThiSinh
    {
        private double tiengAnh;

        public double TiengAnh { get { return tiengAnh; } set { tiengAnh = value; } }

        public ThiSinhChuyen() : base()
        {
            tiengAnh = 0;
        }

        public ThiSinhChuyen(string sbd, string hoten, double b1, double b2, double b3, double tiengAnh)
            : base(sbd, hoten, b1, b2, b3)
        {
            this.tiengAnh = tiengAnh;
        }

        public override void Nhap()
        {
            base.Nhap();
            while (true)
            {
                tiengAnh = TienIch.DocSoThucKhongAm("Nhap diem tieng Anh (0 - 10): ");
                if (tiengAnh >= 0 && tiengAnh <= 10)
                {
                    break;
                }
                Console.WriteLine("Loi: Diem tieng Anh phai tu 0 den 10!");
            }
        }

        // Tinh diem thuong tieng Anh theo quy dinh cua de bai
        public double TinhDiemThuongTiengAnh()
        {
            if (tiengAnh >= 9.0 && tiengAnh <= 10.0)
            {
                return 2.0;
            }
            if (tiengAnh >= 7.0 && tiengAnh <= 8.0) // 7 <= tiengAnh <= 8
            {
                return 1.0;
            }
            return 0.0;
        }

        public override double TinhTongDiem()
        {
            return bai1 + bai2 + bai3 + TinhDiemThuongTiengAnh();
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Doi tuong: Chuyen   | TA: {0,4:F1} (Thuong +{1}) | Tong diem: {2,5:F1}",
                tiengAnh, TinhDiemThuongTiengAnh(), TongDiem);
        }
    }

    /// <summary>
    /// Thi sinh Sieu cup (da co giai truoc day)
    /// Thi them mon Co so du lieu (CSDL).
    /// Tong diem = bai1 + bai2 + bai3 + csdl (tong 4 bai)
    /// </summary>
    public class ThiSinhSieuCup : ThiSinh
    {
        private double csdl;

        public double Csdl { get { return csdl; } set { csdl = value; } }

        public ThiSinhSieuCup() : base()
        {
            csdl = 0;
        }

        public ThiSinhSieuCup(string sbd, string hoten, double b1, double b2, double b3, double csdl)
            : base(sbd, hoten, b1, b2, b3)
        {
            this.csdl = csdl;
        }

        public override void Nhap()
        {
            base.Nhap();
            while (true)
            {
                csdl = TienIch.DocSoThucKhongAm("Nhap diem Co so du lieu (0 - 10): ");
                if (csdl >= 0 && csdl <= 10)
                {
                    break;
                }
                Console.WriteLine("Loi: Diem CSDL phai tu 0 den 10!");
            }
        }

        public override double TinhTongDiem()
        {
            return bai1 + bai2 + bai3 + csdl;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Doi tuong: Sieu cup | CSDL: {0,4:F1}  | Tong diem: {1,5:F1}",
                csdl, TongDiem);
        }
    }

 
    public class CuocThi
    {
        private List<ThiSinh> dsThiSinh;

        public CuocThi()
        {
            dsThiSinh = new List<ThiSinh>();
        }

        public void Nhap()
        {
            int n = TienIch.DocSoNguyenDuong("Nhap so luong thi sinh du thi: ");
            dsThiSinh.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Chon doi tuong cho thi sinh thu {0} ", i + 1);
                Console.WriteLine("1. Thi sinh Chuyen (chua co giai truoc day)");
                Console.WriteLine("2. Thi sinh Sieu cup (da co giai truoc day)");
                int loai = 0;
                while (loai != 1 && loai != 2)
                {
                    loai = TienIch.DocSoNguyen("Chon doi tuong (1 hoac 2): ");
                    if (loai != 1 && loai != 2)
                    {
                        Console.WriteLine("Loi: Vui long chon 1 hoac 2!");
                    }
                }

                ThiSinh ts;
                if (loai == 1)
                {
                    ts = new ThiSinhChuyen();
                }
                else
                {
                    ts = new ThiSinhSieuCup();
                }

                ts.Nhap();
                dsThiSinh.Add(ts);
            }
        }

        public void Xuat()
        {
            Console.WriteLine("\n KET QUA CUOC THI TIN HOC ");
            if (dsThiSinh.Count == 0)
            {
                Console.WriteLine("(Chua co thi sinh nao du thi)");
                return;
            }
            for (int i = 0; i < dsThiSinh.Count; i++)
            {
                Console.Write("{0,2}. ", i + 1);
                dsThiSinh[i].Xuat();
            }
            
        }
    }

  
    public class Bai3_6
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 3.6: TINH DIEM THI SINH CUOC THI TIN HOC (KE THUA & DA HINH) ");

            CuocThi ct = new CuocThi();
            ct.Nhap();
            ct.Xuat();
        }
    }
}
