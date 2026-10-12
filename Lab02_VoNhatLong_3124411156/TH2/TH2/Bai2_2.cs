using System;
using System.Collections.Generic;

namespace TH2
{
    public class PersonList
    {
        // Field luu tru danh sach cac Person
        private List<Person> danhSach;

        public int Count
        {
            get { return danhSach.Count; }
        }

        // Default constructor
        public PersonList()
        {
            danhSach = new List<Person>();
        }

        // Copy constructor
        public PersonList(PersonList other)
        {
            danhSach = new List<Person>();
            if (other != null && other.danhSach != null)
            {
                foreach (Person p in other.danhSach)
                {
                    // Sao chep tung doi tuong Person bang Copy Constructor cua Person
                    danhSach.Add(new Person(p));
                }
            }
        }

        // Add(Person x): Them mot Person vao trong PersonList
        public void Add(Person x)
        {
            if (x != null)
            {
                danhSach.Add(x);
            }
        }

        // Input(): Nhap cac du lieu cua PersonList
        public void Input()
        {
            int n = TienIch.DocSoNguyenDuong("Nhap so luong nguoi trong danh sach: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap thong tin nguoi thu {0}:", i + 1);
                Person p = new Person();
                p.Input();
                Add(p);
            }
        }

        // Output(): Xuat cac du lieu cua PersonList
        public void Output()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("(Danh sach trong)");
                return;
            }
            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, danhSach[i]);
            }
        }

        // LivingPeople(): Tra ve mot PersonList nhung nguoi con song
        public PersonList LivingPeople()
        {
            PersonList ketQua = new PersonList();
            foreach (Person p in danhSach)
            {
                if (p.IsLiving())
                {
                    ketQua.Add(new Person(p));
                }
            }
            return ketQua;
        }
    }

    /// <summary>
    /// Bai 2.2: Quan ly nhan khau voi lop PersonList
    /// </summary>
    public class Bai2_2
    {
        public static void Chay()
        {
            Console.WriteLine(" BAI 2.2: QUAN LY NHAN KHAU VOI LOP PERSONLIST ");

            PersonList danhSachTong = new PersonList();
            danhSachTong.Input();

            Console.WriteLine("\n DANH SACH TOAN BO NHAN KHAU ");
            danhSachTong.Output();

            Console.WriteLine("\n DANH SACH NHUNG NGUOI CON SONG (LivingPeople) ");
            PersonList danhSachSong = danhSachTong.LivingPeople();
            danhSachSong.Output();

            Console.WriteLine("\n KIEM TRA COPY CONSTRUCTOR CUA PERSONLIST ");
            PersonList danhSachSaoChep = new PersonList(danhSachTong);
            Console.WriteLine("So luong nguoi trong danh sach sao chep: {0}", danhSachSaoChep.Count);
        }
    }
}
