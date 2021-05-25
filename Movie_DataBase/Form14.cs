using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form14 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string nameFilm, nameGenre, numberFilm, numberGenre;

        public Form14(string numberFilm, string numberGenre)
        {
            InitializeComponent();
            this.numberFilm = numberFilm;
            this.numberGenre = numberGenre;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();
            // Запускаем процедуру выборки данных

            loadData1();
            loadData2();

            textBox1.Text = numberFilm;
            textBox2.Text = numberGenre;
        }

        private void loadData1()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм where idФильм = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void loadData2()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select*from dbo.Жанр where idЖанр = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberGenre;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView2.AutoGenerateColumns = false; dataGridView2.DataSource = dt; dataGridView2.Refresh();
        }
    }
}
