using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseworkClasses;

namespace Coursework
{
    public partial class main_page : Form
    {
        public main_page()
        {
            InitializeComponent();
        }
        // Переход на форму с регистрацией и авторизацией
        private void button1_Click(object sender, EventArgs e)
        {
            Avt f = new Avt();
            this.Hide();
            f.Show();
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Переход на форму с конспектом
        private void button3_Click(object sender, EventArgs e)
        {
            Conspekt f = new Conspekt();
            this.Hide();
            f.Show();
        }
        // Переход на форму с тестиованием
        private void button4_Click(object sender, EventArgs e)
        {
            //Проверка на авторизоавнность пользователя
            if (Class1.is_avt == true)
            {
                v1 f = new v1();
                this.Hide();
                f.Show();
            }
            else{MessageBox.Show("Для прохождения тестирования необходимо авторизоваться", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        // Переход на форму с напутствием, которое считано из текстового файла и вставленное в нарисованную область
        private void button5_Click_1(object sender, EventArgs e)
        {
            NonstandartForm f = new NonstandartForm();
            this.Hide();
            f.Show();
        }
        // Переход на форму с медиаплеером
        private void button6_Click(object sender, EventArgs e)
        {
            NonStF f = new NonStF();
            this.Hide();
            f.Show();
        }
        // Обновление строки состяния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        // Переход на форму с информацией
        private void button8_Click(object sender, EventArgs e)
        {
            Circles f = new Circles();
            this.Hide();
            f.Show();
        }

        private void main_page_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
