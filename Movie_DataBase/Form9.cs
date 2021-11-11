using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form9 : Form
    {
        SqlConnection myConn = new SqlConnection();
        int indexSelectRow;
        SqlCommand myComm = new SqlCommand("select*from dbo.Жанр");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Открываем соединение
            Program.openConnection(myConn);

            // Выборка создания и заполнения в DataSet таблицы с жанрами
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Жанр");

            dataGridView1.Columns[0].ReadOnly = true; // блокируем изменение id
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Жанр"];
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelectRow = e.RowIndex;
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConn.Close();
            Application.Exit();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Program.returnToStartForm();
            Close();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о жанре. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { MessageBox.Show("Почему-то вызвалось исключение. Выполните двойной щелчок по названию жанра", "Внимание!"); }
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Жанр"].Rows.Add();
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {  
                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Жанр"]);
            }
            catch { MessageBox.Show("Необходимо заполнить добавленную строку", "Внимание!"); }
        }

    }
}
