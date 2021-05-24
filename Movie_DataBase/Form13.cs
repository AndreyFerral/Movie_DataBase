using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form13 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select*from Фильм_has_Жанр");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            //Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            //Выборка создания и заполнения в DataSet таблицы с жанрами
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Фильм_has_Жанр");

            // dataGridView1.Columns[0].ReadOnly = true; // не надо блокировать id
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Фильм_has_Жанр"];
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



        private void добавлениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ds.Tables["Фильм_has_Жанр"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о связи. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { MessageBox.Show("Почему-то вызвалось исключение", "Внимание!"); }
        }

        private void сохранениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Фильм_has_Жанр"]);
            }
            catch { 
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                "1. Необходимо заполнить добавленную строку.\n\n " +
                "2. Необходимо ввести корректный номер фильма и/или жанра.", "Внимание!"); 
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
            string numberGenre = SelectedRow.Cells[0].Value.ToString();
            string numberFilm = SelectedRow.Cells[1].Value.ToString();

            Form14 form14 = new Form14(numberFilm, numberGenre);
            form14.ShowDialog();
        }
    }
}
