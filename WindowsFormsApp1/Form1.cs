using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double x = 0, r = 2;
        int round = 1; 
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Не введён X(по умолчанию 0)");
                textBox1.Text = Convert.ToString(0);
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Не введён радиус(по умолчанию 2)");
                textBox2.Text = Convert.ToString(2);
            }
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Не введён округление(по умолчанию 1)");
                textBox3.Text = Convert.ToString(1);
            }
            x = Convert.ToDouble(textBox1.Text);
            r = Convert.ToDouble(textBox2.Text);
            if (r > 2 || r <= 0)
            {
                MessageBox.Show("Не допустимые значения радуса");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            if (textBox3.Text == "")
            {
                round = 2;
            }
            else if (Convert.ToInt32(textBox3.Text) >= 16)
            {
                round = 15;
            }
            else
            {
                round = Convert.ToInt32(textBox3.Text);
            }
            if (x >= -10 && x <= -6)
            {
                textBox4.Text = Convert.ToString(Math.Round((Math.Sqrt(Math.Abs(r * r - (x - 8) * (x - 8)) + 2)), round));
            }
            else if (x > -6 && x <= -4)
            {
                textBox4.Text = Convert.ToString(2);
            }
            else if (x > -4 && x <= 2)
            {
                textBox4.Text = Convert.ToString(Math.Round((-x / 2), round));
            }
            else if (x > 2 && x <= 4)
            {
                textBox4.Text = Convert.ToString(Math.Round((x - 3), round));
            }
            else {
                MessageBox.Show("Не допустимые значения на данном промежутке");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void TextBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введите Х");
            toolTip1.IsBalloon = true;
        }

        private void TextBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "Введите R");
            toolTip1.IsBalloon = true;
        }

        private void TextBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введите точность");
            toolTip1.IsBalloon = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' && ch != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar == '-')
            {
                if (textBox1.Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                    return;
                }
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Знаходження функції на проміжку";

        }

    }
}
