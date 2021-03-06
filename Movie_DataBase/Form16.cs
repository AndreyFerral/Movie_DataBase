using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form16 : Form
    {
        SqlConnection myConn = new SqlConnection();
        SqlCommand myComm = new SqlCommand("select*from Зал");
        SqlDataAdapter sda = new SqlDataAdapter(); DataSet ds = new DataSet();

        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // Открываем соединение
            Program.openConnection(myConn);

            // Выборка создания и заполнения в DataSet таблицы
            myComm.Connection = myConn;
            sda.SelectCommand = myComm;
            sda.Fill(ds, "Зал");

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables["Зал"];
            dataGridView1.Refresh();
            myConn.Close();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ds.Tables["Зал"].Rows.Add();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Будет удалена вся информация о зале. Продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch 
            {
                MessageBox.Show("Почему-то вызвалось исключение", "Внимание!"); 
            }
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myConn.Open();

                // Создаем команды манипулирования данными
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.GetUpdateCommand(); scb.GetDeleteCommand(); scb.GetInsertCommand();

                // Отправляем изменения в БД
                sda.Update(ds.Tables["Зал"]);

                // Очищаем таблицу
                ds.Clear();

                // Заполняем таблицу
                sda.Fill(ds, "Зал"); 

                myConn.Close();
                
            }
            catch
            {
                myConn.Close();
                MessageBox.Show("Ошибка. Возможное решение:\n\n " +
                " 1. Необходимо заполнить добавленную строку.\n\n " +
                " 2. Количество рядов и мест должно находиться\n" +
                "   в диапазоне от 1 до 20\n\n" +
                " 3. Возможно данный зал используется в других таблицах", "Внимание!");
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
