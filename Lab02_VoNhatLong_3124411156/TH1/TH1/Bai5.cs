using System;

namespace TH1
{
    // Bài 5: menu xử lý các lựa chọn
    class Bai5
    {
        static void CanBacHai(string ten, double v)
        {
            if (v < 0)
                Console.WriteLine("Khong tinh duoc can bac 2 cua " + ten + " (am)");
            else
                Console.WriteLine("Can bac 2 cua " + ten + " la: " + Math.Sqrt(v));
        }

        public static void Chay()
        {
            double x = 0, y = 0;
            bool daNhap = false;
            int chon;

            do
            {
                Console.WriteLine();
                Console.WriteLine("MENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon)) chon = 0;

                switch (chon)
                {
                    case 1:
                        if (TienIch.DocSoThuc("x", out x) && TienIch.DocSoThuc("y", out y))
                            daNhap = true;
                        else
                        {
                            daNhap = false;
                            Console.WriteLine("Loi: gia tri nhap khong hop le!");
                        }
                        break;

                    case 2:
                        if (!daNhap)
                        {
                            Console.WriteLine("Hay chon 1 de nhap x, y truoc!");
                            break;
                        }
                        Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + Math.Pow(x, y));
                        break;

                    case 3:
                        if (!daNhap)
                        {
                            Console.WriteLine("Hay chon 1 de nhap x, y truoc!");
                            break;
                        }
                        CanBacHai("x", x);
                        CanBacHai("y", y);
                        break;

                    case 4:
                        Console.WriteLine("Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (chon != 4);
        }
    }
}
