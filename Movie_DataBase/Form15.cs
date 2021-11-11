using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form15 : Form
    {
        SqlConnection myConn = new SqlConnection();
        SqlCommand myComm = new SqlCommand("select*from Сотрудник");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // Открываем соединение
            Program.openConnection(myConn);

            // Выборка создания и заполнения в DataSet таблицы
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Сотрудник");

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Сотрудник"];
            dataGridView1.Refresh();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Сотрудник"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о сотруднике. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch {
                MessageBox.Show("Почему-то вызвалось исключение", "Внимание!"); 
            }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Сотрудник"]);

                // Очищаем таблицу
                ds.Clear();

                // Заполняем таблицу
                sda.Fill(ds, "Сотрудник");
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                " 1. Необходимо заполнить добавленную строку.\n\n " +
                " 2. Необходимо ввести уникальный номер, состоящий из 6 цифр.\n\n", "Внимание!");
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Program.returnToStartForm();
            Close();
        }
    }
}
