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
        string currentNameFilm, currentNameFilmMaker;

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

            loadDataComboBox(); // Заполняем объект типа ComboBox
            loadData();         // Запускаем процедуру выборки данных
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Для того, чтобы не обновлялись значения, если нажатия происходит в одной строке
            if (e.RowIndex != indexSelectRow && e.RowIndex != -1)
            {
                indexSelectRow = e.RowIndex;
                currentNameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                currentNameFilmMaker = dataGridView1[1, indexSelectRow].Value.ToString();
            }
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            try
            {
                indexSelectRow = dataGridView1.Rows.Count - 2;
                string nameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                string nameFilmMaker = dataGridView1[1, indexSelectRow].Value.ToString();

                myConn.Open();
                if (nameFilm.Trim() == "" || nameFilmMaker.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("EXECUTE [add_filmmaker] @p1, @p2", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = nameFilmMaker;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = nameFilm;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь добавить пустую строку.", "Внимание!");
            }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация о режиссере фильма будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    myConn.Open();
                    if (currentNameFilm == "" || currentNameFilmMaker == "") throw new Exception();

                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("EXECUTE [dbo].[delete_filmmaker] @p1, @p2", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p1"].Value = currentNameFilmMaker;
                    myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p2"].Value = currentNameFilm;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData();
                }
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь удалить пустую строку.", "Внимание!");
            }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string nameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                string nameFilmMaker = dataGridView1[1, indexSelectRow].Value.ToString();

                myConn.Open();
                if (nameFilm.Trim() == "" || nameFilmMaker.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("EXECUTE [dbo].[update_filmmaker] @p1, @p2, @p3, @p4", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = currentNameFilmMaker;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = currentNameFilm;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = nameFilmMaker;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = nameFilm;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь редактировать пустую строку.", "Внимание!");
            }
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
                string nameFilm = SelectedRow.Cells[0].Value.ToString();
                string nameFilmMaker = SelectedRow.Cells[1].Value.ToString();
                if (nameFilm.Trim() == "" || nameFilmMaker.Trim() == "") throw new Exception();

                Form11 form11 = new Form11(nameFilmMaker);
                form11.ShowDialog();
            }
            catch {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь посмотреть информацию о несуществующих данных.", "Внимание!");
            }
        }
        
        private void loadDataComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Фильм", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            film_name.DisplayMember = "Название";
            film_name.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData()
        {
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select Название, Режиссер from dbo.View_FilmMaker", myConn);

            SqlDataReader myReader = myComm.ExecuteReader();
            DataTable dtbl = new DataTable(); dtbl.Load(myReader);
            dataGridView1.DataSource = dtbl;
            myConn.Close();

            indexSelectRow = 0;
            currentNameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
            currentNameFilmMaker = dataGridView1[1, indexSelectRow].Value.ToString();
        }
    }
}
