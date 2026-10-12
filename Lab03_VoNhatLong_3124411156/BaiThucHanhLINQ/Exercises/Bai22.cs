using System;
using System.Linq;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai22
    {
        public static void Run()
        {
            string[] mangChuoi =
            {
                "đầu", "lòng", "hai", "ả", "tố", "nga",
                "Thúy", "Kiều", "là", "chị", "em", "là",
                "Thúy", "Vân"
            };

            Console.WriteLine("===== BÀI 2.2 =====");

            
            // CÂU A
            Console.WriteLine("\nCâu a - Chuỗi có 4 ký tự, sắp xếp theo ký tự đầu:");

            var ketQuaA = mangChuoi
                .Where(x => x.Length == 4)
                .OrderBy(x => char.ToLower(x[0]));

            foreach (var x in ketQuaA)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();


            
            // CÂU B
            Console.WriteLine("\nCâu b - Chuyển thành dạng chữ thường - chữ hoa:");

            var ketQuaB = mangChuoi
                .Select(x => $"{x.ToLower()} - {x.ToUpper()}");

            foreach (var x in ketQuaB)
            {
                Console.WriteLine(x);
            }


            
            // CÂU C
            Console.WriteLine("\nCâu c - Chuỗi có chứa ký tự 'u':");

            var ketQuaC = mangChuoi
                .Where(x => x.Contains("u"));

            foreach (var x in ketQuaC)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();


           
            // CÂU D
            Console.WriteLine("\nCâu d - Chuỗi bắt đầu bằng chữ in hoa:");

            var ketQuaD = mangChuoi
                .Where(x => x.Length > 0 && char.IsUpper(x[0]));

            foreach (var x in ketQuaD)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }
    }
}