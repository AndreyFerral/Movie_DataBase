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
        string currentNameFilm, currentNameFilmGenre;

        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;

            // Заполняем объект типа ComboBox
            loadData1ComboBox();
            loadData2ComboBox();
            
            // Запускаем процедуру выборки данных
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Для того, чтобы не обновлялись значения, если нажатия происходит в одной строке
            if (e.RowIndex != indexSelectRow && e.RowIndex != -1)
            {
                indexSelectRow = e.RowIndex;
                currentNameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                currentNameFilmGenre = dataGridView1[1, indexSelectRow].Value.ToString();
            }
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void добавлениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                indexSelectRow = dataGridView1.Rows.Count - 2;
                string nameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                string nameFilmGenre = dataGridView1[1, indexSelectRow].Value.ToString();

                myConn.Open();
                if (nameFilm.Trim() == "" || nameFilmGenre.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("execute add_filmhasgenre @p1, @p2", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = nameFilm;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = nameFilmGenre;

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

        private void удалениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    myConn.Open();
                    if (currentNameFilm == "" || currentNameFilmGenre == "") throw new Exception();

                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("execute del_filmhasgenre @p1, @p2", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p1"].Value = currentNameFilm;
                    myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p2"].Value = currentNameFilmGenre;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData();
                }
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь удалить пустую строку.", "Внимание!");
            }
        }

        private void сохранениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nameFilm = dataGridView1[0, indexSelectRow].Value.ToString();
                string NameFilmGenre = dataGridView1[1, indexSelectRow].Value.ToString();

                myConn.Open();
                if (nameFilm.Trim() == "" || NameFilmGenre.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("EXECUTE [dbo].[update_filmhasgenre] @p1, @p2, @p3, @p4", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = currentNameFilm;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = currentNameFilmGenre;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = nameFilm;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = NameFilmGenre;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь редактировать пустую строку.", "Внимание!");
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
            try {
                if (currentNameFilm.Trim() == "" || currentNameFilmGenre.Trim() == "") throw new Exception();

                Form14 form14 = new Form14(currentNameFilm, currentNameFilmGenre);
                form14.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь посмотреть информацию о несуществующих данных.", "Внимание!");
            }
        }

        private void loadData1ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Фильм", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            film_name.DisplayMember = "Название";
            film_name.DataSource = dtbl;

            myConn.Close();
        }
        private void loadData2ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Жанр from Жанр", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            film_genre.DisplayMember = "Жанр";
            film_genre.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData()
        {
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select Название, Жанр from dbo.View_FilmGenre", myConn);

            SqlDataReader myReader = myComm.ExecuteReader();
            DataTable dtbl = new DataTable(); dtbl.Load(myReader);
            dataGridView1.DataSource = dtbl;
            myConn.Close();

            indexSelectRow = 0;
            currentNameFilmGenre = dataGridView1[0, indexSelectRow].Value.ToString();
            currentNameFilm = dataGridView1[1, indexSelectRow].Value.ToString();
        }
    }
}
