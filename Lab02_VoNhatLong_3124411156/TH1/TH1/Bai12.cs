using System;

namespace TH1
{
    // Bài 12: chuyển chuỗi sang chữ thường, chữ hoa, đếm số từ
    class Bai12
    {
        public static int DemTu(string s)
        {
            string[] tu = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tu.Length;
        }

        public static void Chay()
        {
            Console.Write("Nhap chuoi gom nhieu tu: ");
            string s = Console.ReadLine();

            Console.WriteLine("Ky tu thuong: " + s.ToLower());
            Console.WriteLine("Ky tu hoa:    " + s.ToUpper());
            Console.WriteLine("So tu trong chuoi: " + DemTu(s));
        }
    }
}
