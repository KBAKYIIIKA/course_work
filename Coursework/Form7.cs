﻿using System;
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
    public partial class v1 : Form
    {
        public v1()
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
            bool k = Class1.v1(comboBox1, comboBox2, comboBox3, comboBox4);
            //Проверка, был ли ответ на вопрос
            if (k == true)
            {
                v2 f = new v2();
                this.Hide();
                f.Show();
            }
        }
        // Пропуск вопроса
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Skip(0);
            v2 f = new v2();
            this.Hide();
            f.Show();
        }
        // Смена строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
