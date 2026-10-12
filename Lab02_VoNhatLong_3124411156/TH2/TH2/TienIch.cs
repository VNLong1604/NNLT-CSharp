using System;

namespace TH2
{
    
    public static class TienIch
    {
        
        public static int DocSoNguyen(string thongBao)
        {
            int giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (int.TryParse(input, out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Du lieu nhap vao khong phai la so nguyen hop le. Vui long nhap lai!");
            }
        }

        
        public static int DocSoNguyenDuong(string thongBao)
        {
            int giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (int.TryParse(input, out giaTri) && giaTri > 0)
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Vui long nhap mot so nguyen duong (> 0)!");
            }
        }

       
        public static int DocSoNguyenKhongAm(string thongBao)
        {
            int giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (int.TryParse(input, out giaTri) && giaTri >= 0)
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Vui long nhap mot so nguyen khong am (>= 0)!");
            }
        }

        le DocSoThuc(string thongBao)
        {
            double giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (double.TryParse(input, out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Du lieu nhap vao khong phai la so thuc hop le. Vui long nhap lai!");
            }
        }

       
        public static double DocSoThucKhongAm(string thongBao)
        {
            double giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (double.TryParse(input, out giaTri) && giaTri >= 0)
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Vui long nhap so thuc khong am (>= 0)!");
            }
        }

        public static string DocChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Loi: Chuoi khong duoc de trong. Vui long nhap lai!");
            }
        }
    }
}
