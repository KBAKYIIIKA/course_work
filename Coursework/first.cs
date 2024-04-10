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
    public partial class first : Form
    {
        public first()
        {
            InitializeComponent();
        }
        // Рисование текста, линии и отображение картинки
        private void first_Paint(object sender, PaintEventArgs e)
        {
            Image MyImage = Image.FromFile(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\zz.jpg");
            Graphics MyGraphics = Graphics.FromImage(MyImage);
            Graphics g = e.Graphics;
            g.DrawImage(MyImage, new PointF(200.0F, 100.0F));
            MyGraphics.Dispose();
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            g.DrawString("Пособие по CRM-системе Простой Бизнес",
                new Font("Times New Roman", 24), MyBrush, 120, 30);
            Pen MyPen = new Pen(Color.Yellow, 10);
            e.Graphics.DrawLine(MyPen, 150, 80, 700, 80);
        }
        // Выход из программы
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // По истечению времени программа автоматически переходит в главное меню
        private void timer1_Tick(object sender, EventArgs e)
        {
            main_page f = new main_page();
            this.Hide();
            f.Show();
            timer1.Stop();
        }

        private void first_Load(object sender, EventArgs e)
        {

        }
    }
}
