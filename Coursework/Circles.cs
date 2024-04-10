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

namespace Coursework
{
    public partial class Circles : Form
    {
        public Circles()
        {
            InitializeComponent();
        }
        // Рисование округлой формы с кругами
        private void Circles_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsPath z = new GraphicsPath();
            z.AddArc(400, 700, 100, 100, 0, 400);
            z.AddArc(1000, 700, 100, 100, 0, 400);
            z.AddEllipse(0, -300, this.Width, 1000);
            this.Region = new Region(z);
            g.Dispose();
        }
        // Выход из программы
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Переход в меню
        private void button1_Click(object sender, EventArgs e)
        {
            main_page f = new main_page();
            this.Hide();
            f.Show();
        }
    }
}
