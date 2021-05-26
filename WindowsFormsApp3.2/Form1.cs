using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click_1(object sender, EventArgs e)//викликаєм функцію при кліку на Button1
        {
            textBox1.Text = "";
            textBox1.ReadOnly = true;
            int raw, col;
            if (textBox2.Text == "")
            {
                textBox2.Text = "5";
                raw = Convert.ToInt32(textBox2.Text);//конвертуєм значення з textBox2 для того щоб знати кількість рядків
            }
            else
            {
                raw = Convert.ToInt32(textBox2.Text);//конвертуєм значення з textBox2 для того щоб знати кількість рядків
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "5";
                col = Convert.ToInt32(textBox3.Text);//конвертуєм значення з textBox3 для того щоб знати кількість стовбців
            }
            else
            {
                col = Convert.ToInt32(textBox3.Text);//конвертуєм значення з textBox3 для того щоб знати кількість стовбців
            }
            if (raw >= 28) {
                textBox2.Text = "28";
                MessageBox.Show("Максимально допустиме значення 28 ",
        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                raw = 28;
            }
            if (col >= 28)
            {
                textBox3.Text = "28";
                MessageBox.Show("Максимально допустиме значення 28 ",
        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                col = 28;
            }

            double[,] a = new double[raw, col];//створюєм двохвимірний масив з введения рядків і стовбців
            int i, j;//створюєм допоміжні цикли для змінних
            double dobutok = 1;//створюєм змінну для обчислення добутку
            for (i = 0; i < raw; i++)//створюєо цикл для перерахунку елементів масиву рядків
            {
                for (j = 0; j < col; j++)//створюєо цикл для перерахунку елементів масиву ствобців
                {
                    a[i, j] = i * j;//рахуєм
                    if (a[i, j] >= 2 && a[i, j] <= 10)//якшо елемент більший або рівний 2 і менший або рівний 10
                    {
                        dobutok *= a[i, j];//обчислюєм добуток
                    }
                    textBox1.AppendText(Convert.ToString(a[i, j]) + "\t");//ввиводим масив
                }
                textBox1.Text += "\r\n" + "\r\n";//ввиводим масив
            }
            textBox1.AppendText("Добуток едементів які більші 2 і менше 10 = " + Convert.ToString(dobutok));//виводиим в кінці добуток едементів які більші 2 і менше 10
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
