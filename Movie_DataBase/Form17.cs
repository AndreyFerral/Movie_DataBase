using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form17 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select*from dbo.Билетик");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            // Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();

            // Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();

            loadDataComboBox();

            // Выборка создания и заполнения в DataSet таблицы
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Билетик");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Билетик"];
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Билетик"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о билете. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { MessageBox.Show("Почему-то вызвалось исключение", "Внимание!"); }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Билетик"]);

                // Очищаем таблицу
                ds.Clear();

                // Заполняем таблицу
                sda.Fill(ds, "Билетик");
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n" +
                " 1. Необходимо заполнить добавленную строку.\n\n" +
                " 2. Номер расписания отсутствует в базе данных.\n\n" +
                " 3. Номер ряда или места превышает вместимость зала.", "Внимание!");
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dataGridView1.Rows[indexSelectRow];
            string numberRyad = SelectedRow.Cells[0].Value.ToString();
            string numberMesto = SelectedRow.Cells[1].Value.ToString();
            string numberTiming = SelectedRow.Cells[2].Value.ToString();

            Form18 form18 = new Form18(numberRyad, numberMesto, numberTiming);
            form18.ShowDialog();
        }

        private void loadDataComboBox()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("select idРасписание, " +
                "CONCAT(idРасписание, ' - ', CONVERT(nvarchar(100), Дата_время, 4), ' ', " +
                "CONVERT(nvarchar(100), Дата_время, 8),' - ', Фильм) AS info " +
                "from dbo.View_TicketInfo ORDER BY idРасписание", myConn);

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            timing.DataSource = dtbl; // Источник
            timing.ValueMember = "idРасписание"; // Реальное значение
            timing.DisplayMember = "info"; // Отображаемое значение
        }
    }
}
