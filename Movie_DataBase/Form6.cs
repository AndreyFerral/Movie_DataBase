using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form6 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberFilm, nameFilm, description, howmuch;
        // SqlDataReader myReader = null;

        int indexDelUp1, indexInsert1; // Режиссер
        int indexDelUp2, indexInsert2; // Жанр

        public Form6(SqlConnection myConn, string numberFilm, string nameFilm, string description, string howmuch)
        {
            InitializeComponent();
            // this.myConn = myConn;
            this.numberFilm = numberFilm;
            this.nameFilm = nameFilm;
            this.description = description;
            this.howmuch = howmuch;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;

            // Заполняем объект типа ComboBox
            loadData1ComboBox();
            loadData2ComboBox();

            // Запускаем процедуру выборки данных
            loadData1();
            loadData2();

            // Устанавливаем значения полям
            text1.Text = numberFilm;
            text2.Text = nameFilm;
            text3.Text = description;
            text4.Text = howmuch;

        }



        // получаем индекс нажатой ячейки
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDelUp1 = e.RowIndex;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDelUp2 = e.RowIndex;
        }

        // Измененные данных фильма
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text2.Text.Trim() == "" || text3.Text.Trim() == "" || text4.Text.Trim() == "") throw new Exception();

                // Создать команду для изменения
                myConn.Open();
                SqlCommand myComm = new SqlCommand("UPDATE dbo.Фильм SET Название = @p1, Описание = @p2, Длительность = @p3 where idФильм = @p4", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = text2.Text;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = text3.Text;

                myComm.Parameters.Add("@p3", SqlDbType.Int);
                myComm.Parameters["@p3"].Value = text4.Text;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 10);
                myComm.Parameters["@p4"].Value = numberFilm;

                if (Int32.Parse(text4.Text) < 15 || Int32.Parse(text4.Text) > 240) { myConn.Close(); }
                
                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();            
            }
            catch {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Необходимо заполнить добавленную строку.\n\n " +
                                "2. Длительность фильма должна быть от 15 до 240 минут.", "Внимание!");
            }
        }

        // Добавление режиссера к фильму
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                indexInsert1 = dataGridView1.Rows.Count - 2;
                string nameFilmMaker = dataGridView1[0, indexInsert1].Value.ToString();

                // Создать команду для изменения
                myConn.Open();
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
                loadData1();
            }
            catch { MessageBox.Show("Необходимо заполнить добавленную строку!", "Внимание!"); }
        }


        // Удаление режиссера от фильма
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация о режиссере фильма будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (indexDelUp1 > dataGridView1.Rows.Count - 2) throw new Exception();
                    string nameFilmMaker = dataGridView1[0, indexDelUp1].Value.ToString();

                    // Создать команду для удаления
                    myConn.Open();
                    SqlCommand myComm = new SqlCommand("delete from dbo.Режиссер where Фильм_idФильм = @p1 and Режиссер.Режиссер = @p2", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
                    myComm.Parameters["@p1"].Value = numberFilm;
                    myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p2"].Value = nameFilmMaker;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData1();
                }
            }
            catch { MessageBox.Show("Вы пытаетесь удалить пустую строку", "Внимание!"); }
        }

        // Добавление жанра к фильму
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                indexInsert2 = dataGridView2.Rows.Count - 2;
                string nameGenre = dataGridView2[0, indexInsert2].Value.ToString();

                // Создать команду для изменения
                myConn.Open();
                SqlCommand myComm = new SqlCommand("execute add_filmhasgenre @p1, @p2", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = nameFilm;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = nameGenre;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData2();
            }
            catch { MessageBox.Show("Необходимо заполнить добавленную строку!", "Внимание!"); }

        }

        // Удаление связи между жанром и фильмом
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация о жанре фильма будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (indexDelUp2 > dataGridView2.Rows.Count - 2) throw new Exception();
                    string nameGenre = dataGridView2[0, indexDelUp2].Value.ToString();

                    // Создать команду для удаления
                    myConn.Open();
                    SqlCommand myComm = new SqlCommand("execute del_filmhasgenre @p1, @p2", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p1"].Value = nameFilm;
                    myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p2"].Value = nameGenre;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData2();
                }
            }
            catch { MessageBox.Show("Вы пытаетесь удалить пустую строку", "Внимание!"); }
        }


        private void loadData1ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct Режиссер from Режиссер", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            FilmMaker.DisplayMember = "Режиссер";
            FilmMaker.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData2ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Жанр", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            FilmGenre.DisplayMember = "Жанр";
            FilmGenre.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData1() {
            indexDelUp1 = 0;

            myConn.Open();
            SqlCommand myComm = new SqlCommand("select Режиссер from dbo.Режиссер where Фильм_idФильм = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;
            SqlDataReader myReader = myComm.ExecuteReader();

            DataTable dtbl = new DataTable(); dtbl.Load(myReader);
            dataGridView1.DataSource = dtbl;
            myConn.Close();
        }

        private void loadData2()
        {
            indexDelUp2 = 0;

            // Создать команду для выборки
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select Жанр from dbo.View_FilmGenre where Фильм_idФильм = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;
            SqlDataReader myReader = myComm.ExecuteReader();

            DataTable dtbl = new DataTable(); dtbl.Load(myReader);
            dataGridView2.DataSource = dtbl;
            myConn.Close();
        }
    }
}
