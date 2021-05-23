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
    public partial class Form8 : Form
    {
        SqlConnection myConn;
        public Form8(SqlConnection myConn)
        {
            InitializeComponent();
            this.myConn = myConn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text.Trim() == "" || text2.Text.Trim() == "" || text3.Text.Trim() == "" || text4.Text.Trim() == "" || text5.Text.Trim() == "") throw new Exception();

                //Создать команду для добавления
                SqlCommand myComm = new SqlCommand("execute add_film_filmm_genre @p1, @p2, @p3, @p4, @p5", myConn);
                //Создать параметр и передать в него значение текстового поля 

                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = text1.Text.ToString();

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = text2.Text.ToString();

                myComm.Parameters.Add("@p3", SqlDbType.Int);
                myComm.Parameters["@p3"].Value = text3.Text;

                myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p4"].Value = text4.Text.ToString();

                myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p5"].Value = text5.Text.ToString();

                //вызвать процедуру без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Все поля должны быть заполнены", "Внимание!"); }
        }
    }
}
