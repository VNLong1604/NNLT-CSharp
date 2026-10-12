using System;
using System.Collections.Generic;

namespace TH2
{
    
    public class ConsoleMenu
    {
        protected List<string> danhSachChucNang;
        protected string tieuDeMenu;

        // Su kien Choose: ho tro mo rong qua event delegate
        public event Action<int> Choose;

        public ConsoleMenu(string tieuDe = "MENU CHUONG TRINH")
        {
            this.tieuDeMenu = tieuDe;
            danhSachChucNang = new List<string>();
        }

        // Them chuc nang vao menu
        public void ThemChucNang(string chucNang)
        {
            if (!string.IsNullOrWhiteSpace(chucNang))
            {
                danhSachChucNang.Add(chucNang);
            }
        }

        // Hien thi menu
        public virtual void HienThi()
        {
            Console.WriteLine("\n================== {0} ==================", tieuDeMenu);
            for (int i = 0; i < danhSachChucNang.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, danhSachChucNang[i]);
            }
            Console.WriteLine("0. Thoat chuong trinh");
           
        }

        // Phuong thuc ao de lop con co the override (mo rong qua ke thua)
        public virtual void ThucHien(int chon)
        {
            Console.WriteLine("Ban thuc hien chuc nang: {0}", chon);
            // Kich hoat su kien Choose neu co dang ky (mo rong qua su kien)
            if (Choose != null)
            {
                Choose(chon);
            }
        }

        // Vong lap chay menu
        public void Run()
        {
            while (true)
            {
                HienThi();
                int chon = TienIch.DocSoNguyen("Thuc hien: ");
                if (chon == 0)
                {
                    Console.WriteLine("Tam biet!");
                    break;
                }
                if (chon < 0 || chon > danhSachChucNang.Count)
                {
                    Console.WriteLine("Loi: Chuc nang khong ton tai. Vui long chon lai!");
                    continue;
                }
                ThucHien(chon);
            }
        }
    }

    
    public class PTBac2Console : ConsoleMenu
    {
        private double a;
        private double b;
        private double c;
        private bool daNhap;

        public PTBac2Console() : base("GIAI PHUONG TRINH BAC 2 (ax^2 + bx + c = 0)")
        {
            a = 0;
            b = 0;
            c = 0;
            daNhap = false;

            ThemChucNang("Nhap he so a, b, c");
            ThemChucNang("Giai phuong trinh bac 2 va xuat ket qua");
            ThemChucNang("Xem phuong trinh hien tai");
        }

        // Nhap he so
        private void NhapHeSo()
        {
            Console.WriteLine("\n Nhap cac he so cho phuong trinh ax^2 + bx + c = 0 ");
            a = TienIch.DocSoThuc("Nhap he so a: ");
            b = TienIch.DocSoThuc("Nhap he so b: ");
            c = TienIch.DocSoThuc("Nhap he so c: ");
            daNhap = true;
            Console.WriteLine("Da cap nhat he so: a = {0}, b = {1}, c = {2}", a, b, c);
        }

        // Xem phuong trinh
        private void XemPhuongTrinh()
        {
            Console.WriteLine("\nPhuong trinh hien tai: ({0})x^2 + ({1})x + ({2}) = 0", a, b, c);
        }

        // Giai phuong trinh
        private void GiaiPhuongTrinh()
        {
            if (!daNhap)
            {
                Console.WriteLine("Chua nhap he so. Vui long nhap he so truoc!");
                return;
            }

            XemPhuongTrinh();
            if (a == 0)
            {
                // bx + c = 0
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("Ket qua: Phuong trinh co vo so nghiem.");
                    }
                    else
                    {
                        Console.WriteLine("Ket qua: Phuong trinh vo nghiem.");
                    }
                }
                else
                {
                    double x = -c / b;
                    Console.WriteLine("Ket qua: Phuong trinh bac nhat co 1 nghiem x = {0:F4}", x);
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;
                Console.WriteLine("Delta = {0}", delta);
                if (delta < 0)
                {
                    Console.WriteLine("Ket qua: Delta < 0, phuong trinh vo nghiem thuc.");
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine("Ket qua: Phuong trinh co nghiem kep x1 = x2 = {0:F4}", x);
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("Ket qua: Phuong trinh co 2 nghiem phan biet:");
                    Console.WriteLine("  x1 = {0:F4}", x1);
                    Console.WriteLine("  x2 = {0:F4}", x2);
                }
            }
        }

        // Mo rong qua ke thua: override phuong thuc ThucHien cua lop cha ConsoleMenu
        public override void ThucHien(int chon)
        {
            switch (chon)
            {
                case 1:
                    NhapHeSo();
                    break;
                case 2:
                    GiaiPhuongTrinh();
                    break;
                case 3:
                    XemPhuongTrinh();
                    break;
            }

            // Goi base.ThucHien(chon) de kich hoat su kien Choose neu co su dung mo rong qua event
            base.ThucHien(chon);
        }
    }

    
    public class Bai3_4
    {
        public static void Chay()
        {
            Console.WriteLine("=== BAI 3.4*: LOP CONSOLEMENU TONG QUAT & PTBAC2CONSOLE ===");

           
            PTBac2Console app = new PTBac2Console();

            // Dang ky su kien Choose de ghi log (minh hoa tinh nang mo rong qua su kien)
            app.Choose += (chon) =>
            {
                Console.WriteLine("[Log Event Choose]: Ban da hoan thanh thao tac tren chuc nang {0}", chon);
            };

            // Chay menu
            app.Run();
        }
    }
}
