using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form7 : Form
    {
        SqlConnection myConn;
        string numberGenre, nameGenre;
        public Form7(SqlConnection myConn, string numberGenre, string nameGenre) {
            InitializeComponent();
            this.myConn = myConn;
            this.numberGenre = numberGenre;
            this.nameGenre = nameGenre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() == "") throw new Exception();

                // Создать команду для изменения
                SqlCommand myComm = new SqlCommand("UPDATE dbo.Прокатчик SET Название = @p1 where idПрокатчик = @p2", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = textBox2.Text;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 10);
                myComm.Parameters["@p2"].Value = numberGenre;

                // Выполнить запрос на изменение без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Возможно вы ввели пустую строку", "Внимание!"); }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Text = numberGenre;
            textBox2.Text = nameGenre;
        }
    }
}
