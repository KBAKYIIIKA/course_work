using CourseworkClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Avt : Form
    {
        public Avt()
        {
            InitializeComponent();
            pass.UseSystemPasswordChar = true;
        }
        // Выход из программы
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        // Переход в главное меню
        private void button1_Click(object sender, EventArgs e)
        {
            main_page f = new main_page();
            this.Hide();
            f.Show();
        }
        // Функция, скрывающая и отобраающая пароль
        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
            {
                pass.UseSystemPasswordChar = false;

            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }
        // Вызов метода авторизации
        private void button3_Click(object sender, EventArgs e)
        {
            Class1.Avtoriz(login, pass);
        }
        // Вызов метода регистрации
        private void button4_Click(object sender, EventArgs e)
        {
            Class1.Registr(login, pass);
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }

        private void Avt_Load(object sender, EventArgs e)
        {

        }
    }
}
