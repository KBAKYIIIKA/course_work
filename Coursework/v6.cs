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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework
{
    public partial class v6 : Form
    {
        public v6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void v6_Load(object sender, EventArgs e)
        {

        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button5_Click(object sender, EventArgs e)
        {
            bool k = Class1.v6(radioButton1, radioButton2, radioButton3, radioButton4);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v7 f = new v7();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(5);
            v7 f = new v7();
            this.Hide();
            f.Show();
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
