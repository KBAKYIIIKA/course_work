using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public partial class NonStF : Form
    {
        OpenFileDialog openFileDialog1;
        public NonStF()
        {
            InitializeComponent();
        }
        // Рисование округлой формы
        private void NonStF_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsPath z = new GraphicsPath();
            z.AddEllipse(0, -300, this.Width, 1200);
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
        // Кнопка, позволяющая выбрать видеоролик
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        // Вывод версии проигрывателя
        private void NonStF_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            this.Text = "                     Windows Media Player, версия = " + axWindowsMediaPlayer1.versionInfo;
        }
        // Кнопка, осуществляющая переход в полноэкранный режим
        private void button4_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                axWindowsMediaPlayer1.fullScreen = true;
        }
        // Кнопка, ставящая видео на паузу
        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
        // Кнопка, возобновляющая проигрывание
        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        // Кнопка,выключающая звук
        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.mute = true;
        }
        // Кнопка, включающая звук
        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.mute = false;
        }
        // Кнопка, пкоазывающая свойства плеера
        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.ShowPropertyPages();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
