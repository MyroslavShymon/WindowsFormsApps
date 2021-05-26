using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int countOFMin = 0;//  створюєм змінну для підрпахунку відємних значень
            double[] P = new double[32];//створюємо масив на 32 елементи
            listBox1.Items.Add("");//Вставляємо пробіл
            for (int counter = 0; counter < 32; counter++)//створюєо цикл для перерахунку елементів масиву
            {
                P[counter] = (Math.Log(counter) * Math.Log(counter) - 3.85) / (0.7 * counter + 3.85);//обчислєм значення функції за формулою
                if (P[counter] < 0)//робим умову якщо елемент меньший 0
                {
                    listBox1.Items.Add(Convert.ToString(P[counter] + "\n"));//і виводимо його в listBox1
                    countOFMin++;//додаєм + 1 при кожній вірній умові
                }
                else//в інакшому випадку
                {
                    listBox1.Items.Add(Convert.ToString("Для додатніх не обчислюєм " + "\n"));//виводим в listBox1 для додатніх не обчислюєм
                }
            }
            listBox1.Items.Add(Convert.ToString("Кількість від'ємних = " + countOFMin + "\n"));//виводим в listBox1 кількість від'ємних
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Обрахунок масиву";//заголовок форми
            button1.Text = "Рахуєм!!!";//присваюєм текст button1'у 
        }
    }
}
