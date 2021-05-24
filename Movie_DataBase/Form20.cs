using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form20 : Form
    {
        SqlConnection myConn = new SqlConnection();

        string numberDogovor;
        string numberStaff;
        string numberFilm;
        string numberProkatchik;
        string dateDogovor;
        string dateProkat;
        string week;
        string costDogovor;

        public Form20(string numberDogovor, string numberStaff, string numberFilm, 
            string numberProkatchik, string dateDogovor, 
            string dateProkat, string week, string costDogovor)
        {
            InitializeComponent();
            // задание значения параметрам
            this.numberDogovor = numberDogovor;
            this.numberStaff = numberStaff;
            this.numberFilm = numberFilm;
            this.numberProkatchik = numberProkatchik;
            this.dateDogovor = dateDogovor;
            this.dateProkat = dateProkat;
            this.week = week;
            this.costDogovor = costDogovor;
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Запускаем процедуру выборки данных
            loadData1();
            loadData2();
            loadData3();

            textBox1.Text = numberDogovor;
            textBox2.Text = numberStaff;
            textBox3.Text = numberFilm;
            textBox4.Text = numberProkatchik;
            textBox5.Text = dateDogovor;
            textBox6.Text = dateProkat;
            textBox7.Text = week;
            textBox8.Text = costDogovor;
        }

        private void loadData1()
        {
            SqlCommand myComm = new SqlCommand("select*from dbo.Фильм WHERE idФильм = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberFilm;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void loadData2()
        {
            SqlCommand myComm = new SqlCommand("select*from dbo.Сотрудник WHERE idСотрудник = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberStaff;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView2.AutoGenerateColumns = false; dataGridView2.DataSource = dt; dataGridView2.Refresh();
        }

        private void loadData3()
        {
            SqlCommand myComm = new SqlCommand("select*from dbo.Прокатчик WHERE idПрокатчик = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberProkatchik;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView3.AutoGenerateColumns = false; dataGridView3.DataSource = dt; dataGridView3.Refresh();
        }
    }
}
