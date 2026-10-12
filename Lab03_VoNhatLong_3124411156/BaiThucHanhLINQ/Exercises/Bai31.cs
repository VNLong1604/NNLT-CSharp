using System;
using System.Linq;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai31
    {
        public static void Run()
        {
            int[] mangSo =
            {
                50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85
            };

            Console.WriteLine("===== BÀI 3.1 =====");

            // CÂU A
            Console.WriteLine("\nCâu a - Đếm tổng số, số chẵn, số lẻ:");

            int tongSo = mangSo.Count();

            int soChan = mangSo.Count(x => x % 2 == 0);

            int soLe = mangSo.Count(x => x % 2 != 0);

            Console.WriteLine("Tổng số phần tử: " + tongSo);
            Console.WriteLine("Số phần tử chẵn: " + soChan);
            Console.WriteLine("Số phần tử lẻ: " + soLe);


        
            // CÂU B
            Console.WriteLine("\nCâu b - Tổng, lớn nhất, nhỏ nhất:");

            int tong = mangSo.Sum();
            int lonNhat = mangSo.Max();
            int nhoNhat = mangSo.Min();

            Console.WriteLine("Tổng: " + tong);
            Console.WriteLine("Lớn nhất: " + lonNhat);
            Console.WriteLine("Nhỏ nhất: " + nhoNhat);


            
            // CÂU C
            Console.WriteLine("\nCâu c - Số lượng phần tử không trùng:");

            int soLuongKhacNhau = mangSo
                .Distinct()
                .Count();

            Console.WriteLine("Số lượng khác nhau: " + soLuongKhacNhau);


            
            // CÂU D
            Console.WriteLine("\nCâu d - Nhóm theo số dư khi chia cho 5:");

            var nhomTheoDu = mangSo
                .GroupBy(x => x % 5)
                .OrderBy(g => g.Key);

            foreach (var nhom in nhomTheoDu)
            {
                Console.WriteLine(
                    "Số dư " + nhom.Key + ": " +
                    string.Join(", ", nhom)
                );
            }
        }
    }
}