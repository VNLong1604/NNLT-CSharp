using System;
using System.Linq;
using BaiThucHanhLINQ.Data;

namespace BaiThucHanhLINQ.Exercises
{
    public static class Bai41
    {
        public static void Run()
        {
            var danhSachMon = DuLieu.DS_Mon();

            Console.WriteLine("===== BÀI 4.1 =====");

            foreach (var mon in danhSachMon)
            {
                Console.WriteLine(
                    $"{mon.MaMon} | {mon.TenMon} | {mon.He} | {mon.SoTiet} tiết"
                );
            }
        }
    }
}