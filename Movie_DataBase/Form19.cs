using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form19 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        string curNumberDogovor, curNameStaff, curNameFilm, curNameDistrib, 
            curDateDogovor, curDateProkat, curWeek, curCost;

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
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

                curNumberDogovor = dataGridView1[0, indexSelectRow].Value.ToString();
                curNameStaff = dataGridView1[1, indexSelectRow].Value.ToString();
                curNameFilm = dataGridView1[2, indexSelectRow].Value.ToString();
                curNameDistrib = dataGridView1[3, indexSelectRow].Value.ToString();
                curDateDogovor = dataGridView1[4, indexSelectRow].Value.ToString();
                curDateProkat = dataGridView1[5, indexSelectRow].Value.ToString();
                curWeek = dataGridView1[6, indexSelectRow].Value.ToString();
                curCost = dataGridView1[7, indexSelectRow].Value.ToString();
            }
        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Можно добавить бросание исключений на количество недель и даты

            try
            {
                indexSelectRow = dataGridView1.Rows.Count - 2;
                string NameStaff = dataGridView1[1, indexSelectRow].Value.ToString();
                string NameFilm = dataGridView1[2, indexSelectRow].Value.ToString();
                string NameDistrib = dataGridView1[3, indexSelectRow].Value.ToString();
                string DateDogovor = dataGridView1[4, indexSelectRow].Value.ToString();
                string DateProkat = dataGridView1[5, indexSelectRow].Value.ToString();
                string Week = dataGridView1[6, indexSelectRow].Value.ToString();
                string Cost = dataGridView1[7, indexSelectRow].Value.ToString();

                myConn.Open();

                // Остальные поля могут иметь значение NULL
                if (NameStaff.Trim() == "" || NameFilm.Trim() == "" || 
                    NameDistrib.Trim() == "" || Cost.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("execute add_prokat_distrib_film_staff @p1, @p2, @p3, @p4, @p5, @p6, @p7", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.Date);
                myComm.Parameters["@p1"].Value = DateDogovor;

                myComm.Parameters.Add("@p2", SqlDbType.Date);
                myComm.Parameters["@p2"].Value = DateProkat;

                myComm.Parameters.Add("@p3", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p3"].Value = Week;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = Cost;

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = NameDistrib;

                myComm.Parameters.Add("@p6", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p6"].Value = NameFilm;

                myComm.Parameters.Add("@p7", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p7"].Value = NameStaff;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь добавить пустую строку.", "Внимание!");
            }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Информация о прокате фильма будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    myConn.Open();
                    if (curNumberDogovor == "") throw new Exception();

                    // Создать команду для удаления
                    SqlCommand myComm = new SqlCommand("execute delete_prokat @p1", myConn);

                    // Создать параметр и передать в него значение текстового поля 
                    myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 10);
                    myComm.Parameters["@p1"].Value = curNumberDogovor;

                    // Выполнить запрос на удаление без возвращения результата
                    myComm.ExecuteReader();
                    myConn.Close();

                    // Обновляем содержимое 
                    loadData();
                }
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь удалить пустую строку.", "Внимание!");
            }
        }

        private void добавлениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();
            form23.ShowDialog();

            // Перезапускаем форму для обновления данных
            this.Hide();
            Form19 form19 = new Form19();
            form19.ShowDialog();
            this.Close();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (curNumberDogovor.Trim() == "" || curNameStaff.Trim() == "" ||
                    curNameFilm.Trim() == "" || curNameDistrib.Trim() == "" ||
                    //curDateDogovor.Trim() == "" || curDateProkat.Trim() == "" || curWeek.Trim() == "" || 
                    curCost.Trim() == "") throw new Exception();

                Form20 form20 = new Form20(curNumberDogovor, curNameStaff, curNameFilm, 
                    curNameDistrib, curDateDogovor, curDateProkat, curWeek, curCost);

                form20.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                                "1. Возможно вы пытаетесь посмотреть информацию о несуществующих данных.", "Внимание!");
            }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string NumberDogovor = dataGridView1[0, indexSelectRow].Value.ToString();
                string NameStaff = dataGridView1[1, indexSelectRow].Value.ToString();
                string NameFilm = dataGridView1[2, indexSelectRow].Value.ToString();
                string NameDistrib = dataGridView1[3, indexSelectRow].Value.ToString();
                string DateDogovor = dataGridView1[4, indexSelectRow].Value.ToString();
                string DateProkat = dataGridView1[5, indexSelectRow].Value.ToString();
                string Week = dataGridView1[6, indexSelectRow].Value.ToString();
                string Cost = dataGridView1[7, indexSelectRow].Value.ToString();
                Cost = Cost.Substring(0, Cost.LastIndexOf(',')); // удаляем лишние знаки

                myConn.Open();
                if (NumberDogovor.Trim() == "" || NameStaff.Trim() == "" ||
                    NameFilm.Trim() == "" || NameDistrib.Trim() == "" ||
                    //DateDogovor.Trim() == "" || DateProkat.Trim() == "" || Week.Trim() == "" || 
                    Cost.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("execute update_prokat @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = NumberDogovor;

                myComm.Parameters.Add("@p2", SqlDbType.Date);
                myComm.Parameters["@p2"].Value = DateDogovor;

                myComm.Parameters.Add("@p3", SqlDbType.Date);
                myComm.Parameters["@p3"].Value = DateProkat;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = Week;

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = Cost;

                myComm.Parameters.Add("@p6", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p6"].Value = NameDistrib;

                myComm.Parameters.Add("@p7", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p7"].Value = NameFilm;

                myComm.Parameters.Add("@p8", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p8"].Value = NameStaff;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
                myConn.Close();

                // Обновляем содержимое 
                loadData();
            }
            catch { myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n" +
                                " 1. Возможно вы пытаетесь редактировать пустую строку.\n\n" +
                                " 2. Возможно вы установили количество недель не в диапазоне 1-2.\n\n" +
                                " 3. Возможно вы установили дату проката меньше даты договора.", "Внимание!");
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
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

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Фильм", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            film_name.DisplayMember = "Название";
            film_name.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData3ComboBox()
        {
            myConn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select Название from Прокатчик", myConn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            distrib_name.DisplayMember = "Название";
            distrib_name.DataSource = dtbl;

            myConn.Close();
        }

        private void loadData()
        {
            myConn.Open();
            SqlCommand myComm = new SqlCommand("select Номер_договора, ФИО, Фильм, Прокатчик, Дата_договора, Дата_проката, Количество_недель, Стоимость from dbo.View_Dogovor", myConn);

            SqlDataReader myReader = myComm.ExecuteReader();
            DataTable dtbl = new DataTable(); dtbl.Load(myReader);

            // Разрешаем нулевые значений каждому элементу (иначе событие DataError)
            dtbl.Columns[0].AllowDBNull = true;
            dtbl.Columns[1].AllowDBNull = true;
            dtbl.Columns[2].AllowDBNull = true;
            dtbl.Columns[3].AllowDBNull = true;
            dtbl.Columns[4].AllowDBNull = true;
            dtbl.Columns[5].AllowDBNull = true;
            dtbl.Columns[6].AllowDBNull = true;
            dtbl.Columns[7].AllowDBNull = true;

            dataGridView1.DataSource = dtbl;
            myConn.Close();

            indexSelectRow = 0;

            curNumberDogovor = dataGridView1[0, indexSelectRow].Value.ToString();
            curNameStaff = dataGridView1[1, indexSelectRow].Value.ToString();
            curNameFilm = dataGridView1[2, indexSelectRow].Value.ToString();
            curNameDistrib = dataGridView1[3, indexSelectRow].Value.ToString();
            curDateDogovor = dataGridView1[4, indexSelectRow].Value.ToString();
            curDateProkat = dataGridView1[5, indexSelectRow].Value.ToString();
            curWeek = dataGridView1[6, indexSelectRow].Value.ToString();
            curCost = dataGridView1[7, indexSelectRow].Value.ToString();
        }

    }
}
