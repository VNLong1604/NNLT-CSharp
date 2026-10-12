using System;

namespace TH2
{
  
    public class PhanSo
    {
        // Field
        private int tuSo;
        private int mauSo;

        // Property
        public int TuSo
        {
            get { return tuSo; }
            set { tuSo = value; }
        }

        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Mau so khong the bang 0!");
                }
                mauSo = value;
            }
        }

        // Constructor mac nhien: 0/1
        public PhanSo()
        {
            this.tuSo = 0;
            this.mauSo = 1;
        }

        // Constructor 1 tham so (tuSo / 1)
        public PhanSo(int tuSo)
        {
            this.tuSo = tuSo;
            this.mauSo = 1;
        }

        // Constructor 2 tham so (tuSo / mauSo)
        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mau so khong the bang 0!");
            }
            this.tuSo = tuSo;
            this.mauSo = mauSo;
            ChuanHoaDauVaRutGon();
        }

        // Constructor sao chep (Copy constructor)
        public PhanSo(PhanSo other)
        {
            if (other != null)
            {
                this.tuSo = other.tuSo;
                this.mauSo = other.mauSo;
            }
            else
            {
                this.tuSo = 0;
                this.mauSo = 1;
            }
        }

        // Uoc so chung lon nhat
        private static int USCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        // Chuan hoa dau va rut gon
        public void ChuanHoaDauVaRutGon()
        {
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
            int ucln = USCLN(tuSo, mauSo);
            if (ucln > 1)
            {
                tuSo /= ucln;
                mauSo /= ucln;
            }
        }

        // Nhap phan so tu ban phim
        public void Nhap()
        {
            tuSo = TienIch.DocSoNguyen("Nhap tu so: ");
            while (true)
            {
                mauSo = TienIch.DocSoNguyen("Nhap mau so (khac 0): ");
                if (mauSo != 0)
                {
                    break;
                }
                Console.WriteLine("Loi: Mau so phai khac 0!");
            }
            ChuanHoaDauVaRutGon();
        }

        // Xuat phan so
        public void Xuat()
        {
            Console.Write(ToString());
        }

        // Override ToString()
        public override string ToString()
        {
            if (mauSo == 1)
            {
                return tuSo.ToString();
            }
            if (tuSo == 0)
            {
                return "0";
            }
            return string.Format("{0}/{1}", tuSo, mauSo);
        }

        
    }
}
