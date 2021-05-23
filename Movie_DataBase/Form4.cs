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
            // задание значения параметру
            this.myConn = myConn;
        }
            
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Создать команду для добавления
                SqlCommand myComm = new SqlCommand("Exec [dbo].[add_prokatchik] @name = @p1", myConn);
                //Создать параметр и передать в него значение текстового поля 
                if (text1.Text.Trim() == "") throw new Exception();
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = text1.Text.ToString();
                //вызвать процедуру без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Возможно вы ввели пустую строку", "Внимание!"); }

        }

        private void text1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
