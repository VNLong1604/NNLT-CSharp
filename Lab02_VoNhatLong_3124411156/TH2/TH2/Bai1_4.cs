using System;

namespace TH2
{

    public class Bai1_4
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 1.4: THIET KE LOP PHAN SO ");

            Console.WriteLine("\n 1. Kiem tra cac loai Constructor ");
            PhanSo psMacNghien = new PhanSo();
            Console.WriteLine("Constructor mac nhien: {0}", psMacNghien);

            PhanSo ps1ThamSo = new PhanSo(5);
            Console.WriteLine("Constructor 1 tham so (5): {0}", ps1ThamSo);

            PhanSo ps2ThamSo = new PhanSo(6, 8);
            Console.WriteLine("Constructor 2 tham so (6/8 da rut gon): {0}", ps2ThamSo);

            PhanSo psSaoChep = new PhanSo(ps2ThamSo);
            Console.WriteLine("Constructor sao chep tu (6/8): {0}", psSaoChep);

            Console.WriteLine("\n 2. Nhap 2 phan so de kiem tra toan tu ");
            Console.WriteLine("Nhap phan so thu nhat (ps1):");
            PhanSo ps1 = new PhanSo();
            ps1.Nhap();

            Console.WriteLine("Nhap phan so thu hai (ps2):");
            PhanSo ps2 = new PhanSo();
            ps2.Nhap();

            Console.WriteLine("\nPhan so 1 vua nhap: {0}", ps1);
            Console.WriteLine("Phan so 2 vua nhap: {0}", ps2);

            Console.WriteLine("\n 3. Overload toan tu mot ngoi (+, -) ");
            Console.WriteLine("+ps1 = {0}", +ps1);
            Console.WriteLine("-ps1 = {0}", -ps1);

            Console.WriteLine("\n 4. Overload toan tu hai ngoi (+, -, *, /) ");
            Console.WriteLine("{0} + {1} = {2}", ps1, ps2, ps1 + ps2);
            Console.WriteLine("{0} - {1} = {2}", ps1, ps2, ps1 - ps2);
            Console.WriteLine("{0} * {1} = {2}", ps1, ps2, ps1 * ps2);
            if (ps2.TuSo != 0)
            {
                Console.WriteLine("{0} / {1} = {2}", ps1, ps2, ps1 / ps2);
            }
            else
            {
                Console.WriteLine("Khong the chia cho ps2 vi tu so bang 0!");
            }

            Console.WriteLine("\n 5. Overload toan tu so sanh (>, <, >=, <=, ==, !=) ");
            Console.WriteLine("{0} > {1}  : {2}", ps1, ps2, ps1 > ps2);
            Console.WriteLine("{0} < {1}  : {2}", ps1, ps2, ps1 < ps2);
            Console.WriteLine("{0} >= {1} : {2}", ps1, ps2, ps1 >= ps2);
            Console.WriteLine("{0} <= {1} : {2}", ps1, ps2, ps1 <= ps2);
            Console.WriteLine("{0} == {1} : {2}", ps1, ps2, ps1 == ps2);
            Console.WriteLine("{0} != {1} : {2}", ps1, ps2, ps1 != ps2);
        }
    }
}
