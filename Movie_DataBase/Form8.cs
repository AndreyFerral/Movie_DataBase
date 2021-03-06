using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form8 : Form
    {
        SqlConnection myConn;
        public Form8(SqlConnection myConn)
        {
            InitializeComponent();
            this.myConn = myConn;
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            loadData1ComboBox();
            loadData2ComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text.Trim() == "" || text2.Text.Trim() == "" || 
                    text3.Text.Trim() == "" || comboBox4.Text.Trim() == "" ||
                    comboBox5.Text.Trim() == "") throw new Exception();

                // Создать команду для добавления
                SqlCommand myComm = new SqlCommand("execute add_film_filmm_genre @p1, @p2, @p3, @p4, @p5", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = text1.Text.ToString();

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = text2.Text.ToString();

                myComm.Parameters.Add("@p3", SqlDbType.Int);
                myComm.Parameters["@p3"].Value = text3.Text.ToString();

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = comboBox4.Text.ToString();

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = comboBox5.Text.ToString();

                // Вызвать процедуру без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                "1. Все поля должны быть заполнены.\n\n " +
                "2. Длительность фильма должна быть от 15 до 240 минут.", "Внимание!");
            }
        }

        private void loadData1ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct Режиссер from Режиссер", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox4.DisplayMember = "Режиссер";
            comboBox4.DataSource = dtbl;
        }

        private void loadData2ComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Жанр", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox5.DisplayMember = "Жанр";
            comboBox5.DataSource = dtbl;
        }
    }
}
