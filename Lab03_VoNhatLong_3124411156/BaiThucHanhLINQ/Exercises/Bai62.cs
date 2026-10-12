using System;
using System.Linq;
using BaiThucHanhLINQ.Data;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai62
    {
        public static void Run()
        {
            var danhSachMon = DuLieu.DS_Mon();
            var danhSachHe = DuLieu.DS_He();

            Console.WriteLine("===== BÀI 6.2 =====");

            // CÂU A
            Console.WriteLine("\nCâu a - Join hệ và môn:");

            var ketQuaA =
                from he in danhSachHe
                join mon in danhSachMon
                    on he.MaHe equals mon.He
                select new
                {
                    TenHe = he.TenHe,
                    MaMon = mon.MaMon,
                    TenMon = mon.TenMon
                };

            foreach (var item in ketQuaA)
            {
                Console.WriteLine(
                    $"{item.TenHe} | {item.MaMon} | {item.TenMon}"
                );
            }


            
            // CÂU B
            Console.WriteLine("\nCâu b - Left Outer Join:");

            var ketQuaB =
                from he in danhSachHe
                join mon in danhSachMon
                    on he.MaHe equals mon.He into nhomMon
                from mon in nhomMon.DefaultIfEmpty()
                select new
                {
                    TenHe = he.TenHe,
                    MaMon = mon?.MaMon ?? "(Không có)",
                    TenMon = mon?.TenMon ?? "(Không có môn)"
                };

            foreach (var item in ketQuaB)
            {
                Console.WriteLine(
                    $"{item.TenHe} | {item.MaMon} | {item.TenMon}"
                );
            }


            // CÂU C
            Console.WriteLine(
                "\nCâu c - Bao gồm hệ chưa có môn và môn chưa đăng ký hệ:"
            );

            var heCoMon = danhSachMon
                .Select(x => x.He)
                .Distinct();

            var heKhongCoMon = danhSachHe
                .Where(x => !heCoMon.Contains(x.MaHe));

            Console.WriteLine("\nHệ chưa có môn:");

            foreach (var he in heKhongCoMon)
            {
                Console.WriteLine(
                    $"{he.MaHe} | {he.TenHe}"
                );
            }

            var monKhongCoHe = danhSachMon
                .Where(mon =>
                    !danhSachHe.Any(he => he.MaHe == mon.He));

            Console.WriteLine("\nMôn chưa đăng ký hệ:");

            foreach (var mon in monKhongCoHe)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon} | Hệ: {mon.He}"
                );
            }


            // CÂU D
            Console.WriteLine(
                "\nCâu d - Chỉ lấy hệ không có môn và môn không có hệ:"
            );

            Console.WriteLine("\nHệ không có môn:");

            foreach (var he in heKhongCoMon)
            {
                Console.WriteLine(
                    $"{he.MaHe} | {he.TenHe}"
                );
            }

            Console.WriteLine("\nMôn không có hệ:");

            foreach (var mon in monKhongCoHe)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon}"
                );
            }


            // CÂU E
            Console.WriteLine(
                "\nCâu e - 5 môn có số tiết cao nhất:"
            );

            var top5 =
                from mon in danhSachMon
                join he in danhSachHe
                    on mon.He equals he.MaHe
                orderby mon.SoTiet descending
                select new
                {
                    TenHe = he.TenHe,
                    MaMon = mon.MaMon,
                    TenMon = mon.TenMon,
                    SoTiet = mon.SoTiet
                };

            foreach (var item in top5.Take(5))
            {
                Console.WriteLine(
                    $"{item.TenHe} | {item.MaMon} | " +
                    $"{item.TenMon} | {item.SoTiet} tiết"
                );
            }



            // CÂU F
            Console.WriteLine("\nCâu f - Đếm số môn theo hệ:");

            var demTheoHe =
                from he in danhSachHe
                join mon in danhSachMon
                    on he.MaHe equals mon.He into nhomMon
                select new
                {
                    TenHe = he.TenHe,
                    SoMon = nhomMon.Count()
                };

            foreach (var item in demTheoHe)
            {
                Console.WriteLine(
                    $"{item.TenHe}: {item.SoMon} môn"
                );
            }


            // CÂU G
            Console.WriteLine(
                "\nCâu g - Số lượng số tiết khác nhau:"
            );

            int soLuongSoTietKhacNhau = danhSachMon
                .Select(x => x.SoTiet)
                .Distinct()
                .Count();

            Console.WriteLine(
                "Có " + soLuongSoTietKhacNhau +
                " loại số tiết khác nhau."
            );


            // CÂU H

            Console.WriteLine(
                "\nCâu h - Môn đầu tiên có tên bắt đầu bằng 'Lập trình':"
            );

            var monDauTien = danhSachMon
                .FirstOrDefault(x => x.TenMon.StartsWith("Lập trình"));

            if (monDauTien != null)
            {
                Console.WriteLine(
                    $"{monDauTien.MaMon} | {monDauTien.TenMon}"
                );
            }


            // CÂU I
            Console.WriteLine(
                "\nCâu i - Đánh số thứ tự môn trong từng hệ:"
            );

            var nhomTheoHe = danhSachMon
                .GroupBy(x => x.He);

            foreach (var nhom in nhomTheoHe)
            {
                Console.WriteLine($"\nHệ [{nhom.Key}]");

                int stt = 1;

                foreach (var mon in nhom)
                {
                    Console.WriteLine(
                        $"{stt}. {mon.MaMon} | {mon.TenMon}"
                    );

                    stt++;
                }
            }
        }
    }
}