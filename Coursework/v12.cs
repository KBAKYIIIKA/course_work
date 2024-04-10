using CourseworkClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class v12 : Form
    {
        string q12;
        //Вопрос 12
        public v12()
        {
            //Чтение вопроса из файла
            InitializeComponent();
            textBox1.BringToFront();
            StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\4.txt",
                    System.Text.Encoding.GetEncoding(65001));
                q12 = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Файл не найден!" + exc.ToString(),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //Вывод текста в label
            label8.Text = Convert.ToString(q12);
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v12(textBox1);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v13 f = new v13();
                this.Hide();
                f.Show();
            }
        }

        private void v12_Load(object sender, EventArgs e)
        {

        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(11);
            v13 f = new v13();
            this.Hide();
            f.Show();
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
