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
    public partial class Form6 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberFilm, nameFilm, description, howmuch;

        public Form6(string numberFilm, string nameFilm, string description, string howmuch) {
            InitializeComponent();
            // задание значения параметрам
            this.numberFilm = numberFilm;
            this.nameFilm = nameFilm;
            this.description = description;
            this.howmuch = howmuch;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();
            //Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();
            //Запускаем процедуру выборки данных
            loadData1();
            loadData2();
            loadData3();

            text1.Text = numberFilm;
            text2.Text = nameFilm;
            text3.Text = description;
            text4.Text = howmuch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text2.Text.Trim() == "" || text3.Text.Trim() == "" || text4.Text.Trim() == "") throw new Exception();

                // Создать команду для удаления
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

                // Выполнить запрос на удаление без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Возможно вы ввели пустую строку", "Внимание!"); }
        }

        private void loadData1()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select*from dbo.Режиссер where Фильм_idФильм = @p1", myConn);
            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;

            SqlDataReader myReader = myComm.ExecuteReader();
            //Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void loadData2()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select Жанр, idЖанр from dbo.Жанр join dbo.Фильм_has_Жанр ON Жанр.idЖанр = Фильм_has_Жанр.Жанр_idЖанр where Фильм_idФильм = @p1", myConn);
            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;

            SqlDataReader myReader = myComm.ExecuteReader();
            //Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView2.AutoGenerateColumns = false; dataGridView2.DataSource = dt; dataGridView2.Refresh();
        }

        private void loadData3()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм_has_Жанр where Фильм_idФильм = @p1", myConn);
            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
            myComm.Parameters["@p1"].Value = numberFilm;

            SqlDataReader myReader = myComm.ExecuteReader();
            //Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView3.AutoGenerateColumns = false; dataGridView3.DataSource = dt; dataGridView3.Refresh();
        }
    }
}
