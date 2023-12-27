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

        private void buttonDelete_SDV_Click(object sender, EventArgs e)
        {
            string[] tempArray = new string[dataGridViewTable_SDV.SelectedRows.Count];
            int cnt = 0;
            foreach (DataGridViewRow item in this.dataGridViewTable_SDV.SelectedRows)
            {
                tempArray[cnt] = Convert.ToString(dataGridViewTable_SDV.Rows[item.Index].Cells[0].Value);
                dataGridViewTable_SDV.Rows.RemoveAt(item.Index);
                cnt++;
            }
            UpdateTable();

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < tempArray.GetLength(0); j++)
                {
                    try
                    {
                        if (Convert.ToString(dataGridViewTable_SDV.Rows[i].Cells[0].Value) == tempArray[j])
                        {
                            dataGridViewTable_SDV.Rows.RemoveAt(i);
                            rows--;
                        }
                    }
                    catch
                    {
                        if (Convert.ToString(dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[0].Value) == tempArray[j])
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

        private void Filter()
        {
            dataGridViewTable_SDV.Rows.Clear();
            for (int i = 0; i < rows; i++)
            {

                try
                {
                    if ((Convert.ToInt32(arrayValues[i, 5]) >= Convert.ToInt32(filters[0]) || string.IsNullOrWhiteSpace(filters[0]) || Convert.ToInt32(filters[0]) == 0) && (Convert.ToInt32(arrayValues[i, 5]) <= Convert.ToInt32(filters[1]) || string.IsNullOrWhiteSpace(filters[1]) || Convert.ToInt32(filters[1]) == 0) && (arrayValues[i, 4] == filters[3] || string.IsNullOrWhiteSpace(filters[3])))
                    {



                        dataGridViewTable_SDV.Rows.Add(arrayValues[i, 0]);
                        for (int k = 1; k < columns; k++)
                        {
                            dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.RowCount - 1].Cells[k].Value = arrayValues[i, k];
                        }




                    }
                }

                catch
                {
                    dataGridViewTable_SDV.Rows.Add(arrayValues[i, 0]);
                    for (int k = 1; k < columns; k++)
                    {
                        dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.RowCount - 1].Cells[k].Value = arrayValues[i, k];
                    }
                }

            }
        }

        private void UpdateTable()
        {
            dataGridViewTable_SDV.Rows.Clear();
            for (int r = 0; r < rows; r++)
            {
                dataGridViewTable_SDV.Rows.Add();
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewTable_SDV.Rows[r].Cells[c].Value = arrayValues[r, c];
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
                dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[i].Value = "";
            }

            for (int i = 0; i < rows - 1; i++)
            {
                newID = Math.Max(Convert.ToInt32(arrayValues[i, 0]), newID);
            }
            newID++;
            dataGridViewTable_SDV.Rows[dataGridViewTable_SDV.Rows.Count - 1].Cells[0].Value = Convert.ToString(newID);
            string[,] tempValues = arrayValues;
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
            textBoxAmountPeople_SDV.Text = Convert.ToString(ds.People(arrayValues));
        }

        private void buttonResetFilters_SDV_Click(object sender, EventArgs e)
        {
            comboBoxPos_KMA.Text = string.Empty;
            numericUpDownMinDohod_SDV.Value = 0;
            numericUpDownMaxDohod_SDV.Value = 0;
            UpdateTable();
        }

        private void файликиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemNewTable_SDV_Click(object sender, EventArgs e)
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
            comboBoxPos_KMA.Text = string.Empty;
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

        private string[,] LoadFromFileData(string filePath)
        {
            try
            {
                string fileData = File.ReadAllText(filePath, Encoding.GetEncoding(1251));
                fileData = fileData.Replace("\n", "\r");
                string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    rows = lines.Length;
                    columns = lines[0].Split(';').Length;

                    arrayValues = new string[rows, columns];

                    for (int r = 0; r < rows; r++)
                    {
                        string[] line_r = lines[r].Split(';');
                        for (int c = 0; c < columns; c++)
                        {
                            arrayValues[r, c] = line_r[c];
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialogSaveTo_SDV_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
