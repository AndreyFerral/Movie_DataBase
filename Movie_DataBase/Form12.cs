using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Form12 : Form
    {
        SqlConnection myConn = new SqlConnection();
        string numberFilm, nameFilm, description, howmuch;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand myComm;

                // Если оба не поля не заполнены
                if (text5.Text.Trim() == "" && text6.Text.Trim() == "") { throw new Exception(); }
                // Если не заполнено поле "Жанр"
                else if (text5.Text.Trim() == "") {
                    myComm = new SqlCommand("execute add_film_filmm_genre @filmName = @p1, @description = @p2, @length = @p3, @filmMaker = @p4", myConn);

                    myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p4"].Value = text5.Text.ToString();
                }

                // Если не заполнено поле "Режиссер"
                else if (text6.Text.Trim() == "") {
                    myComm = new SqlCommand("execute add_film_filmm_genre @filmName = @p1, @description = @p2, @length = @p3, @filmGenre = @p5", myConn);

                    myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p5"].Value = text6.Text.ToString();
                }
                // Если заполнены оба поля
                else {
                    myComm = new SqlCommand("execute add_film_filmm_genre @p1, @p2, @p3, @p4, @p5", myConn);

                    myComm.Parameters.Add("@p4", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p4"].Value = text5.Text.ToString();

                    myComm.Parameters.Add("@p5", SqlDbType.NVarChar, 100);
                    myComm.Parameters["@p5"].Value = text6.Text.ToString();
                }

                // Создать параметр и передать в него значение текстового поля 
                myComm.Parameters.Add("@p1", SqlDbType.NVarChar, 100);
                myComm.Parameters["@p1"].Value = nameFilm;

                myComm.Parameters.Add("@p2", SqlDbType.NVarChar, 300);
                myComm.Parameters["@p2"].Value = description;

                myComm.Parameters.Add("@p3", SqlDbType.Int);
                myComm.Parameters["@p3"].Value = howmuch;

                // Вызвать процедуру без возвращения результата
                myComm.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Исключение: Минимум одно поле должно быть заполнено", "Внимание!"); }
        }

        public Form12(string numberFilm, string nameFilm, string description, string howmuch)
        {
            InitializeComponent();
            // задание значения параметрам
            this.numberFilm = numberFilm;
            this.nameFilm = nameFilm;
            this.description = description;
            this.howmuch = howmuch;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            //Получаем строку подключения из параметров
            string StrConn = Properties.Settings.Default.ConnStr.ToString();
            //Создаем подключение 
            myConn.ConnectionString = StrConn;
            myConn.Open();
            //Запускаем процедуру выборки данных

            text2.Text = nameFilm;
            text3.Text = description;
            text4.Text = howmuch;
        }
    }
}
