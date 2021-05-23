using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form3 : Form {
        SqlConnection myConn = new SqlConnection(); 
        int indexSelectRow;

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();
            //Создаем подключение 
            myConn.ConnectionString = StrConn; 
            myConn.Open();
            //Запускаем процедуру выборки данных
            loadData();

        }



        private void loadData() {
            //Создаем команду для выборки данных
            SqlCommand myComm = new SqlCommand("select * from Прокатчик", myConn); 
            SqlDataReader myReader = myComm.ExecuteReader();
            //Заполняем данными
            DataTable dt = new DataTable(); dt.Load(myReader); 
            dataGridView1.AutoGenerateColumns = false; dataGridView1.DataSource = dt; dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            indexSelectRow = e.RowIndex;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e) {
            myConn.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}
