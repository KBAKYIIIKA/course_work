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
    public partial class v3 : Form
    {
        public v3()
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
            bool k = Class1.v3(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6);
            if (k == true)
            {
                v4 f = new v4();
                this.Hide();
                f.Show();
            }
        }

        private void v3_Load(object sender, EventArgs e)
        {

        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(2);
            v4 f = new v4();
            this.Hide();
            f.Show();
        }
        // Смена строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
    }
}
