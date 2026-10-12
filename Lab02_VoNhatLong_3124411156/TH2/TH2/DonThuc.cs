using System;

namespace TH2
{
   
    public class DonThuc
    {
        // Field
        private double heSo;
        private int soMu;

        // Property
        public double HeSo
        {
            get { return heSo; }
            set { heSo = value; }
        }

        public int SoMu
        {
            get { return soMu; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("So mu phai la so nguyen khong am (>= 0)!");
                }
                soMu = value;
            }
        }

        // Default constructor
        public DonThuc()
        {
            heSo = 0;
            soMu = 0;
        }

        // Parameter constructor
        public DonThuc(double heSo, int soMu)
        {
            this.heSo = heSo;
            this.soMu = soMu >= 0 ? soMu : 0;
        }

        // Copy constructor
        public DonThuc(DonThuc other)
        {
            if (other != null)
            {
                this.heSo = other.heSo;
                this.soMu = other.soMu;
            }
        }

        // Nhap don thuc tu console
        public void Nhap()
        {
            heSo = TienIch.DocSoThuc("Nhap he so a: ");
            soMu = TienIch.DocSoNguyenKhongAm("Nhap so mu n (>= 0): ");
        }

        // Xuat don thuc
        public void Xuat()
        {
            Console.Write(ToString());
        }

        // (a) Tinh gia tri don thuc P(x) = a * x^n voi gia tri x cho truoc
        public double TinhGiaTri(double x)
        {
            return heSo * Math.Pow(x, soMu);
        }

        // (b) Dao ham don thuc P(x) = a * x^n -> P'(x) = a * n * x^(n - 1)
        public DonThuc DaoHam()
        {
            if (soMu == 0)
            {
                return new DonThuc(0, 0);
            }
            return new DonThuc(heSo * soMu, soMu - 1);
        }

        public override string ToString()
        {
            if (heSo == 0)
            {
                return "0";
            }
            if (soMu == 0)
            {
                return heSo.ToString();
            }
            if (soMu == 1)
            {
                return string.Format("{0}*x", heSo);
            }
            return string.Format("{0}*x^{1}", heSo, soMu);
        }
    }
}
