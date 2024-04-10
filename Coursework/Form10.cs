using CourseworkClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework
{
    public partial class v4 : Form
    {
        string q4;
        // Вопрос 4
        public v4()
        {
            //Считывание текста из файла
            InitializeComponent();
            StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\4.txt",
                    System.Text.Encoding.GetEncoding(65001));
                q4 = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Файл не найден!" + exc.ToString(),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Вывод текста в label
            label1.Text = Convert.ToString(q4);
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v4(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v5 f = new v5();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(3);
            v5 f = new v5();
            this.Hide();
            f.Show();
        }
        // Строка состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
    }
}
