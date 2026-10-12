using System;
using System.Linq;
using BaiThucHanhLINQ.Data;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai52
    {
        public static void Run()
        {
            var danhSachMon = DuLieu.DS_Mon();

            Console.WriteLine("===== BÀI 5.2 =====");
        
            // CÂU A
            Console.WriteLine("\nCâu a - Tổng số môn:");

            int tongSoMon = danhSachMon.Count();

            Console.WriteLine("Tổng số môn: " + tongSoMon);


            
            // CÂU B
            Console.WriteLine("\nCâu b - Số môn bắt đầu bằng 'Lập trình':");

            int soMonLapTrinh = danhSachMon
                .Count(x => x.TenMon.StartsWith("Lập trình"));

            Console.WriteLine("Số môn: " + soMonLapTrinh);



            // CÂU C
            Console.WriteLine("\nCâu c - Tổng số tiết của hệ KTV:");

            int tongTietKTV = danhSachMon
                .Where(x => x.He == "KTV")
                .Sum(x => x.SoTiet);

            Console.WriteLine("Tổng số tiết KTV: " + tongTietKTV);



            // CÂU D
            Console.WriteLine("\nCâu d - Số môn theo từng hệ:");

            var demTheoHe = danhSachMon
                .GroupBy(x => x.He);

            foreach (var nhom in demTheoHe)
            {
                Console.WriteLine(
                    $"Hệ [{nhom.Key}] : {nhom.Count()} môn"
                );
            }


            
            // CÂU E
            Console.WriteLine("\nCâu e - Số môn theo số tiết:");

            var demTheoSoTiet = danhSachMon
                .GroupBy(x => x.SoTiet)
                .OrderByDescending(g => g.Key);

            foreach (var nhom in demTheoSoTiet)
            {
                Console.WriteLine(
                    $"{nhom.Key} tiết: {nhom.Count()} môn"
                );
            }


            // CÂU F
            Console.WriteLine("\nCâu f - Môn có số tiết lớn nhất:");

            var monNhieuTiet = danhSachMon
                .OrderByDescending(x => x.SoTiet)
                .First();

            Console.WriteLine(
                $"{monNhieuTiet.MaMon} | " +
                $"{monNhieuTiet.TenMon} | " +
                $"{monNhieuTiet.SoTiet} tiết"
            );


            
            // CÂU G
            Console.WriteLine("\nCâu g - Thống kê theo từng hệ:");

            var thongKeTheoHe = danhSachMon
                .GroupBy(x => x.He);

            foreach (var nhom in thongKeTheoHe)
            {
                Console.WriteLine($"\nHệ [{nhom.Key}]");

                Console.WriteLine("Số môn: " + nhom.Count());
                Console.WriteLine("Tổng tiết: " + nhom.Sum(x => x.SoTiet));
                Console.WriteLine("Tiết lớn nhất: " + nhom.Max(x => x.SoTiet));
                Console.WriteLine("Tiết nhỏ nhất: " + nhom.Min(x => x.SoTiet));
            }


        
            // CÂU H
            Console.WriteLine("\nCâu h - Nhóm các môn theo hệ:");

            var monTheoHe = danhSachMon
                .GroupBy(x => x.He);

            foreach (var nhom in monTheoHe)
            {
                Console.WriteLine($"\nHệ [{nhom.Key}]");

                foreach (var mon in nhom)
                {
                    Console.WriteLine(
                        $"{mon.MaMon} | {mon.TenMon}"
                    );
                }
            }


            // CÂU I
            Console.WriteLine("\nCâu i - Nhóm môn theo số tiết tăng dần:");

            var monTheoSoTiet = danhSachMon
                .GroupBy(x => x.SoTiet)
                .OrderBy(g => g.Key);

            foreach (var nhom in monTheoSoTiet)
            {
                Console.WriteLine($"\n{nhom.Key} tiết:");

                foreach (var mon in nhom)
                {
                    Console.WriteLine(
                        $"{mon.MaMon} | {mon.TenMon}"
                    );
                }
            }


            // CÂU J
            Console.WriteLine(
                "\nCâu j - Các môn KTV nhóm theo HP2, HP3, HP4, HP5:"
            );

            var nhomKTV = danhSachMon
                .Where(x => x.He == "KTV")
                .GroupBy(x => x.MaMon.Substring(0, 3))
                .OrderBy(g => g.Key);

            foreach (var nhom in nhomKTV)
            {
                Console.WriteLine($"\nNhóm {nhom.Key}:");

                foreach (var mon in nhom.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine(
                        $"{mon.MaMon} | {mon.TenMon}"
                    );
                }
            }


            // CÂU K
            Console.WriteLine(
                "\nCâu k - Nhóm theo hệ, chỉ lấy môn có số tiết > 40:"
            );

            var nhomHeTren40 = danhSachMon
                .Where(x => x.SoTiet > 40)
                .GroupBy(x => x.He)
                .OrderBy(g => g.Key);

            foreach (var nhom in nhomHeTren40)
            {
                Console.WriteLine($"\nHệ [{nhom.Key}]");

                foreach (var mon in nhom.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine(
                        $"{mon.MaMon} | {mon.TenMon} | {mon.SoTiet} tiết"
                    );
                }
            }
        }
    }
}