using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form5 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;

        public Form5() {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e) {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Запускаем процедуру выборки данных
            loadData();
        }

        private void loadData() {
            // Создаем команду для выборки данных
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм", myConn);
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            indexSelectRow = e.RowIndex;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e) {
            myConn.Close();
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
                DialogResult result = MessageBox.Show("Будет удалена вся информация о фильме. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("delete dbo.Фильм where idФильм = @p1", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
                    DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
                    myComm.Parameters["@p1"].Value = SelectedRow.Cells[0].Value.ToString();

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteNonQuery();

                    // Обновить таблицу на форме
                    loadData();
                }
            }
            catch { }
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
            string numberFilm = SelectedRow.Cells[0].Value.ToString();
            string nameFilm = SelectedRow.Cells[1].Value.ToString();
            string description = SelectedRow.Cells[2].Value.ToString();
            string howmuch = SelectedRow.Cells[3].Value.ToString();

            Form6 form6 = new Form6(myConn, numberFilm, nameFilm, description, howmuch);
            form6.ShowDialog();

            loadData();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(myConn);
            form8.ShowDialog();

            loadData();
        }

    }
}
