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
    public partial class v7 : Form
    {
        string q7;
        //Вопрос 7
        public v7()
        {
            //Чтение текста из файла
            InitializeComponent();
            StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\7.txt",
                    System.Text.Encoding.GetEncoding(65001));
                q7 = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Файл не найден!" + exc.ToString(),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //Отображение текста
            label1.Text = Convert.ToString(q7);
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v7(hScrollBar1, label3);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v8 f = new v8();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(6);
            v8 f = new v8();
            this.Hide();
            f.Show();
        }
        //Отобржание значения hscrollbar
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = String.Format("Текущее значение: {0}", hScrollBar1.Value);
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
    }
}
