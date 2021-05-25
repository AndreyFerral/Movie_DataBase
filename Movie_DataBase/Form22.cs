using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form22 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberTiming, numberDogovor, numberHall,
            numberStaff, dateD, costDogovor;

        public Form22(string numberTiming, string numberDogovor, string numberHall,
            string numberStaff, string dateD, string costDogovor)
        {
            InitializeComponent();
            this.numberTiming = numberTiming;
            this.numberDogovor = numberDogovor;
            this.numberHall = numberHall;
            this.numberStaff = numberStaff;
            this.dateD = dateD;
            this.costDogovor = costDogovor;
        }

        private void Form22_Load(object sender, EventArgs e)
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

            textBox1.Text = numberTiming;
            textBox2.Text = numberDogovor;
            textBox3.Text = numberHall;
            textBox4.Text = numberStaff;
            textBox5.Text = dateD;
            textBox6.Text = costDogovor;
        }
        private void loadData1()
        {
            SqlCommand myComm = new SqlCommand("select*from dbo.View_Dogovor WHERE Номер_Договора = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberDogovor;
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
            SqlCommand myComm = new SqlCommand("select*from dbo.Зал WHERE idЗал = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberHall;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView3.AutoGenerateColumns = false; dataGridView3.DataSource = dt; dataGridView3.Refresh();
        }
    }
}
