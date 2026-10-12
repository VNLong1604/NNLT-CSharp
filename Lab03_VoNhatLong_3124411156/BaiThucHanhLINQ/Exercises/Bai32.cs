using System;
using System.Linq;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai32
    {
        public static void Run()
        {
            string[] mangMonAn =
            {
                "Bún bò Huế",
                "Hủ tiếu heo",
                "Bánh canh",
                "Bánh mì",
                "Nước Cà phê",
                "Mì quảng",
                "Cơm tấm",
                "Nước Chanh dây",
                "Mì xào",
                "Bún riêu",
                "Bánh cuốn",
                "Mì gói",
                "Bún chả",
                "Hủ tiếu Nam vang"
            };

            Console.WriteLine("===== BÀI 3.2 =====");


            // CÂU A
            Console.WriteLine("\nCâu a - Món ăn ngắn nhất và dài nhất:");

            var nganNhat = mangMonAn
                .OrderBy(x => x.Length)
                .First();

            var daiNhat = mangMonAn
                .OrderByDescending(x => x.Length)
                .First();

            Console.WriteLine("Ngắn nhất: " + nganNhat);
            Console.WriteLine("Dài nhất: " + daiNhat);


            // CÂU B
            Console.WriteLine("\nCâu b - Nhóm theo từ đầu tiên:");

            var nhomTheoTuDau = mangMonAn
                .GroupBy(x => x.Split(' ')[0]);

            foreach (var nhom in nhomTheoTuDau)
            {
                Console.WriteLine("\n" + nhom.Key + ":");

                foreach (var mon in nhom)
                {
                    Console.WriteLine("  " + mon);
                }
            }


            // CÂU C
            Console.WriteLine("\nCâu c - Số món có từ đầu tiên là 'Bánh':");

            int soMonBanh = mangMonAn
                .Count(x => x.StartsWith("Bánh"));

            Console.WriteLine("Số lượng: " + soMonBanh);
        }
    }
}