using CourseworkClasses;
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

namespace Coursework
{
    public partial class v5 : Form
    {
        string q5;
        //Вопрос 5
        public v5()
        {
            //Чтение текста из файла
            InitializeComponent();
            StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\5.txt",
                    System.Text.Encoding.GetEncoding(65001));
                q5 = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Файл не найден!" + exc.ToString(),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //Подстановка текста
            label1.Text = Convert.ToString(q5);
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v5(trackBar1, label3);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v6 f = new v6();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(4);
            v6 f = new v6();
            this.Hide();
            f.Show();
        }
        // Отображение состояния trackbar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
    }
}
