using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
    public partial class NonstandartForm : Form
    {
        string MyStroka;
        public NonstandartForm()
        {
            InitializeComponent();
        }

        private void NonstandartForm_Load(object sender, EventArgs e)
        {

        }
        //Вывод текста в нарисованную обалсть
        private void NonstandartForm_Paint_1(object sender, PaintEventArgs e)
        {
            // Чтение текста из файла
            StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(@"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\NSF.txt",
                    System.Text.Encoding.GetEncoding(65001));
                MyStroka = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Файл не найден!" + exc.ToString(),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Рисование обалсти и вывод в неё текста
            Rectangle MyR = new Rectangle(190, 60, 300, 180);
            Font MyFont = new Font("Times New Roman", 18);
            LinearGradientBrush MyBrush = new LinearGradientBrush(MyR, Color.Red,
                Color.Yellow, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(MyBrush, MyR);
            StringFormat align = new StringFormat();
            align.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(MyStroka, MyFont, Brushes.Black, MyR, align);
            e.Graphics.DrawRectangle(Pens.BurlyWood, MyR);

        }

        private void NonstandartForm_Resize_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
        // Выход из программы
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
