using System;
using System.Text;

namespace TH1
{
    // Bài 11: trả về chuỗi là đảo của một chuỗi
    class Bai11
    {
        public static string Dao(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public static void Chay()
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            Console.WriteLine("Chuoi dao nguoc: " + Dao(s));
        }
    }
}
