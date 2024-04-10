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
    public partial class v9 : Form
    {
        public v9()
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
            bool k = Class1.v9(hScrollBar1, label3);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v10 f = new v10();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(8);
            v10 f = new v10();
            this.Hide();
            f.Show();
        }
        //Отображение значения hscrollbar
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
