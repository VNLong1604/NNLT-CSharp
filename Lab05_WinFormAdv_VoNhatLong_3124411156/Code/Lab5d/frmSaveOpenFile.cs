using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab05
{
    /// <summary>
    /// 5d - Bài mẫu 3: Lưu / Mở file text bằng SaveFileDialog và OpenFileDialog.
    ///  - "Lưu file": ghi nội dung RichTextBox ra file *.txt, hiện đường dẫn lên TextBox.
    ///  - "Mở file": chọn file *.txt, hiện đường dẫn lên TextBox và nội dung lên RichTextBox.
    /// </summary>
    public class frmSaveOpenFile : Form
    {
        private RichTextBox richTextBox1;
        private TextBox textBox1;              // hiển thị đường dẫn file
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;

        public frmSaveOpenFile()
        {
            Text = "Save File Dialog";
            ClientSize = new Size(460, 340);

            UI.Lbl(this, "Nhập đoạn text", 15, 8, 200);

            richTextBox1 = new RichTextBox();     // Multiline mặc định = true
            richTextBox1.SetBounds(15, 35, 430, 240);
            Controls.Add(richTextBox1);

            textBox1 = UI.Txt(this, 15, 292, 220);
            textBox1.ReadOnly = true;
            UI.Btn(this, "Mở file", 245, 288, 95, btnMoFile_Click);
            UI.Btn(this, "Lưu file", 350, 288, 95, btnLuuFile_Click);

            // Khai báo và tạo thể hiện của lớp dialog (theo tài liệu)
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
        }

        // Lưu nội dung ra file .txt
        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                textBox1.Text = filename;
                try
                {
                    // using: tự động đóng file (Close) khi ghi xong, kể cả khi có lỗi
                    using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                    UI.Info("Đã lưu file thành công!");
                }
                catch (Exception ex)
                {
                    UI.Warn("Không lưu được file: " + ex.Message);
                }
            }
        }

        // Mở file .txt và hiển thị nội dung
        private void btnMoFile_Click(object sender, EventArgs e)
        {
            // Lọc loại đuôi file theo mong muốn
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // Nếu dialog chọn OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Gán đường dẫn lên Textbox
                textBox1.Text = openFileDialog1.FileName;
                try
                {
                    // Đọc dữ liệu từ file txt rồi gán vào richTextBox; using tự đóng luồng đọc
                    using (StreamReader f = new StreamReader(openFileDialog1.FileName, Encoding.UTF8))
                    {
                        richTextBox1.Text = f.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    UI.Warn("Không mở được file: " + ex.Message);
                }
            }
        }
    }
}
