using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form21 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select*from Расписание");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            //Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            //Выборка создания и заполнения в DataSet таблицы с жанрами
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Расписание");

            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Расписание"];
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }
        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConn.Close();
            Application.Exit();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Расписание"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о расписании. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
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

            string numberTiming = SelectedRow.Cells[0].Value.ToString(), 
                numberDogovor = SelectedRow.Cells[1].Value.ToString(), 
                numberHall = SelectedRow.Cells[2].Value.ToString(),
                numberStaff = SelectedRow.Cells[3].Value.ToString(),
                dateD = SelectedRow.Cells[4].Value.ToString(), 
                costDogovor = SelectedRow.Cells[5].Value.ToString();

            Form22 form22 = new Form22(numberTiming, numberDogovor, numberHall, numberStaff,dateD, costDogovor);
            form22.ShowDialog();
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Расписание"]);
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n" +
                " 1. Необходимо заполнить добавленную строку.\n\n" +
                " 2. Какой-либо из номеров отсутствует в базе данных.", "Внимание!");
            }
        }
    }
}
