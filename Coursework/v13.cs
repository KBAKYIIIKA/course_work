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
    public partial class v13 : Form
    {
        public v13()
        {
            InitializeComponent();
        }

        private void v13_Load(object sender, EventArgs e)
        {

        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов метода проверки вопроса с переходом на следующую форму
        private void button4_Click(object sender, EventArgs e)
        {
            bool k = Class1.v13(textBox1, textBox2, textBox3, textBox4);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v14 f = new v14();
                this.Hide();
                f.Show();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(12);
            v14 f = new v14();
            this.Hide();
            f.Show();
        }
        //Подстановка выбранного элемента
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(listBox1.SelectedItem);
        }
        //Подстановка выбранного элемента
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(listBox1.SelectedItem);
        }
        //Подстановка выбранного элемента
        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(listBox1.SelectedItem);
        }
        //Подстановка выбранного элемента
        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(listBox1.SelectedItem);
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
    }
}
