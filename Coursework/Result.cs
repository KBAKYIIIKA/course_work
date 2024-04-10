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
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;

namespace Coursework
{
    public partial class Result : Form
    {
        // Расположение файла с макросами
        private static string NameExcel = @"C:\Users\arbaa\OneDrive\Рабочий стол\%№;№%;№%\Makros.xlsm";
        public Result()
        {
            InitializeComponent();
            // Обращение к пользователю
            label2.Text = "Поздравяляю, " + Class1.Log + "! Вы прошли тест!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Заполнение результатов
            dataGridView2.ColumnCount = 2;
            dataGridView2.Rows.Add("Номер вопроса", "Ответ");
            for (int i = 0; i < Class1.mas.Length; i++) {
                dataGridView2.Rows.Add(Convert.ToString(i+1), Class1.mas[i].ToString());
            }
            label1.Text = "Ваш результат: " + Class1.n.ToString() + " из 16-и.";
            Class1.testRes = true;
            //Первый правильный ответ (с икслючением)
            for (int i = 0; i < Class1.mas.Length; i++)
            {
                if (Class1.mas[i] == 1)
                {
                    MessageBox.Show("Первый правильный ответ: " + (i + 1), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Нет правильных ответов!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Выход из программы
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Вызов метод, записывающего результаты в Word
        private void button3_Click(object sender, EventArgs e)
        {
            Class1.AddWord(Class1.mas);
        }
        // Вывов метода, записывающего результаты в Excel
        private void button4_Click(object sender, EventArgs e)
        {
            Class1.AddExcel(Class1.mas);
        }
        // Открытие файла doc/docx через диалоговое окно
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.doc;*.docx";
            otkr.Filter = "Microsoft Word (*docx*)|*.doc*";
            otkr.Title = "Выберите документ Word";
            if (otkr.ShowDialog()!= DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }
        // Открытие файла doc/docx через диалоговое окно
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.xlsm;*.xlsx";
            otkr.Filter = "Microsoft Excel (*xlsm*)|*.xlsx*";
            otkr.Title = "Выберите документ Excel";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }
        // Обновление строки состояния
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel2.Text = "C# 11 . NET 7";
        }
        // Удаление строки с выбранным индексом
        private void button7_Click(object sender, EventArgs e)
        {
            // Проверка, был ли выведен массив с ответами
            if (Class1.testRes == false) {
                MessageBox.Show("Для начала сгенерируйте ответы", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mess = "Введите номер удаляемого числа";
            int k = Class1.InputBox(mess);
            Class1.isRemoved = true;
            Class1.Del(Class1.mas, Class1.mas.Length, dataGridView2, k-1);
        }
        // Запуск файла с макросом и запись в него результатов
        private void button8_Click(object sender, EventArgs e)
        {
            // Проверка, был ли выведен массив с ответами
            if (Class1.testRes == false)
            {
                MessageBox.Show("Для начала сгенерируйте ответы", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Проверка, был ли удалён элемент
            if (Class1.isRemoved == false)
            {
                MessageBox.Show("Для начала удалите элемент", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();                                                                                                                                                       
            Workbook ObjWorkBook = ObjExcel.Workbooks.Open(NameExcel,0, false, 5, "", "",
                false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Worksheet workSheet;
            workSheet = (Worksheet)ObjWorkBook.Worksheets.get_Item(1);
            workSheet.Name = "Массив Исходный";
            workSheet.Cells[1, 1] = "Массив ответов";
            for (int i = 0; i < Class1.arr.Length; i++)
            {
                int q = i + 1;
                workSheet.Cells[2, i + 1] = "[" + q + "]";
                workSheet.Cells[3, i + 1] = Class1.arr[i];
            }
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
        // Переход в меню
        private void button9_Click(object sender, EventArgs e)
        {
            main_page f = new main_page();
            this.Hide();
            f.Show();
        }
    }
}
