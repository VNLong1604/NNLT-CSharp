using System;

namespace TH2
{
    
    public class Bai1_3
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 1.3: DINH NGHIA LOP PERSON ");

            Console.WriteLine("\n 1. Khoi tao bang Default Constructor va nhap thong tin ");
            Person p1 = new Person();
            p1.Input();

            Console.WriteLine("\nThong tin nguoi thu nhat (p1):");
            p1.Output();
            Console.WriteLine("Kiem tra IsLiving(): {0} ({1})", 
                p1.IsLiving(), 
                p1.IsLiving() ? "Dang con song" : "Da mat");

            Console.WriteLine("\n 2. Khoi tao nguoi thu hai (p2) bang Copy Constructor tu p1 ");
            Person p2 = new Person(p1);
            Console.WriteLine("Thong tin p2 (duoc sao chep tu p1):");
            p2.Output();

            Console.WriteLine("\n 3. Khoi tao nguoi thu ba (p3) bang Parameter Constructor ");
            Person p3 = new Person("P003", "Nguyen Van An", 1990, 0);
            p3.Output();
            Console.WriteLine("Kiem tra p3 IsLiving(): {0}", p3.IsLiving());
        }
    }
}
