using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form3 : Form {
        SqlConnection myConn = new SqlConnection(); 
        int indexSelectRow;

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Открываем соединение
            Program.openConnection(myConn);

            // Запускаем процедуру выборки данных
            loadData();
        }

        private void loadData() {
            // Создаем команду для выборки данных
            SqlCommand myComm = new SqlCommand("select*from dbo.Прокатчик", myConn); 
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader); 
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            indexSelectRow = e.RowIndex;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e) {
            myConn.Close();
            Application.Exit();
        }

        private void изменениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
                string numberGenre = SelectedRow.Cells[0].Value.ToString();
                string nameGenre = SelectedRow.Cells[1].Value.ToString();

                Form7 form7 = new Form7(myConn, numberGenre, nameGenre);
                form7.ShowDialog();

                //обновить таблицу на форме
                loadData();

            }
            catch { MessageBox.Show("Возникла непредвиденная ошибка при изменении поля", "Внимание!"); }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о прокатчике. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("execute delete_prokatchik @p1", myConn);

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
            catch { MessageBox.Show("Почему-то вызвалось исключение. Выполните двойной щелчок по названию прокатчика", "Внимание!"); }

        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(myConn);
            form4.ShowDialog();

            loadData();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Program.returnToStartForm();
            Close();
        }
    }
}
