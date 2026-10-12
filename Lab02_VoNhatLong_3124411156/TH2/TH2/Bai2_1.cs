using System;
using System.Collections;

namespace TH2
{
    /// <summary>
    /// Lop ArrayPoint dung de luu tru cac doi tuong Point
    /// - Field: Mot ArrayList cac Point
    /// - Indexer: Cho phep truy cap Point thu i cua ArrayList
    /// </summary>
    public class ArrayPoint
    {
        // Field: Mot ArrayList cac Point theo dung yeu cau de bai
        private ArrayList danhSach;

        // Property lay so luong diem
        public int Count
        {
            get { return danhSach.Count; }
        }

        // Constructor
        public ArrayPoint()
        {
            danhSach = new ArrayList();
        }

        // Them mot Point vao danh sach
        public void Add(Point p)
        {
            if (p != null)
            {
                danhSach.Add(p);
            }
        }

        // Indexer cho phep truy cap Point thu i cua ArrayList
        public Point this[int index]
        {
            get
            {
                if (index < 0 || index >= danhSach.Count)
                {
                    throw new IndexOutOfRangeException("Chi so index vuot qua pham vi danh sach!");
                }
                return (Point)danhSach[index];
            }
            set
            {
                if (index < 0 || index >= danhSach.Count)
                {
                    throw new IndexOutOfRangeException("Chi so index vuot qua pham vi danh sach!");
                }
                danhSach[index] = value;
            }
        }

        // Nhap danh sach diem
        public void Nhap()
        {
            int n = TienIch.DocSoNguyenDuong("Nhap so luong diem: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap toa do diem thu {0}:", i + 1);
                Point p = new Point();
                p.Input();
                Add(p);
            }
        }

        // Xuat danh sach diem
        public void Xuat()
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.WriteLine("Diem [{0}]: {1}", i, this[i]);
            }
        }
    }

    /// <summary>
    /// Bai 2.1: Thiet ke lop ArrayPoint
    /// </summary>
    public class Bai2_1
    {
        public static void Chay()
        {
            Console.WriteLine("=== BAI 2.1: THIET KE LOP ARRAYPOINT ===");

            ArrayPoint arr = new ArrayPoint();
            arr.Nhap();

            Console.WriteLine("\n--- Danh sach cac diem da nhap ---");
            arr.Xuat();

            if (arr.Count > 0)
            {
                Console.WriteLine("\n--- Kiem tra Indexer ---");
                int idx = TienIch.DocSoNguyenKhongAm(string.Format("Nhap chi so i muon xem (0 den {0}): ", arr.Count - 1));
                if (idx < arr.Count)
                {
                    Console.WriteLine("Diem tai vi tri [{0}] la: {1}", idx, arr[idx]);

                    Console.WriteLine("\nCap nhat diem tai vi tri [{0}] bang Indexer:", idx);
                    Point diemMoi = new Point();
                    diemMoi.Input();
                    arr[idx] = diemMoi;

                    Console.WriteLine("\nDanh sach diem sau khi cap nhat:");
                    arr.Xuat();
                }
                else
                {
                    Console.WriteLine("Chi so vuot qua pham vi!");
                }
            }
        }
    }
}
