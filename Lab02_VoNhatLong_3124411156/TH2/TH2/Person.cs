using System;

namespace TH2
{
    
    public class Person
    {
        // Du lieu thanh vien
        private string id;
        private string name;
        private int yob; // Nam sinh
        private int yod; // Nam mat (0 neu con song)

        // Property
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Yob
        {
            get { return yob; }
            set { yob = value; }
        }

        public int Yod
        {
            get { return yod; }
            set { yod = value; }
        }

        // Default Constructor
        public Person()
        {
            id = string.Empty;
            name = string.Empty;
            yob = 0;
            yod = 0;
        }

        // Parameter Constructor
        public Person(string id, string name, int yob, int yod)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // Copy Constructor
        public Person(Person other)
        {
            if (other != null)
            {
                this.id = other.id;
                this.name = other.name;
                this.yob = other.yob;
                this.yod = other.yod;
            }
        }

        // Nhap thong tin Person
        public void Input()
        {
            id = TienIch.DocChuoi("Nhap ID: ");
            name = TienIch.DocChuoi("Nhap ho ten: ");
            yob = TienIch.DocSoNguyenDuong("Nhap nam sinh (yob): ");
            while (true)
            {
                yod = TienIch.DocSoNguyenKhongAm("Nhap nam mat (yod, nhap 0 neu con song): ");
                if (yod == 0 || yod >= yob)
                {
                    break;
                }
                Console.WriteLine("Loi: Nam mat phai lon hon hoac bang nam sinh!");
            }
        }

        // Xuat thong tin Person
        public void Output()
        {
            Console.WriteLine(ToString());
        }

        // Kiem tra con song hay khong: true neu yod == 0, false neu yod != 0
        public bool IsLiving()
        {
            return yod == 0;
        }

        public override string ToString()
        {
            string trangThai = IsLiving() ? "Con song" : ("Da mat nam " + yod);
            return string.Format("ID: {0} | Ho ten: {1} | Nam sinh: {2} | Trang thai: {3}", id, name, yob, trangThai);
        }
    }
}
