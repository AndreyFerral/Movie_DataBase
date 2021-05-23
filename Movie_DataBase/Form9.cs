using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form9 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();
            //Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();
            //Запускаем процедуру выборки данных
            loadData();
        }

        private void loadData()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select* from dbo.Жанр", myConn);
            // Создать параметр и передать в него значение текстового поля 
            SqlDataReader myReader = myComm.ExecuteReader();
            //Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                DialogResult result = MessageBox.Show("Будет удалена вся информация о жанре. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("delete dbo.Жанр where idЖанр = @p1", myConn);
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
            catch { MessageBox.Show("Почему-то вызвалось исключение. Выполните двойной щелчок по названию жанра", "Внимание!"); }
        }

        private void изменениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
                string numberGenre = SelectedRow.Cells[0].Value.ToString();
                string nameGenre = SelectedRow.Cells[1].Value.ToString();

                Form10 form10 = new Form10(myConn, numberGenre, nameGenre);
                form10.ShowDialog();

                //обновить таблицу на форме
                loadData();

            }
            catch { MessageBox.Show("Возникла непредвиденная ошибка при изменении поля", "Внимание!"); }
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(myConn);
            form11.ShowDialog();
            //обновить таблицу на форме
            loadData();
        }
    }
}
