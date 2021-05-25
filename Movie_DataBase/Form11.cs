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
    public partial class Form11 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberFilm, nameFilmMaker;

        public Form11(string numberFilm, string nameFilmMaker)
        {
            InitializeComponent();
            this.numberFilm = numberFilm;
            this.nameFilmMaker = nameFilmMaker;
        }

        private void Form11_Load(object sender, EventArgs e)
        {

            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Запускаем процедуру выборки данных
            loadData();

            text2.Text = nameFilmMaker;
        }

        private void loadData()
        {
            // Создать команду для выборки
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм join dbo.Режиссер ON Фильм.idФильм = Режиссер.Фильм_idФильм WHERE Режиссер = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = nameFilmMaker;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }
    }
}
