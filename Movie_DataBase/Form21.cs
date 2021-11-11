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
            // Открываем соединение
            Program.openConnection(myConn);

            // Program.getCurrentUser(myConn);

            // Закрываем подключение, т.к. оно было открыто в пред функции
            myConn.Close();

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
            if (e.RowIndex != indexSelectRow && e.RowIndex != -1)
            {
                indexSelectRow = e.RowIndex;

                curNumberTiming = dataGridView1[0, indexSelectRow].Value.ToString();
                curNumberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
                curNameStaff = dataGridView1[2, indexSelectRow].Value.ToString();
                curNameHall = dataGridView1[3, indexSelectRow].Value.ToString();
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
            Program.returnToStartForm();
            Close();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Можно добавить бросание исключений на количество недель и даты

            try
            {
                indexSelectRow = dataGridView1.Rows.Count - 2;
                string numberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
                string nameStaff = dataGridView1[2, indexSelectRow].Value.ToString();
                string nameHall = dataGridView1[3, indexSelectRow].Value.ToString();
                string dateTime = dataGridView1[4, indexSelectRow].Value.ToString();
                string cost = dataGridView1[5, indexSelectRow].Value.ToString();

                myConn.Open();

                // Остальные поля могут иметь значение NULL
                if (numberDogovor.Trim() == "" || nameHall.Trim() == "" || nameStaff.Trim() == "" || 
                    dateTime.Trim() == "" || cost.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("EXECUTE add_timing @p1, @p2, @p3, @p4, @p5", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = numberDogovor;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = nameHall;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = nameStaff;

                DateTime myTime = DateTime.Parse(dateTime);
                dateTime = myTime.ToString("yyyy-MM-dd HH:mm:ss");
                myComm.Parameters.Add("@p4", SqlDbType.SmallDateTime);
                myComm.Parameters["@p4"].Value = dateTime;

                myComm.Parameters.Add("@p5", SqlDbType.Money);
                myComm.Parameters["@p5"].Value = cost;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь добавить пустую строку.", "Внимание!");
            }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация о расписании будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    myConn.Open();
                    if (curNumberTiming == "") throw new Exception();

                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("execute delete_timing @p1", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
                    myComm.Parameters["@p1"].Value = curNumberTiming;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData();
                }
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь удалить пустую строку.", "Внимание!");
            }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string numberTiming = dataGridView1[0, indexSelectRow].Value.ToString();
                string numberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
                string nameStaff = dataGridView1[2, indexSelectRow].Value.ToString();
                string nameHall = dataGridView1[3, indexSelectRow].Value.ToString();
                string dateTime = dataGridView1[4, indexSelectRow].Value.ToString();
                string cost = dataGridView1[5, indexSelectRow].Value.ToString();

                myConn.Open();

                // Остальные поля могут иметь значение NULL
                if (numberDogovor.Trim() == "" || nameHall.Trim() == "" || nameStaff.Trim() == "" ||
                    dateTime.Trim() == "" || cost.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("execute update_timing @p1, @p2, @p3, @p4, @p5, @p6", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = numberTiming;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p2"].Value = numberDogovor;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = nameHall;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = nameStaff;

                myComm.Parameters.Add("@p5", SqlDbType.SmallDateTime);
                myComm.Parameters["@p5"].Value = dateTime;

                myComm.Parameters.Add("@p6", SqlDbType.Money);
                myComm.Parameters["@p6"].Value = cost;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n" +
                                " 1. Возможно вы пытаетесь редактировать пустую строку.\n\n" +
                                " 2. Возможно вы установили дату и время некорректно.", "Внимание!");
            }
        }

        private void добавлениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form24 form24 = new Form24();
            form24.ShowDialog();

            // Перезапускаем форму для обновления данных
            this.Hide();
            Form21 form21 = new Form21();
            form21.ShowDialog();
            this.Close();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (curNumberTiming.Trim() == "" || curNumberDogovor.Trim() == "" ||
                    curNameHall.Trim() == "" || curNameStaff.Trim() == "" ||
                    curDateTime.Trim() == "" || curCost.Trim() == "") throw new Exception();

                Form22 form22 = new Form22(curNumberTiming, curNumberDogovor, curNameStaff,
                    curNameHall, curDateTime, curCost);
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

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Номер_договора, CONCAT(Номер_договора, ' - ', Фильм) AS info from dbo.View_Dogovor ORDER BY Номер_договора", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            dogovor_number.DataSource = dtbl; // Источник
            dogovor_number.ValueMember = "Номер_договора"; // Реальное значение
            dogovor_number.DisplayMember = "info"; // Отображаемое значение

            myConn.Close();
        }

        private void loadData()
        {
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select*from dbo.View_Timing", myConn);

            SqlDataReader myReader = myComm.ExecuteReader();
            DataTable dtbl = new DataTable(); dtbl.Load(myReader);

            // Разрешаем нулевые значений каждому элементу (иначе событие DataError)
            dtbl.Columns[0].AllowDBNull = true;
            dtbl.Columns[1].AllowDBNull = true;
            dtbl.Columns[2].AllowDBNull = true;
            dtbl.Columns[3].AllowDBNull = true;
            dtbl.Columns[4].AllowDBNull = true;
            dtbl.Columns[5].AllowDBNull = true;

            dataGridView1.DataSource = dtbl;
            myConn.Close();

            indexSelectRow = 0;
            
            curNumberTiming = dataGridView1[0, indexSelectRow].Value.ToString();
            curNumberDogovor = dataGridView1[1, indexSelectRow].Value.ToString();
            curNameStaff = dataGridView1[2, indexSelectRow].Value.ToString();
            curNameHall = dataGridView1[3, indexSelectRow].Value.ToString();
            curDateTime = dataGridView1[4, indexSelectRow].Value.ToString();
            curCost = dataGridView1[5, indexSelectRow].Value.ToString();
            
        }
    }
}
