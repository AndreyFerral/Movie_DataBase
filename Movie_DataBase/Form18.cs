using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form18 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberRyad, numberMesto, numberTiming;

        public Form18(string numberRyad, string numberMesto, string numberTiming)
        {
            InitializeComponent();
            this.numberRyad = numberRyad;
            this.numberMesto = numberMesto;
            this.numberTiming = numberTiming;
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            // Запускаем процедуру выборки данных
            loadData();

            textBox1.Text = numberRyad;
            textBox2.Text = numberMesto;
            textBox3.Text = numberTiming;
        }

        private void loadData()
        {
            // Создать команду для удаления
            SqlCommand myComm = new SqlCommand("select*from dbo.Расписание WHERE idРасписание = @p1", myConn);

            // Создать параметр и передать в него значение текстового поля 
            myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
            myComm.Parameters["@p1"].Value = numberTiming;
            SqlDataReader myReader = myComm.ExecuteReader();

            // Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader);
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }
    }
}
