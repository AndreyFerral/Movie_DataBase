using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form24 : Form
    {
        SqlConnection myConn = new SqlConnection();

        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;

            // Заполняем объект типа ComboBox
            NumberDogovorComboBox();
            NameHallComboBox();
            NameStaffTimingComboBox();
            NameStaffProkatComboBox();
            NamePostComboBox();
            NameFilmComboBox();
            NameDistribComboBox();

        }

        private void NumberDogovorComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Номер_договора from Прокат_фильма", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox1.DisplayMember = "Номер_договора";
            comboBox1.DataSource = dtbl;
        }

        private void NameHallComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Зал", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox2.DisplayMember = "Название";
            comboBox2.DataSource = dtbl;
        }

        private void NameStaffTimingComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ФИО from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox3.DisplayMember = "ФИО";
            comboBox3.DataSource = dtbl;
        }

        private void NameStaffProkatComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ФИО from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox6.DisplayMember = "ФИО";
            comboBox6.DataSource = dtbl;
        }

        private void NamePostComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Должность from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox13.DisplayMember = "Должность";
            comboBox13.DataSource = dtbl;
        }

        private void NameFilmComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Фильм", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox7.DisplayMember = "Название";
            comboBox7.DataSource = dtbl;
        }

        private void NameDistribComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Прокатчик", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            comboBox8.DisplayMember = "Название";
            comboBox8.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Можно добавить бросание исключений (=ограничения)
            try
            {
                // Расписание
                string numberDogovor = comboBox1.Text;
                string nameHall = comboBox2.Text;
                string nameStaffTiming = comboBox3.Text;
                string date = dateTimePicker1.Text;
                string time = dateTimePicker2.Text;
                string costTiming = textBox5.Text;

                // Прокат фильма
                string nameStaffProkat = comboBox6.Text;
                string nameFilm = comboBox7.Text;
                string nameDistrib = comboBox8.Text;
                string dateDogovor = dateTimePicker3.Text;
                string dateProkat = dateTimePicker4.Text;
                string week = textBox11.Text;
                string costProkat = textBox12.Text;

                // Сотрудник
                string post = comboBox13.Text;
                string phone = textBox14.Text;

                // Зал
                string ryad = textBox15.Text;
                string mesto = textBox16.Text;

                myConn.Open();

                // Остальные поля могут иметь значение NULL
                if (numberDogovor.Trim() == "" || nameHall.Trim() == "" ||
                    nameStaffTiming.Trim() == "" || date.Trim() == "" ||
                    time.Trim() == "" || costTiming.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand(
                    "execute add_timing @p1, @p2, @p3, @p4, @p5, @p6, " +
                    "@p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = numberDogovor;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = nameHall;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = nameStaffTiming;

                string dateTime = date + " " + time;
                DateTime myTime = DateTime.Parse(dateTime);
                dateTime = myTime.ToString("yyyy-MM-dd HH:mm:ss");
                myComm.Parameters.Add("@p4", SqlDbType.SmallDateTime);
                myComm.Parameters["@p4"].Value = dateTime;

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = costTiming;

                myComm.Parameters.Add("@p6", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p6"].Value = nameStaffProkat;

                myComm.Parameters.Add("@p7", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p7"].Value = nameFilm;

                myComm.Parameters.Add("@p8", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p8"].Value = nameDistrib;

                myComm.Parameters.Add("@p9", SqlDbType.Date);
                myComm.Parameters["@p9"].Value = dateDogovor;

                myComm.Parameters.Add("@p10", SqlDbType.Date);
                myComm.Parameters["@p10"].Value = dateProkat;

                myComm.Parameters.Add("@p11", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p11"].Value = week;

                myComm.Parameters.Add("@p12", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p12"].Value = costProkat;

                myComm.Parameters.Add("@p13", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p13"].Value = post;

                myComm.Parameters.Add("@p14", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p14"].Value = phone;

                myComm.Parameters.Add("@p15", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p15"].Value = ryad;

                myComm.Parameters.Add("@p16", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p16"].Value = mesto;

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
