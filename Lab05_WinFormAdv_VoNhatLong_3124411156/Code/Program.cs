using System;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>Điểm khởi động của chương trình: chạy form chính (MainForm) chứa menu gắn tất cả bài tập.</summary>
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
