using System;

namespace TH1
{
    // Bài 9: tham chiếu out - tìm giá trị lớn nhất và nhỏ nhất của ba số thực
    class Bai9
    {
        public static void MaxMin(double a, double b, double c, out double max, out double min)
        {
            max = a;
            min = a;
            if (b > max) max = b;
            if (c > max) max = c;
            if (b < min) min = b;
            if (c < min) min = c;
        }

        public static void Chay()
        {
            double a = TienIch.DocSoThucLap("a");
            double b = TienIch.DocSoThucLap("b");
            double c = TienIch.DocSoThucLap("c");

            double max, min;
            MaxMin(a, b, c, out max, out min);

            Console.WriteLine("Gia tri lon nhat: " + max);
            Console.WriteLine("Gia tri nho nhat: " + min);
        }
    }
}
