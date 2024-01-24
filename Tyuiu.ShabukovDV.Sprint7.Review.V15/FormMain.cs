using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.ShabukovDV.Sprint7.Review.V15.Lib;
using System.IO;
namespace Tyuiu.ShabukovDV.Sprint7.Review.V15
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        static int rows = 0;
        static int columns = 8;
        static string openFilePath = "";
        static string[,] arrayValues = new string[rows, columns];
        static int newID = 0;
        static bool wasTrue = false;
        static string[] filters = new string[7];
        DataService ds = new DataService();

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private string[,] LoadFromFileData(string filePath)
        {
            try
            {
                string fileData = File.ReadAllText(filePath, Encoding.GetEncoding(1251));//читает файл, сохраняет в fileData
                fileData = fileData.Replace("\n", "\r"); //заменяет символ переноса строки на перенос каретки
                string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);  //делит элементы fileData используя каретку, сохр. в lines
                try
                {
                    rows = lines.Length;
                    columns = lines[0].Split(';').Length; //кол-во столбцов в 1й строке, разделяя ее по ;


                    arrayValues = new string[rows, columns];

                    for (int r = 0; r < rows; r++)
                    {
                        string[] line_r = lines[r].Split(';'); //создается массив разделенных строк символом ;
                        for (int c = 0; c < columns; c++)
                        {
                            arrayValues[r, c] = line_r[c]; //в основной массив закидываеца массив разделенных строк
                        }
                    }
                }
                catch
                {
                    rows = 0;
                    columns = 8;
                    arrayValues = new string[rows, columns];
                }
            }
            catch { }

            return arrayValues;
        }

        private void UpdateTable() //синхронизация текущей таблицы с массивом
        {
            dataGridViewTable_SDV.Rows.Clear();
            for (int r = 0; r < rows; r++)
            {
                dataGridViewTable_SDV.Rows.Add();
                for (int c = 0; c < columns; c++) //цикл, который проходит по каждой строке
                {
                    dataGridViewTable_SDV.Rows[r].Cells[c].Value = arrayValues[r, c];
                }
            }
        }

        private void Filter()
        {
            dataGridViewTable_SDV.Rows.Clear();
            for (int i = 0; i < rows; i++)
            {

                try //фильтр: если оклад меньше числа в фильтре или фильтр пустой или фильтр = 0, И если число оклада меньше или равно фильтру макс. или фильтр макс пустой или фильтр макс = 0, И если должность равна тому что в фильтре или фильтр пустой или фильтр = 0
                {
                    if ((Convert.ToInt32(arrayValues[i, 5]) >= Convert.ToInt32(filters[0]) || string.IsNullOrWhiteSpace(filters[0]) || Convert.ToInt32(filters[0]) == 0) && (Convert.ToInt32(arrayValues[i, 5]) <= Convert.ToInt32(filters[1]) || string.IsNullOrWhiteSpace(filters[1]) || Convert.ToInt32(filters[1]) == 0) && (arrayValues[i, 4] == filters[3] || string.IsNullOrWhiteSpace(filters[3])))
                    {



                        dataGridViewTable_SDV.Rows.Add(arrayValues[i, 0]);
                        for (int k = 1; k < columns; k++)
                        {
                            dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.RowCount - 1].Cells[k].Value = arrayValues[i, k];// значения всех ячеек последней строки (кроме id)  поменять на те, что в массиве
                        }




                    }
                }

                catch
                {
                    dataGridViewTable_SDV.Rows.Add(arrayValues[i, 0]);
                    for (int k = 1; k < columns; k++)
                    {
                        dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.RowCount - 1].Cells[k].Value = arrayValues[i, k]; // значения всех ячеек последней строки (кроме id)  поменять на те, что в массиве
                    }
                }

            }
        }

        private void buttonAdd_SDV_Click(object sender, EventArgs e)
        {
            dataGridViewTable_SDV.Rows.Add();
            buttonAboutPeople_SDV.Enabled = true;
            buttonDelete_SDV.Enabled = true;
            wasTrue = true;
            rows++;

            for (int i = 1; i < columns; i++)
            {
                dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[i].Value = ""; //очистка всех ячеек, кроме ID в последней добвленной строке

            }

            for (int i = 0; i < rows - 1; i++)
            {
                newID = Math.Max(Convert.ToInt32(arrayValues[i, 0]), newID);
            }
            newID++;
            dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[0].Value = Convert.ToString(newID); //устанавить значение первой ячейки в последней добавленной строке в таблице равным новому идентификатору
            string[,] tempValues = arrayValues; //temp - временный
            arrayValues = new string[rows, columns];
            for (int r = 0; r < rows - 1; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    arrayValues[r, c] = tempValues[r, c];
                }
            }
            for (int с = 0; с < columns; с++)
                arrayValues[rows - 1, с] = Convert.ToString(dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[с].Value);
            textBoxAmountPeople_SDV.Text = Convert.ToString(ds.People(arrayValues)); //делаем так чтобы значение в texbox было равно значению метода в ДС

        }

        private void buttonDelete_SDV_Click(object sender, EventArgs e)
        {
            string[] tempArray = new string[dataGridViewTable_SDV.SelectedRows.Count];
            int cnt = 0;
            foreach (DataGridViewRow item in this.dataGridViewTable_SDV.SelectedRows) //это все надо чтобы при удалении какой либо строки все не ломалось в ID
            {
                tempArray[cnt] = Convert.ToString(dataGridViewTable_SDV.Rows[item.Index].Cells[0].Value); //забиваем значение первой ячейки во временный массив в cnt
                dataGridViewTable_SDV.Rows.RemoveAt(item.Index); //удаляем выбранную строку
                cnt++;
            }
            UpdateTable();

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < tempArray.GetLength(0); j++)
                {
                    try
                    {
                        if (Convert.ToString(dataGridViewTable_SDV.Rows[i].Cells[0].Value) == tempArray[j]) //равно ли значение первой ячейки в строке с индексом i в таблице значению во врем. массиве под индексом j.
                        {
                            dataGridViewTable_SDV.Rows.RemoveAt(i);
                            rows--;
                        }
                    }
                    catch
                    {
                        if (Convert.ToString(dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[0].Value) == tempArray[j]) //равно ли значение первой ячейки в последней строке с индексом i в таблице значению во врем. массиве под индексом j.
                        {
                            dataGridViewTable_SDV.Rows.RemoveAt(dataGridViewTable_SDV.Rows.Count - 1);
                            rows--;
                        }
                    }
                }

            }
            arrayValues = new string[rows, columns];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    arrayValues[r, c] = Convert.ToString(dataGridViewTable_SDV.Rows[r].Cells[c].Value);

                }
            }
            newID = 0;
            textBoxAmountPeople_SDV.Text = Convert.ToString(ds.People(arrayValues));
            textBoxMinDohod_SDV.Text = Convert.ToString(ds.MinDohod(arrayValues));
            textBoxMaxDohod_SDV.Text = Convert.ToString(ds.MaxDohod(arrayValues));
            textBoxSummDohod_SDV.Text = Convert.ToString(ds.SummDohod(arrayValues));
            Filter();
        }

        
        private void buttonAboutPeople_SDV_Click(object sender, EventArgs e)
        {
            FormAboutPeople formRoute = new FormAboutPeople();
            foreach (DataGridViewRow item in this.dataGridViewTable_SDV.SelectedRows)
            {
                try
                {
                    formRoute.Text = Convert.ToString(dataGridViewTable_SDV.Rows[item.Index].Cells[2].Value);
                }
                catch { }
            }
            formRoute.valueArray = arrayValues;
            formRoute.Show();
        }

        private void textBoxSearch_SDV_TextChanged(object sender, EventArgs e)
        {
            dataGridViewTable_SDV.Rows.Clear();
            string text = textBoxSearch_SDV.Text;
            if (text != "")
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (arrayValues[i, j].Contains(text))
                        {
                            foreach (DataGridViewRow row in dataGridViewTable_SDV.Rows)
                            {
                                if (row.Cells[0].Value.ToString().Contains(arrayValues[i, 0])) //если значение первой ячейки в строке содержит значение из первого столбца найденной строки
                                {
                                    dataGridViewTable_SDV.Rows.Remove(row);
                                }
                            }
                            dataGridViewTable_SDV.Rows.Add(arrayValues[i, 0]);
                            for (int k = 1; k < columns; k++)
                            {
                                dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.RowCount - 1].Cells[k].Value = arrayValues[i, k];//Заполняем остальные ячейки новой строки значениями из найденной строки
                            }
                        }
                    }
                }
            }
            else
            {
                UpdateTable();
            }
        }

        

        private void dataGridViewTable_SDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < dataGridViewTable_SDV.Rows.Count; j++)
                {
                    if (Convert.ToString(dataGridViewTable_SDV.Rows[j].Cells[0].Value) == arrayValues[i, 0])
                    {

                        for (int k = 1; k < columns; k++)
                        {
                            arrayValues[i, k] = Convert.ToString(dataGridViewTable_SDV.Rows[j].Cells[k].Value); //каждая ячейка преобразована в строку и закидывается в массив
                        }
                    }
                    if (!comboBoxPos_SDV.Items.Contains(Convert.ToString(dataGridViewTable_SDV.Rows[j].Cells[4].Value)) && !(string.IsNullOrWhiteSpace(Convert.ToString(dataGridViewTable_SDV.Rows[j].Cells[4].Value))))// есть ли значение пятой ячейки в текущей строке таблицы в списке элементов фильтра, и проверяет пусто ли там, или есть пробеллы
                    {
                        comboBoxPos_SDV.Items.Add(Convert.ToString(dataGridViewTable_SDV.Rows[j].Cells[4].Value)); //добавляем значение 5й колонки в комбобокс
                    }
                }
            textBoxAmountPeople_SDV.Text = Convert.ToString(ds.People(arrayValues));
            textBoxMinDohod_SDV.Text = Convert.ToString(ds.MinDohod(arrayValues));
            textBoxMaxDohod_SDV.Text = Convert.ToString(ds.MaxDohod(arrayValues));
            textBoxSummDohod_SDV.Text = Convert.ToString(ds.SummDohod(arrayValues));
        }

        private void comboBoxPos_SDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            filters[3] = Convert.ToString(comboBoxPos_SDV.Text);
            Filter();
        }

        private void buttonResetFilters_SDV_Click(object sender, EventArgs e)
        {
            comboBoxPos_SDV.Text = string.Empty;
            numericUpDownMinDohod_SDV.Value = 0;
            numericUpDownMaxDohod_SDV.Value = 0;
            UpdateTable();
        }

        private void numericUpDownMinDohod_SDV_ValueChanged(object sender, EventArgs e)
        {
            filters[0] = Convert.ToString(numericUpDownMinDohod_SDV.Value);
            Filter();
        }

        private void numericUpDownMaxDohod_SDV_ValueChanged(object sender, EventArgs e)
        {
            filters[1] = Convert.ToString(numericUpDownMaxDohod_SDV.Value);
            Filter();
        }

        private void файликиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        

        private void saveFileDialogSaveTo_SDV_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        

        private void labelNaming_SDV_Click(object sender, EventArgs e)
        {

        }

       

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripMenuItemNewTable_SDV_Click_1(object sender, EventArgs e)
        {
            rows = 0;
            columns = 8;
            openFilePath = "";
            arrayValues = new string[rows, columns];
            newID = 0;
            dataGridViewTable_SDV.Rows.Clear();
            buttonAboutPeople_SDV.Enabled = false;
            buttonDelete_SDV.Enabled = false;
            wasTrue = false;
            comboBoxPos_SDV.Text = string.Empty;
            filters = new string[7];
            textBoxAmountPeople_SDV.Text = null;
            textBoxMinDohod_SDV.Text = null;
            textBoxMaxDohod_SDV.Text = null;
            textBoxSummDohod_SDV.Text = null;
        }

        private void ToolStripMenuItemOpen_SDV_Click(object sender, EventArgs e)
        {
            openFileDialogTable_SDV.ShowDialog();
            openFilePath = openFileDialogTable_SDV.FileName;

            arrayValues = LoadFromFileData(openFilePath);

            dataGridViewTable_SDV.ColumnCount = columns;
            dataGridViewTable_SDV.RowCount = rows;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewTable_SDV.Rows[r].Cells[c].Value = arrayValues[r, c];
                }
            }
            if (rows > 0)
            {
                buttonAboutPeople_SDV.Enabled = true;
                buttonDelete_SDV.Enabled = true;
                wasTrue = true;
                textBoxAmountPeople_SDV.Text = Convert.ToString(ds.People(arrayValues));
                textBoxMinDohod_SDV.Text = Convert.ToString(ds.MinDohod(arrayValues));
                textBoxMaxDohod_SDV.Text = Convert.ToString(ds.MaxDohod(arrayValues));
                textBoxSummDohod_SDV.Text = Convert.ToString(ds.SummDohod(arrayValues));
            }
        }

        private void ToolStripMenuItemSave_SDV_Click(object sender, EventArgs e)
        {
            saveFileDialogSaveTo_SDV.FileName = "База Данных Работников.csv";
            saveFileDialogSaveTo_SDV.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialogSaveTo_SDV.ShowDialog();

            openFilePath = saveFileDialogSaveTo_SDV.FileName;
            FileInfo fileInfo = new FileInfo(openFilePath);
            bool fileExists = fileInfo.Exists;

            if (fileExists)
            {
                File.Delete(openFilePath);
            }
            string str = "";
            dataGridViewTable_SDV.Sort(dataGridViewTable_SDV.Columns[0], ListSortDirection.Ascending);//сорт в порядке возрастания в 1й колонке
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j != columns - 1)
                    {
                        str = str + dataGridViewTable_SDV.Rows[i].Cells[j].Value + ";";//если строчка не ластовая, то добавляем разделитель
                    }
                    else
                    {
                        str += dataGridViewTable_SDV.Rows[i].Cells[j].Value;
                    }
                }
                File.AppendAllText(openFilePath, str + Environment.NewLine, Encoding.GetEncoding(1251)); // буквы Русские
                str = "";
            }
            Filter();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
