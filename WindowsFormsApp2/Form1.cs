using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number!=8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int mnozhenya = 1, k = 0, rez1 = 0, rez2 = 0;//далі створбєм чотири змінних перша для того, щоб записувати добуток
                                                         //друга для того, щоб рахувати кількість позитивних елементів масиву
                                                         //rez1 i rez2 для того, щоб записувати в них 2 і 4 додатні елементи
            int size_array;
            if (textBox1.Text == "")
            {
                textBox1.Text = "5";
                size_array = System.Convert.ToInt32(textBox1.Text);
            }
            else
            {
                size_array = System.Convert.ToInt32(textBox1.Text);//конвертуєм розмір масиву в textBox1

            }
            int[] sorted_array = new int[size_array];//створюємо масив
            int max = sorted_array[0];//створюємо змінну max, в яку записуєм перший елемент масиву
            listBox1.Items.Add("");//Вставляємо пробіл
            listBox2.Items.Add("");//Вставляємо пробіл
            Random rand = new Random();//Створюємо рандом
            for (int counter = 0; counter < size_array; counter++)//створюєо цикл для перерахунку елементів масиву
            {
                sorted_array[counter] = rand.Next(-100, 101);//елементу масиву призначаєм значення рандому в межах від -100 до 101
                listBox1.Items.Add(Convert.ToString(sorted_array[counter] + "\n"));//і виводимо його в listBox1
            }



            for (int counter = 0; counter < size_array; counter++)//створюєо цикл для перерахунку елементів з довжиною масива
            {
                if (sorted_array[counter] < 0 && counter % 2 != 0)//якщо елемент масиву менший 0 і порядковий номер не є парним
                {
                    mnozhenya *= sorted_array[counter];//тоді перемножаєм елементи
                }
                if (sorted_array[counter] > 0)//якщо елемент масиву більший 0
                {
                    k++;//додаєм до змінної 1
                    if (k == 2) rez1 = counter + 1;//коли цей порядковий номер досягне двох то записуєм значення + 1 щрб користувач розумів
                    if (k == 4) rez2 = counter + 1;//коли цей порядковий номер досягне чотирьох то записуєм значення + 1 щрб користувач розумів
                }
                if (sorted_array[counter] % 2 != 0)//якщо елемент масиву не є парним
                {
                    if (sorted_array[counter] > max) max = sorted_array[counter];//і елемент масиву більший максимального то максимпльному призначається значення елементу масива 
                }

            }
            listBox2.Items.Add(Convert.ToString("dobutok = " + mnozhenya + "\n Elem 2 = " + rez1 + "\n Elem 4 = " + rez2 + "\n" + " max = " + max)); //виводим результат

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.Text = "Сортування масиву";//заголовок форми
            label1.Text = "Введіть розмірність масиву";//присваюєм текст label1'у 
            button1.Text = "Ввід";//присваюєм текст button1'у 
        }

        private void textBox1_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введіть розмірність масиву");
            toolTip1.IsBalloon = true;
        }
    }
}
