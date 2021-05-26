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
using System.Diagnostics;

namespace Task_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)//створюєм функцію
        {
            disable();
            textBox1.KeyPress += KeyPressWords;//при набиранні клавіш в textBox1 
            textBox6.KeyPress += KeyPressWords;//при набиранні клавіш в textBox6 
            textBox7.KeyPress += KeyPressWords;//при набиранні клавіш в textBox7 
            textBox8.KeyPress += KeyPressWords;//при набиранні клавіш в textBox8 
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

        struct info
        {
            public string tovar, krayina, virobnik, tsina;//створюєм структуру на 4 значення типу string
        };

        info[] arr = new info[100];//робим його розміром на 100 елементів
        public bool is_changed = false;//створюєм глобальну змінну булевого значення is_changed яка рівна false
        public bool is_new = false;//створюєм глобальну змінну булевого значення is_new яка рівна false
        public string path;//створюєм глобальну змінну типу строка path

        private void ПрочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)//при кліку читаєм з файлу
        {
            dataGridView1.Rows.Clear();//очищуєм

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//відкривайє файловий провідник
            {
                if (openFileDialog1.FileName == null)//якшо не відкрили
                    return;//то повертаєм

                BinaryReader br = new BinaryReader(new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate));//створюєм змінну для легшої роботи з бінарними файлами

                path = openFileDialog1.FileName;//імя файла записуєм в змінну path
                int count = dataGridView1.Rows.Count;//створюєм змінну цілогочисленлтного типу для підрахунку рядків

                while (br.BaseStream.Position != br.BaseStream.Length)//створюєм цикл для перерахунку
                {
                    dataGridView1.Rows.Add();//добавляєм рядки

                    for (int i = 0; i < 4; i++)//цикл створюєм для чотирьох стовбців
                        dataGridView1.Rows[count].Cells[i].Value = br.ReadString();//читаєм рядки
                    count++;//плюсуєм + 1 
                }

                br.Close();//закриваєм змінну бінарного файлу

                for (int i = 0; i < count; i++)//створюєм цикли
                {
                    arr[i].tovar = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);//конвертуєм tovar
                    arr[i].krayina = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);//конвертуєм krayina
                    arr[i].virobnik = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);//конвертуєм virobnik
                    arr[i].tsina = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);//конвертуєм tsina
                }

                if (count == 0)//якшо змінна count = 0
                {
                    MessageBox.Show("В даному файлі немає жодного запису!\n ",//то ми виводим в MessageBox текст "В даному файлі немає жодного запису!\n "
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);//тип MessageBox
                }
                else//в інакшому випадку
                {
                    enable();//активуєм
                    updateComboBox();//обновляєм
                    comboBox1.SelectedIndex = 0;//обраний індекс = 0
                    updateTextBox(0);//обновляєм TextBox
                    MessageBox.Show("Файл завантажено!\n " +
                        "Кількість зчитаних записів: " + count, "", MessageBoxButtons.OK, MessageBoxIcon.Information);//виводим повідомлення в меседж бокс
                }
            }
        }
        private void ЗаписатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)// при кліку на Записати У Файл викликаєм функцію Save();
        {
            Save();//викликаєм функцію Save();

        }

        private void Button2_Click(object sender, EventArgs e)//при кліку на Button2
        {
            string str = textBox1.Text;//створюєм змінну зі значення строки string
            string str2 = textBox2.Text;//створюєм змінну зі значення строки string
            string str3 = textBox3.Text;//створюєм змінну зі значення строки string
            textBox1.Text = "";//присвоюєм значення пустогго рялка
            textBox2.Text = "";
            textBox3.Text = "";
            if (str != "" || str2 != "" || str3 != "")//якшо не пустий
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)//то цикл по всіх значеннях рядка
                    if (str == arr[i].tovar && str2 == arr[i].krayina && str3 == arr[i].virobnik)//якшо строка рівна рівна товару
                    {
                        updateTextBox(i);//
                        MessageBox.Show("Товар з назвою: " + str + " знайдено", "",//виводим в MessageBox Запис з прізвищем: імя знайдено
                            MessageBoxButtons.OK, MessageBoxIcon.Information);//налаштовуєм MessageBox
                        return;//повертаєм 
                    }
                MessageBox.Show("Не знайдено жодного товару з назвою: " + str, "",//виводим в MessageBox Не знайдено жодного запису з прізвищем: імя 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);//налаштовуєм MessageBox
            }
            else MessageBox.Show("Ви не ввели жодного найменування товару\nВведіть найменування товару",//виводим в MessageBox Ви не ввели жодного прізвища\nВведіть прізвище та спробуйте ще раз
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);//налаштовуєм MessageBox
        }
        //для очищення функія
        private void Button3_Click(object sender, EventArgs e)//при кліку на Button3
        {
            int count = dataGridView1.Rows.Count;//ініціалізуєм змінну зі значення кількості рядків 
            int index = comboBox1.SelectedIndex;//змінна обраний інлекс

            arr[index].tovar = null;//присваюєм значення 0
            arr[index].krayina = null;//присваюєм значення 0
            arr[index].virobnik = null;//присваюєм значення 0
            arr[index].tsina = null;//присваюєм значення 0
            count--;//count - 1 

            dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);//видаляєм

            for (int i = index; i < count; i++)//оголошуєм цико
            {
                arr[i].tovar = arr[i + 1].tovar;//номер в масиві + 1 
                arr[i].krayina = arr[i + 1].krayina;//номер в масиві + 1 
                arr[i].virobnik = arr[i + 1].virobnik;//номер в масиві + 1 
                arr[i].tsina = arr[i + 1].tsina;//номер в масиві + 1 
            }
            updateDataGrid();//обновляєм
            if //якшо
                (index == count) comboBox1.SelectedIndex = count - 1;//якшо index = count то
            else//в ігакшомцу вирадку
                comboBox1.SelectedIndex = index;//вибраниий номор в comboBox1 доріньє index
            is_changed = true;//змінна is_changed = true

            if (dataGridView1.Rows.Count == 0)//якшо кількість = 0 
            {
                comboBox1.Text = "";//текст в comboBox1 = пустота
                updateTextBox(0);//визиваєм функцію і передаєм 0
                disable();//визиваєм фкнкцію
                MessageBox.Show("Усі записи вилучено!\n"+" Збереження порожнього файлу є безглуздим тому," +
                    " якщо бажаєте зберегти записи або знову розпочати редагування, додайте нові записи або завантажте файл",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);//видаєм поввдомлення
                is_changed = false;//змінна is_changed = false
            }
        }

        private void ВідАдоЯToolStripMenuItem_Click(object sender, EventArgs e)//функція яка викликається при кліку на MenuItem з назвою ВідАдоЯ
        {
            info temp;
            int count = dataGridView1.Rows.Count;
            //сортування бульбашкою
            for (int i = 0; i < count; i++)//створюєм цикл
            {
                for (int j = i + 1; j < count; j++)//створюєм цикл 
                {
                    if (string.Compare(arr[i].tovar, arr[j].tovar) > 0)//яккшо порівнбване більше 0
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    updateDataGrid();//викликаєм функцію
                }
            }
        }
        private void ВідЯдоАToolStripMenuItem_Click(object sender, EventArgs e)//функція яка викликається при кліку на MenuItem з назвою ВідЯдоА
        {
            info temp;
            int count = dataGridView1.Rows.Count;
            //сортування бульбашкою
            for (int i = 0; i < count; i++)//створюєм
            {
                for (int j = i + 1; j < count; j++)//створюєм
                {
                    if (string.Compare(arr[i].tovar, arr[j].tovar) < 0)//яккшо порівнбване меньше 0
                    {
                        temp = arr[i];//
                        arr[i] = arr[j];//
                        arr[j] = temp;//
                    }
                    updateDataGrid();//викликаєм функцію
                }
            }
        }
        private void updateComboBox()//функція для обновлювання ComboBox
        {
            int count = dataGridView1.Rows.Count;
            int index = comboBox1.SelectedIndex;
            this.comboBox1.Items.Clear();

            for (int i = 0; i < count; i++)
                comboBox1.Items.Add(dataGridView1.Rows[i].Cells[0].Value);

            if (index == dataGridView1.Rows.Count)
            {
                return;
            }
            else
                comboBox1.SelectedIndex = index;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTextBox(comboBox1.SelectedIndex);
        }
        private void updateTextBox(int i)//функція для обнови TextBox
        {
            int count = dataGridView1.Rows.Count;
            if (i < count && i >= 0)
            {
                comboBox1.SelectedIndex = i;
                textBox6.Text = arr[i].tovar;
                textBox7.Text = arr[i].krayina;
                textBox8.Text = arr[i].virobnik;
                textBox9.Text = arr[i].tsina;
            }
            else
            {
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
        }
        private void updateDataGrid()////функція для обнови dataGridView1
        {
            int count = dataGridView1.Rows.Count;

            dataGridView1.Rows.Clear();
            if (count != 0)
                dataGridView1.Rows.Add(count);

            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = arr[i].tovar;
                dataGridView1.Rows[i].Cells[1].Value = arr[i].krayina;
                dataGridView1.Rows[i].Cells[2].Value = arr[i].virobnik;
                dataGridView1.Rows[i].Cells[3].Value = arr[i].tsina;
            }
            updateComboBox();
        }
        private void enable()//функція яка робить елемети активними
        {
            редагуватиToolStripMenuItem.Enabled = true;
            записатиУФайлToolStripMenuItem.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }
        private void disable()//функція яка робить елемети не активними
        {
            записатиУФайлToolStripMenuItem.Enabled = false;
            редагуватиToolStripMenuItem.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void Save()//функція зберігання в бінарний файл
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == null)
                    return;

                BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create));

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                    bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                    bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value));
                    bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                }

                bw.Close();
            }
        }
        private void ЗберегтиЗміниУСпискуЗаписівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_changed)
            {
                saveChanges();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseForm() == false)
                e.Cancel = true;
        }
        private bool CloseForm()
        {
            var result = MessageBox.Show("Ви дійсно бажаєте завершити роботу програми?",
                    "Підтвердження виходу", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (is_changed)
                    saveChanges();

                return true;
            }
            else
                return false;
        }
        private void saveChanges()
        {
            var result = MessageBox.Show("Деякі записи були відредаговані або видалені, зберегти зміни у файл?",//
                "Зберегти зміни?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//
            if (is_new)
            {
                if (DialogResult.Yes == result)
                    Save();
            }
            else
            {
                if (DialogResult.Yes == result)
                {
                    File.Delete(path);
                    BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                        bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                        bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value));
                        bw.Write(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                    }

                    bw.Close();

                    is_changed = false;
                }
            }
                
        }
        private void KeyPressWords(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')
            {
                e.Handled = true;
            }
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e){}
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e) { }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e) { }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e) { }
        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e) { }
        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e) { }
        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e) {
            //char ch = e.KeyChar;
            //if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == '.')
            //{
            //    e.KeyChar = ',';
            //    if (textBox1.Text.IndexOf(',') != -1)
            //    {
            //        e.Handled = true;
            //        return;
            //    }
            //}
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e) { }

        private void КінецьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        double suma = 0; int k = 0;
        double serednya_tsina = 0;
        private void button5_Click_1(object sender, EventArgs e)
        {
            
            if (textBox6.Text.Length > 0 && textBox7.Text.Length > 0 &&//якшо розмір текста
                 textBox8.Text.Length > 0 && textBox9.Text.Length > 0)//
            {
                int count = dataGridView1.Rows.Count;//

                dataGridView1.Rows.Add();//

                dataGridView1.Rows[count].Cells[0].Value = textBox6.Text;//
                dataGridView1.Rows[count].Cells[1].Value = textBox7.Text;//
                dataGridView1.Rows[count].Cells[2].Value = textBox8.Text;//
                dataGridView1.Rows[count].Cells[3].Value = textBox9.Text;//
                count++;//

                arr[count - 1].tovar = Convert.ToString(dataGridView1.Rows[count - 1].Cells[0].Value);//
                arr[count - 1].krayina = Convert.ToString(dataGridView1.Rows[count - 1].Cells[1].Value);//
                arr[count - 1].virobnik = Convert.ToString(dataGridView1.Rows[count - 1].Cells[2].Value);//
                arr[count - 1].tsina = Convert.ToString(dataGridView1.Rows[count - 1].Cells[3].Value);//

                updateComboBox();//
                updateTextBox(0);//
                MessageBox.Show("Запис успішно доданий!",//
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);//
                enable();//

                textBox6.Text = "";//
                textBox7.Text = "";//
                textBox8.Text = "";//
                textBox9.Text = "";//

                if (count - 1 == 0)//
                    is_new = true;//

                is_changed = true;//
                for (int i = 0; i <= count; i++)
                {
                    suma += Convert.ToDouble(arr[i].tsina);
                }
                serednya_tsina = suma / count;
                
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToDouble(arr[i].tsina) > serednya_tsina)
                    {
                        k++;
                    }
                }
                label3.Text = "Кількість товарів з цінною вищою середньої " + k;
            }
            else//в інакшому випадку
                MessageBox.Show("Перевірте чи заповнені та спробуйте ще раз",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);//видаєм повідомлення Перевірте чи заповнені та спробуйте ще раз

            k = 0; serednya_tsina = 0;suma = 0;
        }


        private void button1_Click(object sender, EventArgs e)// при кліку на кнопку визиваєм функцію в якій
        {
            textBox6.Text = "";// очишаєм текст в textBox6
            textBox7.Text = "";// очишаєм текст в textBox7
            textBox8.Text = "";// очишаєм текст в textBox8
            textBox9.Text = "";// очишаєм текст в textBox9
        }

        private void textBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox6, "Введіть Товар");
            toolTip1.IsBalloon = true;
        }

        private void textBox7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox7, "Введіть країну");
            toolTip1.IsBalloon = true;
        }

        private void textBox8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox8, "Введіть виробника");
            toolTip1.IsBalloon = true;
        }

        private void textBox9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox9, "Введіть ціну");
            toolTip1.IsBalloon = true;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введіть назву товару якого ви хочете знайти");
            toolTip1.IsBalloon = true;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "Введіть країну товару якого ви хочете знайти");
            toolTip1.IsBalloon = true;
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введіть виробника товару якого ви хочете знайти");
            toolTip1.IsBalloon = true;
        }




        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox10.Clear();
            textBox5.Clear();
            textBox11.Clear();
        }
        double x = 0, r = 2;
        int round = 1;
        private void button6_Click(object sender, EventArgs e)
        {
            textBox11.ReadOnly = true;
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Не введён X(по умолчанию 0)");
                textBox4.Text = Convert.ToString(0);
            }
            if (textBox10.Text == string.Empty)
            {
                MessageBox.Show("Не введён радиус(по умолчанию 2)");
                textBox10.Text = Convert.ToString(2);
            }
            if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("Не введён округление(по умолчанию 1)");
                textBox5.Text = Convert.ToString(1);
            }
            x = Convert.ToDouble(textBox4.Text);
            r = Convert.ToDouble(textBox10.Text);
            if (r > 2 || r <= 0)
            {
                MessageBox.Show("Не допустимые значения радуса");
                textBox4.Clear();
                textBox10.Clear();
                textBox5.Clear();
                textBox11.Clear();
            }
            if (textBox5.Text == "")
            {
                round = 2;
            }
            else if (Convert.ToInt32(textBox5.Text) >= 16)
            {
                round = 15;
            }
            else
            {
                round = Convert.ToInt32(textBox5.Text);
            }
            if (x >= -10 && x <= -6)
            {
                textBox11.Text = Convert.ToString(Math.Round((Math.Sqrt(Math.Abs(r * r - (x - 8) * (x - 8)) + 2)), round));
            }
            else if (x > -6 && x <= -4)
            {
                textBox11.Text = Convert.ToString(2);
            }
            else if (x > -4 && x <= 2)
            {
                textBox11.Text = Convert.ToString(Math.Round((-x / 2), round));
            }
            else if (x > 2 && x <= 4)
            {
                textBox11.Text = Convert.ToString(Math.Round((x - 3), round));
            }
            else
            {
                MessageBox.Show("Не допустимые значения на данном промежутке");
                textBox4.Clear();
                textBox10.Clear();
                textBox5.Clear();
                textBox11.Clear();
            }
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "Введите Х");
            toolTip1.IsBalloon = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' && ch != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                if (textBox4.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar == '-')
            {
                if (textBox4.Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                    return;
                }
            }

        }

        private void textBox10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox10, "Введите R");
            toolTip1.IsBalloon = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox5, "Введите точность");
            toolTip1.IsBalloon = true;
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox11_MouseHover(object sender, EventArgs e)
        {

        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox12, "Введіть розмірність масиву");
            toolTip1.IsBalloon = true;
        }

        private void textBox13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox13, "Введіть число яке буде на місці нажатого");
            toolTip1.IsBalloon = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int mnozhenya = 1, k = 0, rez1 = 0, rez2 = 0;//далі створбєм чотири змінних перша для того, щоб записувати добуток
                                                         //друга для того, щоб рахувати кількість позитивних елементів масиву
                                                         //rez1 i rez2 для того, щоб записувати в них 2 і 4 додатні елементи
            int size_array;
            if (textBox12.Text == "")
            {
                textBox12.Text = "5";
                size_array = System.Convert.ToInt32(textBox12.Text);
            }
            else if (Convert.ToInt64(textBox12.Text) >= 111) {
                textBox12.Text = "110";
                MessageBox.Show("Найбільше можливе значення 110");
                size_array = System.Convert.ToInt32(textBox12.Text);
            }
            else
            {
                size_array = System.Convert.ToInt32(textBox12.Text);//конвертуєм розмір масиву в textBox1

            }
            int[] sorted_array = new int[size_array];//створюємо масив
            int max = sorted_array[0];//створюємо змінну max, в яку записуєм перший елемент масиву

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

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int mnozhenya = 1, k = 0, rez1 = 0, rez2 = 0;//далі створбєм чотири змінних перша для того, щоб записувати добуток
                                                         //друга для того, щоб рахувати кількість позитивних елементів масиву
                                                         //rez1 i rez2 для того, щоб записувати в них 2 і 4 додатні елементи
            int size_array;
            if (textBox12.Text == "")
            {
                textBox12.Text = "5";
                size_array = System.Convert.ToInt32(textBox12.Text);
            }
            else
            {
                size_array = System.Convert.ToInt32(textBox12.Text);//конвертуєм розмір масиву в textBox1

            }
            int[] sorted_array1 = new int[size_array];//створюємо масив
            int max = sorted_array1[0];//створюємо змінну max, в яку записуєм перший елемент масиву
            for (int counter = 0; counter < size_array; counter++)//створюєо цикл для перерахунку елементів масиву
            {
                sorted_array1[counter] = System.Convert.ToInt32(listBox1.Items[counter]);
            }



            for (int counter = 0; counter < size_array; counter++)//створюєо цикл для перерахунку елементів з довжиною масива
            {
                if (sorted_array1[counter] < 0 && counter % 2 != 0)//якщо елемент масиву менший 0 і порядковий номер не є парним
                {
                    mnozhenya *= sorted_array1[counter];//тоді перемножаєм елементи
                }
                if (sorted_array1[counter] > 0)//якщо елемент масиву більший 0
                {
                    k++;//додаєм до змінної 1
                    if (k == 2) rez1 = counter + 1;//коли цей порядковий номер досягне двох то записуєм значення + 1 щрб користувач розумів
                    if (k == 4) rez2 = counter + 1;//коли цей порядковий номер досягне чотирьох то записуєм значення + 1 щрб користувач розумів
                }
                if (sorted_array1[counter] % 2 != 0)//якщо елемент масиву не є парним
                {
                    if (sorted_array1[counter] > max) max = sorted_array1[counter];//і елемент масиву більший максимального то максимпльному призначається значення елементу масива 
                }

            }
            listBox2.Items.Add(Convert.ToString("dobutok = " + mnozhenya + "\n Elem 2 = " + rez1 + "\n Elem 4 = " + rez2 + "\n" + " max = " + max)); //виводим результат

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (textBox13.Text == "")
                {
                    textBox13.Text = "1";
                }
                listBox1.Items[listBox1.SelectedIndex] = Convert.ToInt32(textBox13.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int countOFMin = 0;//  створюєм змінну для підрпахунку відємних значень
            double[] P = new double[32];//створюємо масив на 32 елементи
            listBox3.Items.Add("");//Вставляємо пробіл
            for (int counter = 0; counter < 32; counter++)//створюєо цикл для перерахунку елементів масиву
            {
                P[counter] = (Math.Log(counter) * Math.Log(counter) - 3.85) / (0.7 * counter + 3.85);//обчислєм значення функції за формулою
                if (P[counter] < 0)//робим умову якщо елемент меньший 0
                {
                    listBox3.Items.Add(Convert.ToString(P[counter] + "\n"));//і виводимо його в listBox1
                    countOFMin++;//додаєм + 1 при кожній вірній умові
                }
                else//в інакшому випадку
                {
                    listBox3.Items.Add(Convert.ToString("Для додатніх не обчислюєм " + "\n"));//виводим в listBox1 для додатніх не обчислюєм
                }
            }
            listBox3.Items.Add(Convert.ToString("Кількість від'ємних = " + countOFMin + "\n"));//виводим в listBox1 кількість від'ємних
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox14.ReadOnly = true;
            int raw, col;
            if (textBox15.Text == "")
            {
                textBox15.Text = "5";
                raw = Convert.ToInt32(textBox15.Text);//конвертуєм значення з textBox2 для того щоб знати кількість рядків
            }
            else
            {
                raw = Convert.ToInt32(textBox15.Text);//конвертуєм значення з textBox2 для того щоб знати кількість рядків
            }
            if (textBox16.Text == "")
            {
                textBox16.Text = "5";
                col = Convert.ToInt32(textBox16.Text);//конвертуєм значення з textBox3 для того щоб знати кількість стовбців
            }
            else
            {
                col = Convert.ToInt32(textBox16.Text);//конвертуєм значення з textBox3 для того щоб знати кількість стовбців
            }
            if (raw >= 28)
            {
                textBox15.Text = "28";
                MessageBox.Show("Максимально допустиме значення 28 ",
        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                raw = 28;
            }
            if (col >= 28)
            {
                textBox16.Text = "28";
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
                    textBox14.AppendText(Convert.ToString(a[i, j]) + "\t");//ввиводим масив
                }
                textBox14.Text += "\r\n" + "\r\n";//ввиводим масив
            }
            textBox14.AppendText("Добуток едементів які більші 2 і менше 10 = " + Convert.ToString(dobutok));//виводиим в кінці добуток едементів які більші 2 і менше 10
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label16.Text = "";//очищуєм текст в label1
            label17.Text = "";//очищуєм текст в label2
            label18.Text = "";//очищуєм текст в label3
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)//створюєм цикл
            {
                label16.Text = ""; label17.Text = ""; label18.Text = "";//очищуєм текст
                label16.Text += imen[rnd.Next(0, num1 + 1)];//додаєм рандомний текст 
                label17.Text += die[rnd.Next(0, num2 + 1)];//додаєм рандомний текст
                label18.Text += priymen[rnd.Next(0, num3 + 1)];//додаєм рандомний текст
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string name = textBox17.Text;//створюєм змінну name типу string якому призначаєм текст з textBox1
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

        private void button12_Click(object sender, EventArgs e)
        {
            string dija = textBox18.Text;//створюєм змінну name типу string якому призначаєм текст з textBox2
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

        private void button13_Click(object sender, EventArgs e)
        {
            string pri = textBox19.Text;//створюєм змінну name типу string якому призначаєм текст з textBox3
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

        private void textBox17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox17, "Введіть Іменник");
            toolTip1.IsBalloon = true;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }

        private void textBox18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox18, "Введіть дієслово");
            toolTip1.IsBalloon = true;
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }

        private void textBox19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox19, "Введіть займенник");
            toolTip1.IsBalloon = true;
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;//
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && l != 'ї' && l != 'і' && l != 'ґ')//
            {
                e.Handled = true;//
            }
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button11, "Введіть іменник клацнувши по цій кнопці для того шоб він з'являвся в новозгенерованих реченнях");
            toolTip1.IsBalloon = true;

        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button12, "Введіть дієслово клацнувши по цій кнопці для того шоб він з'являвся в новозгенерованих реченнях");
            toolTip1.IsBalloon = true;
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button13, "Введіть прийменник клацнувши по цій кнопці для того шоб він з'являвся в новозгенерованих реченнях");
            toolTip1.IsBalloon = true;
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button14, "Натисніть цю кнопку щоб згенерувати речення. Натиснувши ще раз ви згенеруєте нове");
            toolTip1.IsBalloon = true;
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button15, "Натисніть цю кнопку шоб видалити речення");
            toolTip1.IsBalloon = true;
        }

        private void textBox15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox15, "Введіть кількість рядків");
            toolTip1.IsBalloon = true;
        }

        private void textBox16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox16, "Введіть кількість стовбців");
            toolTip1.IsBalloon = true;
        }

        private void textBox9_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }


    }
}
