using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form23 : Form
    {
        SqlConnection myConn = new SqlConnection();

        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;

            // Заполняем объект типа ComboBox
            loadData1ComboBox();
            loadData2ComboBox();
            loadData3ComboBox();
            loadData4ComboBox();
        }

        private void loadData1ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ФИО from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox1.DisplayMember = "ФИО";
            comboBox1.DataSource = dtbl;
        }

        private void loadData2ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Фильм", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox2.DisplayMember = "Название";
            comboBox2.DataSource = dtbl;
        }

        private void loadData3ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Прокатчик", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox3.DisplayMember = "Название";
            comboBox3.DataSource = dtbl;
        }

        private void loadData4ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Должность from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox8.DisplayMember = "Должность";
            comboBox8.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Можно добавить бросание исключений на количество недель и даты
            try
            {
                string nameStaff = comboBox1.Text;
                string nameFilm = comboBox2.Text;
                string nameDistrib = comboBox3.Text;
                string dateDogovor = dateTimePicker4.Text;
                string dateProkat = dateTimePicker5.Text;
                string week = textBox6.Text;
                string cost = textBox7.Text;

                string post = comboBox8.Text;
                string phone = textBox9.Text;
                string description = textBox10.Text;
                string length = textBox11.Text;

                myConn.Open();

                // Остальные поля могут иметь значение NULL
                if (nameStaff.Trim() == "" || nameFilm.Trim() == "" ||
                    nameDistrib.Trim() == "" || cost.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand(
                    "execute add_prokat_distrib_film_staff " +
                    "@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.Date);
                myComm.Parameters["@p1"].Value = dateDogovor;

                myComm.Parameters.Add("@p2", SqlDbType.Date);
                myComm.Parameters["@p2"].Value = dateProkat;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = week;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = cost;

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = nameDistrib;

                myComm.Parameters.Add("@p6", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p6"].Value = nameFilm;

                myComm.Parameters.Add("@p7", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p7"].Value = nameStaff;

                myComm.Parameters.Add("@p8", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p8"].Value = description;

                myComm.Parameters.Add("@p9", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p9"].Value = length;

                myComm.Parameters.Add("@p10", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p10"].Value = post;

                myComm.Parameters.Add("@p11", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p11"].Value = phone;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь добавить пустую строку.", "Внимание!");
            }
        }
    }
}
