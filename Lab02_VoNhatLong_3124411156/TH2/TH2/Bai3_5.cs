using System;
using System.Collections.Generic;

namespace TH2
{
  
    public abstract class NhanVien
    {
        protected string maNV;
        protected string hoTen;

        public string MaNV { get { return maNV; } set { maNV = value; } }
        public string HoTen { get { return hoTen; } set { hoTen = value; } }

        public NhanVien()
        {
            maNV = string.Empty;
            hoTen = string.Empty;
        }

        public NhanVien(string maNV, string hoTen)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
        }

        public virtual void Nhap()
        {
            maNV = TienIch.DocChuoi("Nhap ma nhan vien: ");
            hoTen = TienIch.DocChuoi("Nhap ho ten nhan vien: ");
        }

        // Phuong thuc truu tuong tinh luong - the hien tinh da hinh
        public abstract double TinhLuong();

        public virtual void Xuat()
        {
            Console.Write("Ma NV: {0,-10} | Ho ten: {1,-20} | ", maNV, hoTen);
        }
    }

    
    public class NhanVienKinhDoanh : NhanVien
    {
        private double luongCoBan;
        private int soHopDong;

        public const double HOA_HONG_HOP_DONG = 500000.0;

        public double LuongCoBan { get { return luongCoBan; } set { luongCoBan = value >= 0 ? value : 0; } }
        public int SoHopDong { get { return soHopDong; } set { soHopDong = value >= 0 ? value : 0; } }

        public NhanVienKinhDoanh() : base()
        {
            luongCoBan = 0;
            soHopDong = 0;
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, int soHopDong) : base(maNV, hoTen)
        {
            this.luongCoBan = luongCoBan;
            this.soHopDong = soHopDong;
        }

        public override void Nhap()
        {
            base.Nhap();
            luongCoBan = TienIch.DocSoThucKhongAm("Nhap muc luong co ban hang thang: ");
            soHopDong = TienIch.DocSoNguyenKhongAm("Nhap so hop dong ky ket: ");
        }

        public override double TinhLuong()
        {
            return luongCoBan + (soHopDong * HOA_HONG_HOP_DONG);
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Bo phan: Kinh doanh | Luong CB: {0,10:N0} | So HD: {1,2} | Luong: {2,12:N0} VND",
                luongCoBan, soHopDong, TinhLuong());
        }
    }

    /// <summary>
    /// Nhan vien san xuat: Luong = So san pham * 1000. Neu > 3000 san pham thi thuong 5%
    /// </summary>
    public class NhanVienSanXuat : NhanVien
    {
        private int soSanPham;
        public const double DON_GIA_SAN_PHAM = 1000.0;

        public int SoSanPham { get { return soSanPham; } set { soSanPham = value >= 0 ? value : 0; } }

        public NhanVienSanXuat() : base()
        {
            soSanPham = 0;
        }

        public NhanVienSanXuat(string maNV, string hoTen, int soSanPham) : base(maNV, hoTen)
        {
            this.soSanPham = soSanPham;
        }

        public override void Nhap()
        {
            base.Nhap();
            soSanPham = TienIch.DocSoNguyenKhongAm("Nhap so luong san pham: ");
        }

        public override double TinhLuong()
        {
            double luong = soSanPham * DON_GIA_SAN_PHAM;
            if (soSanPham > 3000)
            {
                luong += luong * 0.05; // Thuong 5% luong
            }
            return luong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Bo phan: San xuat   | So SP: {0,6} | Thuong: {1,-5} | Luong: {2,12:N0} VND",
                soSanPham, soSanPham > 3000 ? "5%" : "0%", TinhLuong());
        }
    }

    /// <summary>
    /// Bai 3.5: Tinh luong nhan vien cong ty X (Ke thua va Da hinh)
    /// </summary>
    public class Bai3_5
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 3.5: TINH LUONG NHAN VIEN CONG TY X (KE THUA VA DA HINH) ");

            int n = TienIch.DocSoNguyenDuong("Nhap so luong nhan vien trong cong ty: ");
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Chon loai nhan vien thu {0} ", i + 1);
                Console.WriteLine("1. Nhan vien kinh doanh");
                Console.WriteLine("2. Nhan vien san xuat");
                int loai = 0;
                while (loai != 1 && loai != 2)
                {
                    loai = TienIch.DocSoNguyen("Chon loai (1 hoac 2): ");
                    if (loai != 1 && loai != 2)
                    {
                        Console.WriteLine("Loi: Vui long chon 1 hoac 2!");
                    }
                }

                NhanVien nv;
                if (loai == 1)
                {
                    nv = new NhanVienKinhDoanh();
                }
                else
                {
                    nv = new NhanVienSanXuat();
                }

                nv.Nhap();
                dsNhanVien.Add(nv);
            }

            Console.WriteLine("\n BANG LUONG NHAN VIEN CONG TY X ");
            double tongLuong = 0;
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                Console.Write("{0,2}. ", i + 1);
                dsNhanVien[i].Xuat();
                tongLuong += dsNhanVien[i].TinhLuong();
            }
            Console.WriteLine("");
            Console.WriteLine("TONG LUONG TOAN CONG TY: {0:N0} VND", tongLuong);
        }
    }
}
