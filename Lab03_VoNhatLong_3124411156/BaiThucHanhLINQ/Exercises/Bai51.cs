using System;
using System.Linq;
using BaiThucHanhLINQ.Data;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai51
    {
        public static void Run()
        {
            var danhSachMon = DuLieu.DS_Mon();

            Console.WriteLine("===== BÀI 5.1 =====");


            // CÂU A
            Console.WriteLine("\nCâu a - Các môn bắt đầu bằng 'Lập trình':");

            var ketQuaA = danhSachMon
                .Where(x => x.TenMon.StartsWith("Lập trình"));

            foreach (var mon in ketQuaA)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon}"
                );
            }



            // CÂU B
            Console.WriteLine("\nCâu b - Hệ CD, sắp xếp số tiết giảm dần, mã môn tăng dần:");

            var ketQuaB = danhSachMon
                .Where(x => x.He == "CD")
                .OrderByDescending(x => x.SoTiet)
                .ThenBy(x => x.MaMon);

            foreach (var mon in ketQuaB)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon} | {mon.He} | {mon.SoTiet} tiết"
                );
            }


            // CÂU C
            Console.WriteLine("\nCâu c - Tên môn có chứa 'web':");

            var ketQuaC = danhSachMon
                .Where(x => x.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                .Select(x => new
                {
                    x.TenMon,
                    x.He
                });

            foreach (var mon in ketQuaC)
            {
                Console.WriteLine(
                    $"{mon.TenMon} | {mon.He}"
                );
            }


            // CÂU D
            Console.WriteLine("\nCâu d - Các môn thuộc hệ KTV, sắp xếp theo mã môn:");

            var ketQuaD = danhSachMon
                .Where(x => x.He == "KTV")
                .OrderBy(x => x.MaMon);

            foreach (var mon in ketQuaD)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon} | {mon.SoTiet} tiết"
                );
            }
        }
    }
}