using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();//створюєм рандом
        public int num1 = 0;//ініціалізуєм змінну цілого типу з назвою num1 і значенням 0
        public int num2 = 0;//ініціалізуєм змінну цілого типу з назвою num2 і значенням 0
        public int num3 = 0;//ініціалізуєм змінну цілого типу з назвою num3 і значенням 0

        string[] imen = {"Саша", "Паша", "Гріша",
      "Гєша", "Рома", "Фєдя", "Пєтя", "","","","","","","","","","","","","","","","","","","","" };//створюєм масив слів
        string[] die = {"грає", "думає про", "всім розповідає про",
      "хоче пограти", "говорить про ", "любить грати", "мотивує", "","","","","","","","","","","","","","","","","","","",""  };//створюєм масив слів
        string[] priymen = {"футбол", "баскетбол", "волейбол",
      "тетріс", "гандбол", "теніс", "великий теніс", "","","","","","","","","","","","","","","","","","","",""  };//створюєм масив слів

        private void Form1_Load(object sender, EventArgs e)//при завантаженні форми
        {
            this.Text = "Рандомайзер речень";//називаєм форму
        }

        private void button2_Click(object sender, EventArgs e)//при кліку на button2 викликаєм функцію
        {
            for (int i = 0; i < 1; i++)//створюєм цикл
            {
                label1.Text = ""; label2.Text = ""; label3.Text = "";//очищуєм текст
                label1.Text += imen[rnd.Next(0, num1 + 1)];//додаєм рандомний текст 
                label2.Text += die[rnd.Next(0, num2 + 1)];//додаєм рандомний текст
                label3.Text += priymen[rnd.Next(0, num3 + 1)];//додаєм рандомний текст
            }

        }

        private void button1_Click(object sender, EventArgs e)//при кліку на button1 викликаєм функцію
        {

            string name = textBox1.Text;//створюєм змінну name типу string якому призначаєм текст з textBox1
            for (int i = 0; i < imen.Length; i++)//створюєм цикл
            {
                if (imen[i] == "")//якшо значення масиву пустота 
                {
                    imen[i] = name;//то присваюєм значення змінної name
                    num1 = i;//змінній num1 присваюєм значення змінної і
                    break;//перериваєм цикл
                }
                
            }
            
        }
        private void button5_Click(object sender, EventArgs e)//при кліку на button5 викликаєм функцію
        {
            string dija = textBox2.Text;//створюєм змінну name типу string якому призначаєм текст з textBox2
            for (int i = 0; i < die.Length; i++)//створюєм цикл
            {
                if (die[i] == "")//якшо значення масиву пустота 
                {
                    die[i] = dija;//то присваюєм значення змінної dija
                    num2 = i;//змінній num2 присваюєм значення змінної і
                    break;//перериваєм цикл
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)//при кліку на button4 викликаєм функцію
        {
            string pri = textBox3.Text;//створюєм змінну name типу string якому призначаєм текст з textBox3
            for (int i = 0; i < priymen.Length; i++)//створюєм цикл
            {
                if (priymen[i] == "")//якшо значення масиву пустота 
                {
                    priymen[i] = pri;//то присваюєм значення змінної pri
                    num3 = i;//змінній num3 присваюєм значення змінної і
                    break;//перериваєм цикл
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)//при кліку на button3 викликаєм функцію
        {
            label1.Text = "";//очищуєм текст в label1
            label2.Text = "";//очищуєм текст в label2
            label3.Text = "";//очищуєм текст в label3
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введіть Іменник");
            toolTip1.IsBalloon = true;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "Введіть Дієслово");
            toolTip1.IsBalloon = true;
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введіть Прийменник");
            toolTip1.IsBalloon = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }
    }
}
