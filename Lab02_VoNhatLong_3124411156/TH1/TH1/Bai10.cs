using System;

namespace TH1
{
    // Bài 10: kiểm tra chuỗi có đối xứng hay không
    // (bỏ qua khoảng trắng, không phân biệt hoa thường)
    class Bai10
    {
        public static bool DoiXung(string s)
        {
            string t = s.Replace(" ", "").ToLower();
            for (int i = 0, j = t.Length - 1; i < j; i++, j--)
            {
                if (t[i] != t[j]) return false;
            }
            return true;
        }

        public static void Chay()
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            if (DoiXung(s))
                Console.WriteLine("Chuoi doi xung");
            else
                Console.WriteLine("Chuoi khong doi xung");
        }
    }
}
