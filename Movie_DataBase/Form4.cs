using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form4 : Form
    {
        SqlConnection myConn;
        public Form4(SqlConnection myConn)
        {
            InitializeComponent();
            this.myConn = myConn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text.Trim() == "") throw new Exception();

                // Создать команду для добавления
                SqlCommand myComm = new SqlCommand("execute add_prokatchik @p1", myConn);

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = text1.Text.ToString();

                // Вызвать процедуру без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Возможно вы ввели пустую строку", "Внимание!"); }

        }
    }
}
