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

namespace Coursework
{
    public partial class v11 : Form
    {
        public v11()
        {
            InitializeComponent();
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v11(trackBar1, label3);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v12 f = new v12();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(10);
            v12 f = new v12();
            this.Hide();
            f.Show();
        }
        //Отображение значения trackbar
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
