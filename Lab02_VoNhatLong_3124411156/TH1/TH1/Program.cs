using System;
using System.Text;

namespace TH1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Để nhập/xuất được tiếng Việt có dấu
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Chon bai can chay (1, 3 den 17): ");
            string chon = Console.ReadLine();
            Console.WriteLine();

            switch (chon)
            {
                case "1": Bai1.Chay(); break;
                case "3": Bai3.Chay(); break;
                case "4": Bai4.Chay(); break;
                case "5": Bai5.Chay(); break;
                case "6": Bai6.Chay(); break;
                case "7": Bai7.Chay(); break;
                case "8": Bai8.Chay(); break;
                case "9": Bai9.Chay(); break;
                case "10": Bai10.Chay(); break;
                case "11": Bai11.Chay(); break;
                case "12": Bai12.Chay(); break;
                case "13": Bai13.Chay(); break;
                case "14": Bai14.Chay(); break;
                case "15": Bai15.Chay(); break;
                case "16": Bai16.Chay(); break;
                case "17": Bai17.Chay(); break;
                default: Console.WriteLine("Khong co bai nay!"); break;
            }

            Console.ReadLine(); 
        }
    }
}
