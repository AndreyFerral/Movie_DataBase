using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form21 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        
        string curNumberTiming, curNumberDogovor, curNameHall, 
            curNameStaff, curDateTime, curCost;
        

        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;

            // Заполняем объект типа ComboBox
            loadData1ComboBox();
            loadData2ComboBox();
            loadData3ComboBox();

            // Запускаем процедуру выборки данных
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Для того, чтобы не обновлялись значения, если нажатия происходит в одной строке
            if (e.RowIndex != indexSelectRow)
            {
                indexSelectRow = e.RowIndex;

                curNumberTiming = dataGridView1[0, indexSelectRow].Value.ToString();
                curNumberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
                curNameHall = dataGridView1[2, indexSelectRow].Value.ToString();
                curNameStaff = dataGridView1[3, indexSelectRow].Value.ToString();
                curDateTime = dataGridView1[4, indexSelectRow].Value.ToString();
                curCost = dataGridView1[5, indexSelectRow].Value.ToString();
                
            }
        }
        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (curNumberTiming.Trim() == "" || curNumberDogovor.Trim() == "" ||
                    curNameHall.Trim() == "" || curNameStaff.Trim() == "" ||
                    curDateTime.Trim() == "" || curCost.Trim() == "") throw new Exception();

                Form22 form22 = new Form22(curNumberTiming, curNumberDogovor, curNameHall,
                    curNameStaff, curDateTime, curCost);
                form22.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь посмотреть информацию о несуществующих данных.", "Внимание!");
            }
        }

        private void loadData1ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select ФИО from Сотрудник", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            staff_name.DisplayMember = "ФИО";
            staff_name.DataSource = dtbl;

            myConn.Close();
        }
        private void loadData2ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Зал", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            hall_name.DisplayMember = "Название";
            hall_name.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData3ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Номер_договора from Прокат_фильма", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dogovor_number.DisplayMember = "Номер_договора";
            dogovor_number.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData()
        {
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select idРасписание, Номер_договора, ФИО, Название, Дата_время, Стоимость from dbo.View_Timing", myConn);

            SqlDataReader myReader = myComm.ExecuteReader();
            DataTable dtbl = new DataTable(); dtbl.Load(myReader);
            dataGridView1.DataSource = dtbl;
            myConn.Close();

            indexSelectRow = 0;

            curNumberTiming = dataGridView1[0, indexSelectRow].Value.ToString();
            curNumberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
            curNameHall = dataGridView1[2, indexSelectRow].Value.ToString();
            curNameStaff = dataGridView1[3, indexSelectRow].Value.ToString();
            curDateTime = dataGridView1[4, indexSelectRow].Value.ToString();
            curCost = dataGridView1[5, indexSelectRow].Value.ToString();
        }
    }
}
