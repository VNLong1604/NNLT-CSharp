using System;

namespace TH2
{
   
    public class Bai1_2
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 1.2: THIET KE LOP POINT ");

            Console.WriteLine("\n Nhap diem A ");
            Point A = new Point();
            A.Input();

            Console.WriteLine("\n Nhap diem B ");
            Point B = new Point();
            B.Input();

            Console.WriteLine("\n Xuat toa do 2 diem (su dung ToString va Output) ");
            Console.Write("Diem A (Output): ");
            A.Output();
            Console.WriteLine();
            Console.WriteLine("Diem B (ToString): {0}", B);

            Console.WriteLine("\n Kiem tra cac phep toan nạp chong ");
            Point tong = A + B;
            Console.WriteLine("A + B = {0}", tong);

            Point hieu = A - B;
            Console.WriteLine("A - B = {0}", hieu);

            Point amA = -A;
            Console.WriteLine("Lay am diem A (-A) = {0}", amA);

            Point amB = -B;
            Console.WriteLine("Lay am diem B (-B) = {0}", amB);

            Console.WriteLine("\n (a) Khoang cach giua 2 diem A va B theo 2 cach ");
            double kcThanhVien = A.KhoangCach(B);
            Console.WriteLine("Cach 1 (Phuong thuc thanh vien A.KhoangCach(B)): {0:F4}", kcThanhVien);

            double kcTinh = Point.KhoangCach(A, B);
            Console.WriteLine("Cach 2 (Phuong thuc tinh Point.KhoangCach(A, B)): {0:F4}", kcTinh);

            Console.WriteLine("\n (b) Trung diem I cua 2 diem A va B theo 2 cach ");
            Point iThanhVien = A.TrungDiem(B);
            Console.WriteLine("Cach 1 (Phuong thuc thanh vien A.TrungDiem(B)): {0}", iThanhVien);

            Point iTinh = Point.TrungDiem(A, B);
            Console.WriteLine("Cach 2 (Phuong thuc tinh Point.TrungDiem(A, B)): {0}", iTinh);
        }
    }
}
