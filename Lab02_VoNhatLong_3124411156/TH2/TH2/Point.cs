using System;

namespace TH2
{
   
    public class Point
    {
        // Field
        private double x;
        private double y;

        // Property
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Default constructor khoi tao x = 0, y = 0
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        // Parameter constructor
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Copy constructor
        public Point(Point other)
        {
            if (other != null)
            {
                this.x = other.x;
                this.y = other.y;
            }
        }

        // Method Input de nhap toa do
        public void Input()
        {
            x = TienIch.DocSoThuc("Nhap hoanh do x: ");
            y = TienIch.DocSoThuc("Nhap tung do y: ");
        }

        // Method Output de xuat toa do
        public void Output()
        {
            Console.Write(ToString());
        }

        // Override ToString
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        // Phep toan 2 ngoi: +
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        // Phep toan 2 ngoi: -
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        // Phep toan 1 ngoi: lay am (-)
        public static Point operator -(Point a)
        {
            return new Point(-a.x, -a.y);
        }

        
    }
}
