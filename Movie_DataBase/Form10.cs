using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form10 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select Фильм_idФильм, Режиссер from Режиссер");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Выборка создания и заполнения в DataSet таблицы
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Режиссер");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Режиссер"];
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
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

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о режиссере. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { MessageBox.Show("Почему-то вызвалось исключение. Выполните двойной щелчок по названию жанра", "Внимание!"); }
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Режиссер"].Rows.Add();
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Режиссер"]);
            }
            catch { MessageBox.Show("Ошибка. Возможное решение:\n\n 1. Необходимо заполнить добавленную строку.\n\n 2. Необходимо ввести корректный номер фильма.", "Внимание!"); }
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
            string numberFilm = SelectedRow.Cells[0].Value.ToString();
            string nameFilmMaker = SelectedRow.Cells[1].Value.ToString();

            Form11 form11 = new Form11(numberFilm, nameFilmMaker);
            form11.ShowDialog();
        }
    }
}
