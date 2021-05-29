using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form19 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select*from Прокат_фильма");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Выборка создания и заполнения в DataSet таблицы
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Прокат_фильма");

            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Прокат_фильма"];
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }
        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConn.Close();
            Application.Exit();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Прокат_фильма"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о договоре. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { MessageBox.Show("Почему-то вызвалось исключение", "Внимание!"); }
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
            string numberDogovor = SelectedRow.Cells[0].Value.ToString();
            string numberStaff = SelectedRow.Cells[1].Value.ToString();
            string numberFilm = SelectedRow.Cells[2].Value.ToString();
            string numberProkatchik = SelectedRow.Cells[3].Value.ToString();
            string dateDogovor = SelectedRow.Cells[4].Value.ToString();
            string dateProkat = SelectedRow.Cells[5].Value.ToString();
            string week = SelectedRow.Cells[6].Value.ToString();
            string cost = SelectedRow.Cells[7].Value.ToString();

            Form20 form20 = new Form20(numberDogovor, numberStaff, numberFilm, numberProkatchik, dateDogovor, dateProkat, week, cost);
            form20.ShowDialog();
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Прокат_фильма"]);
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n" +
                " 1. Необходимо заполнить добавленную строку.\n\n" +
                " 2. Какой-либо из номеров отсутствует в базе данных.", "Внимание!");
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }
    }
}
