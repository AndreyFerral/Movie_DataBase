using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            cmbTypeAutor.Items.Add("Проверка подлинности Windows");
            cmbTypeAutor.Items.Add("Проверка подлинности SQL Server");

            txtUserName.Enabled = false;
            txtPass.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                string StrConn;
                if (cmbTypeAutor.SelectedIndex == 0) {
                    StrConn = "Data Source =" + txtNameSrv.Text + ";Initial Catalog =" + txtNameDB.Text + ";Integrated Security = True";
                }
                else {
                    StrConn = "Data Source =" + txtNameSrv.Text + ";Initial Catalog =" + txtNameDB.Text + ";User ID =" + txtUserName.Text + ";Password =" + txtPass.Text;
                }

                // Создание нового подключения на основе строки
                SqlConnection MainConn = new SqlConnection(StrConn);
                MainConn.Open(); //Открытие подключения
                                 // Проверка, установлено ли соединение с БД
                if (MainConn.State == ConnectionState.Open) {
                    // Если подключение прошло успешно,
                    // сохраняем строку в параметры 
                    Properties.Settings.Default.ConnStr = StrConn; 
                    MainConn.Close();
                    // Переходим на следующую форму

                    Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    Close();
                }
                // Если подключение не установлено, то выводим сообщение
                else {
                    MessageBox.Show("Соединение с БД не установлено", "Внимание!");
                }
            }
            // пустые поля, либо неправильные, либо на компьютере нет сервера
            catch { MessageBox.Show("Невозможно подключиться к базе данных", "Внимание!"); }
        }

        private void cmbTypeAutor_SelectionChangeCommitted(object sender, EventArgs e) {
            if (cmbTypeAutor.SelectedIndex != 0) {
                txtUserName.Enabled = true; 
                txtPass.Enabled = true;
            }
            else {
                txtUserName.Enabled = false; 
                txtPass.Enabled = false;
            }

        }
    }
}
