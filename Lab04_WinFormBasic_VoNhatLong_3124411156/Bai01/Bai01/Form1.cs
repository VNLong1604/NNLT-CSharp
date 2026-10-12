using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class From1 : Form
    {
        // Số thứ nhất
        double firstNumber = 0;

        // Phép tính đang chọn
        string operation = "";

        // Kiểm tra có đang nhập số mới không
        bool isNewNumber = true;

        public From1()
        {
            InitializeComponent();

            // Giá trị ban đầu của máy tính
            txtDisplay.Text = "0";
        }


        // XỬ LÝ CÁC NÚT SỐ 0 - 9
        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Nếu đang bắt đầu nhập số mới
            if (isNewNumber || txtDisplay.Text == "0")
            {
                txtDisplay.Text = button.Text;

                isNewNumber = false;
            }
            else
            {
                // Thêm số vào phía sau
                txtDisplay.Text += button.Text;
            }
        }


        // XỬ LÝ CÁC PHÉP TÍNH
        // + - × ÷
        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            firstNumber = double.Parse(txtDisplay.Text);

            operation = button.Text;

            isNewNumber = true;
        }


        // NÚT =
        private void btnEqual_Click(object sender, EventArgs e)
        {
            // Lấy số thứ hai
            double secondNumber = double.Parse(txtDisplay.Text);

            double result = 0;

            // Kiểm tra phép tính
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "x":
                    result = firstNumber * secondNumber;
                    break;

                case "%":

                    // Không cho chia cho 0
                    if (secondNumber == 0)
                    {
                        MessageBox.Show(
                            "Không thể chia cho 0!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            // Hiển thị kết quả
            txtDisplay.Text = result.ToString();

            // Lần nhập tiếp theo là số mới
            isNewNumber = true;
        }


        // NÚT XÓA
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";

            firstNumber = 0;

            operation = "";

            isNewNumber = true;
        }


        // NÚT BACKSPACE - XÓA 1 SỐ
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(
                    0,
                    txtDisplay.Text.Length - 1
                );
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void From1_Load(object sender, EventArgs e)
        {

        }
    }
}
