using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using TrackBar = System.Windows.Forms.TrackBar;
using Microsoft.Office.Interop.Word;
using CheckBox = System.Windows.Forms.CheckBox;
using Excel = Microsoft.Office.Interop.Excel;
using ADOX;
using Microsoft.Office.Interop.Excel;
using Label = System.Windows.Forms.Label;


namespace CourseworkClasses
{
    public class Class1
    {
        // Объявление массива с ответами, массива с удалённым числом, счётчиком количества правильных ответов,
        // переменной, определяющей, авторизован ли пользователь и логином пользователя
        public static int[] mas = new int[16];
        public static int[] arr = new int[15];
        public static int n = 0;
        public static bool is_avt = false;
        public static string Log = "";
        public static bool testRes = false;
        public static bool isRemoved = false;
        // Метод, записывающий неверный ответ (для пропуска ответов)
        public static void Skip(int q)
        {
            mas[q] = 0;
        }
        // Метод для авторизация пользователя с проверкой на заполнение полей
        public static void Avtoriz(TextBox t1, TextBox t2)
        {
            Class1.Log = Convert.ToString(t1.Text);
            string Pass = Convert.ToString(t2.Text);
            if (Log == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Pass == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Users1.mdb");
            p.Open();
            var c = new OleDbCommand("SELECT [Логин], [Пароль] FROM Users", p);
            OleDbDataReader reader = c.ExecuteReader();
            while (reader.Read())
            {
                if ((Log == reader[0].ToString()) & (Pass == reader[1].ToString()))
                {
                    MessageBox.Show("Вы авторизованы!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    is_avt = true;
                }
            }
            reader.Close();
            if (is_avt == false)
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            p.Close();
        }
        // Метод для регистрации пользователя с проверкой на заполнение полей и уникальность имени 
        public static void Registr(TextBox t1, TextBox t2)
        {
            string Log = Convert.ToString(t1.Text);
            string Pass = Convert.ToString(t2.Text);
            if (Log == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Pass == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Users1.mdb");
            p.Open();
            var c = new OleDbCommand("SELECT [Логин], [Пароль] FROM Users", p);
            OleDbDataReader reader = c.ExecuteReader();
            while (reader.Read())
            {
                if (Log == reader[0].ToString())
                {
                    MessageBox.Show("Это имя занято, выберете другое!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    p.Close();
                    return;
                }
            }
            reader.Close();
            var d = new OleDbCommand($"INSERT INTO Users (Логин, Пароль) Values ('{t1.Text}','{t2.Text}')", p);
            OleDbDataReader reader1 = d.ExecuteReader();
            reader1.Close();
            MessageBox.Show("Вы зарегистрированы!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            t1.Text = "";
            t2.Text = "";
            p.Close();
        }
        // Каждый из методов по вопросам возвращает bool переменную, которая показывает, ответил ли пользователь на вопрос
        // Метод проверяющий ответ на вопрос 1
        public static bool v1(ComboBox comboBox1, ComboBox comboBox2,
    ComboBox comboBox3, ComboBox comboBox4)
        {
            // Проверка на заполнение полей
            if (Convert.ToString(comboBox1.SelectedItem) == "" ||
    Convert.ToString(comboBox2.SelectedItem) == "" ||
    Convert.ToString(comboBox3.SelectedItem) == "" ||
    Convert.ToString(comboBox4.SelectedItem) == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и его запись в массив
            if (Convert.ToString(comboBox1.SelectedItem) == "Начало работы" &
            Convert.ToString(comboBox2.SelectedItem) == "Контакты" &
            Convert.ToString(comboBox3.SelectedItem) == "Работа" &
            Convert.ToString(comboBox4.SelectedItem) == "Коммуникации")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[0] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[0] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 2
        public static bool v2(ComboBox comboBox1, ComboBox comboBox2,
System.Windows.Forms.ComboBox comboBox3)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "" ||
    Convert.ToString(comboBox2.SelectedItem) == "" ||
    Convert.ToString(comboBox3.SelectedItem) == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Моя организация" &
            Convert.ToString(comboBox2.SelectedItem) == "База клиентов" &
            Convert.ToString(comboBox3.SelectedItem) == "Календарь")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[1] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[1] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 3
        public static bool v3(CheckBox checkbox1, CheckBox checkbox2, CheckBox checkbox3,
            CheckBox checkbox4, CheckBox checkbox5, CheckBox checkbox6)
        {
            // Проверка на заполение хотя бы одного поля
            if (checkbox1.Checked == false & checkbox2.Checked == false & checkbox3.Checked == false &
                checkbox4.Checked == false & checkbox5.Checked == false & checkbox6.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и запись ответа в массив
            if (checkbox1.Checked == true & checkbox2.Checked == true & checkbox3.Checked == false &
                checkbox4.Checked == true & checkbox5.Checked == false & checkbox6.Checked == true)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[2] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[2] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 4
        public static bool v4(CheckBox checkbox1, CheckBox checkbox2, CheckBox checkbox3,
    CheckBox checkbox4, CheckBox checkbox5, CheckBox checkbox6)
        {
            if (checkbox1.Checked == false & checkbox2.Checked == false & checkbox3.Checked == false &
                checkbox4.Checked == false & checkbox5.Checked == false & checkbox6.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (checkbox1.Checked == true & checkbox2.Checked == true & checkbox3.Checked == true &
                checkbox4.Checked == true & checkbox5.Checked == true & checkbox6.Checked == true)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[3] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[3] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 5
        public static bool v5(TrackBar tb, Label l)
        {
            // Проверка на выбор ответа
            if (l.Text == "")
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и его запись в массив
            if (tb.Value == 14)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[4] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[4] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 6
        public static bool v6(RadioButton r1, RadioButton r2, RadioButton r3, RadioButton r4)
        {
            // Проверка на выбор отвтеа
            if (r1.Checked == false & r2.Checked == false & r3.Checked == false &
                r4.Checked == false)
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и его запись в массив
            if (r2.Checked == true)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[5] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[5] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 7
        public static bool v7(HScrollBar tb, Label l)
        {
            // Проверка на выбор ответа
            if (l.Text == "")
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и его запись в массив
            if (tb.Value == 35)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[6] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[6] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 8
        public static bool v8(RadioButton r1, RadioButton r2, RadioButton r3, RadioButton r4)
        {
            if (r1.Checked == false & r2.Checked == false & r3.Checked == false &
                r4.Checked == false)
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (r4.Checked == true)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[7] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[7] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 9
        public static bool v9(HScrollBar tb, Label l)
        {
            if (l.Text == "")
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tb.Value == 22)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[8] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[8] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 10
        public static bool v10(TextBox t)
        {
            if (t.Text == "")
            {
                MessageBox.Show("Заполните поле", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (t.Text == "моя организация")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[9] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[9] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 11
        public static bool v11(TrackBar tb, Label l)
        {
            if (l.Text == "")
            {
                MessageBox.Show("Выберите вариант", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tb.Value == 30)
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[10] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[10] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 12
        public static bool v12(TextBox t)
        {
            // Проверка на заполнение полей
            if (t.Text == "")
            {
                MessageBox.Show("Заполните поле", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и запись результата в массив
            if (t.Text == "партнёрам" || t.Text == "партнерам")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[11] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[11] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 13
        public static bool v13(TextBox t1, TextBox t2, TextBox t3, TextBox t4)
        {
            if (t1.Text == "" || t2.Text == "" || t3.Text == "" || t4.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (t1.Text == "Телефония" && t2.Text == "Оповещения" && t3.Text == "Почта" && t4.Text == "Персонал")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[12] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[12] = 1; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 14
        public static bool v14(TextBox t1, TextBox t2, TextBox t3, TextBox t4)
        {
            // Проверка на заполнение полей
            if (t1.Text == "" || t2.Text == "" || t3.Text == "" || t4.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка на верность ответа и запись ответа в массив
            if (t1.Text == "Партнёрам" && t2.Text == "Mac OS" && t3.Text == "Починить" && t4.Text == "Биллинг")
            {
                MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mas[13] = 1;
                n++;
            }
            else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[13] = 0; }
            return true;
        }
        // Метод проверяющий ответ на вопрос 15
        public static bool v15(CheckedListBox ch, Label l)
        {
            // Проверка на верность ответа и его запись в массив
            if (l.Text == "")
            {
                if (Convert.ToString(ch.CheckedItems[0]) == "Программа имеет систему навигации")
                {
                    MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mas[14] = 1;
                    n++;
                }
                else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[14] = 0; }
                return true;
            }
            // Проверка на выбор ответа
            else
            {
                MessageBox.Show("Выберите хотя бы одно значение", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // Метод проверяющий ответ на вопрос 16
        public static bool v16(CheckedListBox ch, Label l)
        {
            if (l.Text == "")
            {
                if (Convert.ToString(ch.CheckedItems[0]) == "Пробный период программы составляет 7 дней")
                {
                    MessageBox.Show("Верно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mas[15] = 1;
                    n++;
                }
                else { MessageBox.Show("Неверно!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information); mas[15] = 1; }
                return true;
            }
            else
            {
                MessageBox.Show("Выберите хотя бы одно значение", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // Метод, добавляющий массив с ответами в Word
        public static void AddWord(int[] mas)

        {
            // Проверка, был ли выведен массив с ответами
            if (Class1.testRes == false)
            {
                MessageBox.Show("Для начала сгенерируйте ответы", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            var Wrd = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true
            };
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf);
            Wrd.Selection.TypeText("Массив Ответов");
            object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, mas.Length, t1, t2);
            for (int i = 0; i < mas.Length; i++)
            {
                tbl.Cell(1, i + 1).Range.InsertAfter("[" + Convert.ToString(i + 1) + "]");
                str = String.Format("{0:f0}", mas[i]);
                tbl.Cell(2, i + 1).Range.InsertAfter(str);
            }
        }
        // Метод, добавялющий массив с ответами в Excel с установлениес границ
        public static void AddExcel(int[] mas)
        {
            // Проверка, был ли выведен массив с ответами
            if (Class1.testRes == false)
            {
                MessageBox.Show("Для начала сгенерируйте ответы", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Массив Исходный";
            workSheet.Cells[1, 1] = "Массив ответов";
            for (int i = 0; i < mas.Length; i++)
            {
                int q = i + 1;
                workSheet.Cells[2, i + 1] = "[" + q + "]";
                workSheet.Cells[3, i + 1] = mas[i];
            }
            Excel.Range range1 = workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[3, mas.Length]];
            range1.Cells.Font.Name = "Times New Roman";
            range1.Cells.Font.Size = 14;
            range1.Cells.Columns.AutoFit();
            range1.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle =
            Excel.XlLineStyle.xlContinuous; //Нижняя граница для всего диапазона
            range1.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle =
            Excel.XlLineStyle.xlContinuous; //Правая граница для всего диапазона
            range1.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle =
            Excel.XlLineStyle.xlContinuous; //горизонтальная граница для внутренних ячеек
            range1.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle =
            Excel.XlLineStyle.xlContinuous; //вертикальная граница для внутренних ячеек
            range1.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle =
            Excel.XlLineStyle.xlContinuous; //верхняя граница для всего диапазона
            workSheet.Range[("A7")].Select();
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        // Метод для удаления элемента из массива, который также создаёт новый массив
        // без удалённого элемента и заполняет им таблицу
        public static void Del(int[] mas, int length, DataGridView DGV, int k)
        {
            for (int i = 0; i < length; i++)
            {

                if (i == k)
                {
                    k = i;
                }
            }
            for (int i = 0; i < k; i++)
            {
                arr[i] = mas[i];
            }
            for (int i = k+1; i < length; i++)
            {
                arr[i-1] = mas[i];
            }

            for (int i = k; i < length - 1; i++)
            {
                mas[i] = mas[i + 1];
            }
            length = length - 1;
            Array.Resize(ref mas, mas.Length - 1);
            DGV.Rows.Clear();
            DGV.Rows.Add("Номер вопроса", "Ответ"); for (int i = 0; i < length; i++)
            {
                DGV.Rows.Add(Convert.ToString(i + 1), Class1.mas[i].ToString());
            }
        }
        // Метод для ввода пользователем числа в всплывающее окно
        public static int InputBox(string mess)
        {
            int chislo = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(mess, "Ввод", "", -1, -1));
            return chislo;
        }
    }
}

    

