using System;
using System.Text;

namespace TH2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            

            Console.Write("Chon bai can chay : ");
            string luaChon = Console.ReadLine();
            if (luaChon != null)
            {
                luaChon = luaChon.Trim().ToLower();
            }

            
            switch (luaChon)
            {
                case "1":
                case "1.1":
                case "bai1_1":
                    Bai1_1.Chay();
                    break;

                case "2":
                case "1.2":
                case "bai1_2":
                    Bai1_2.Chay();
                    break;

                case "3":
                case "1.3":
                case "bai1_3":
                    Bai1_3.Chay();
                    break;

                case "4":
                case "1.4":
                case "bai1_4":
                    Bai1_4.Chay();
                    break;

                case "5":
                case "1.5":
                case "bai1_5":
                    Bai1_5.Chay();
                    break;

                case "6":
                case "2.1":
                case "bai2_1":
                    Bai2_1.Chay();
                    break;

                case "7":
                case "2.2":
                case "bai2_2":
                    Bai2_2.Chay();
                    break;

                case "8":
                case "2.3a":
                case "2.3.1":
                case "bai2_3_mang1chieu":
                    Bai2_3_Mang1Chieu.Chay();
                    break;

                case "9":
                case "2.4a":
                case "2.4.1":
                case "bai2_4_mang2chieu":
                    Bai2_4_Mang2Chieu.Chay();
                    break;

                case "10":
                case "2.3b":
                case "2.3.2":
                case "bai2_3_dathuc":
                    Bai2_3_DaThuc.Chay();
                    break;

                case "11":
                case "2.4b":
                case "2.4.2":
                case "bai2_4_dayphanso":
                    Bai2_4_DayPhanSo.Chay();
                    break;

                case "12":
                case "2.5":
                case "bai2_5":
                    Bai2_5.Chay();
                    break;

                case "13":
                case "3.1":
                case "bai3_1":
                    Bai3_1.Chay();
                    break;

                case "14":
                case "3.2":
                case "bai3_2":
                    Bai3_2.Chay();
                    break;

                case "15":
                case "3.3":
                case "bai3_3":
                    Bai3_3.Chay();
                    break;

                case "16":
                case "3.4":
                case "bai3_4":
                    Bai3_4.Chay();
                    break;

                case "17":
                case "3.5":
                case "bai3_5":
                    Bai3_5.Chay();
                    break;

                case "18":
                case "3.6":
                case "bai3_6":
                    Bai3_6.Chay();
                    break;

                default:
                    Console.WriteLine("Loi: Lua chon khong hop le!");
                    break;
            }

            
            Console.WriteLine("Nhan Enter de ket thuc chuong trinh...");
            Console.ReadLine();
        }
    }
}
