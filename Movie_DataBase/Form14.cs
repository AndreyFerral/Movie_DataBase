using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form14 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string nameFilm, nameGenre;

        public Form14(string nameFilm, string nameGenre)
        {
            InitializeComponent();
            this.nameFilm = nameFilm;
            this.nameGenre = nameGenre;
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

            textBox1.Text = nameFilm;
            textBox2.Text = nameGenre;
        }

        private void loadData1()
        {
            // Создать команду для выборки
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм where Название = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = nameFilm;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void loadData2()
        {
            // Создать команду для выборки
            SqlCommand myComm = new SqlCommand("select*from dbo.Жанр where Жанр = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = nameGenre;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView2.AutoGenerateColumns = false; dataGridView2.DataSource = dt; dataGridView2.Refresh();
        }
    }
}
