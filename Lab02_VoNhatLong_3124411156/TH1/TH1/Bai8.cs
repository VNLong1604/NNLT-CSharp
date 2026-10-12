using System;

namespace TH1
{
    // Bài 8: tham chiếu ref - hoán vị hai số thực
    class Bai8
    {
        public static void HoanVi(ref double a, ref double b)
        {
            double tam = a;
            a = b;
            b = tam;
        }

        public static void Chay()
        {
            double a = TienIch.DocSoThucLap("a");
            double b = TienIch.DocSoThucLap("b");

            Console.WriteLine("Truoc khi hoan vi: a = " + a + ", b = " + b);
            HoanVi(ref a, ref b);
            Console.WriteLine("Sau khi hoan vi:   a = " + a + ", b = " + b);
        }
    }
}
