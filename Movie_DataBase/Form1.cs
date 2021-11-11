using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cmbTypeAutor.Items.Add("Проверка подлинности Windows");
            cmbTypeAutor.Items.Add("Проверка подлинности SQL Server");
            txtUserName.Enabled = false;
            txtPass.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            try 
            {
                string StrConn;

                if (cmbTypeAutor.SelectedIndex == 0) {
                    StrConn = "Data Source =" + txtNameSrv.Text + ";Initial Catalog =" + txtNameDB.Text + ";Integrated Security = True";
                }
                else {
                    StrConn = "Data Source =" + txtNameSrv.Text + ";Initial Catalog =" + txtNameDB.Text + ";User ID =" + txtUserName.Text + ";Password =" + txtPass.Text;
                }

                SqlConnection MainConn = new SqlConnection(StrConn); // Создание нового подключения на основе строки    
                MainConn.Open(); // Открытие подключения
                
                // Проверка, установлено ли соединение с БД
                if (MainConn.State == ConnectionState.Open) 
                {
                    // Если подключение прошло успешно, то сохраняем строку в параметры 
                    Properties.Settings.Default.ConnStr = StrConn;

                    // Program.getCurrentUser(MainConn);

                    MainConn.Close();

                    // Переходим на следующую форму в зависимости от логина
                    if (txtUserName.Text == "Moderator_Second" || txtUserName.Text == "Mod_Second")
                    {
                        // Устанавливаем стартовую форму для модератора второго уровня
                        Properties.Settings.Default.StartForm = 1;
                    }

                    Hide();
                    Program.returnToStartForm();
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

            // Если выбрана аутентификация по пользователю Windows
            if (cmbTypeAutor.SelectedIndex == 0) {

                txtUserName.Text = "";
                txtUserName.Enabled = false;

                txtPass.Text = "";
                txtPass.Enabled = false;

                // Роль приложения не будет активирована
                Properties.Settings.Default.IsRoleApp = false;

            }
            // Если выбрана аутентификация по логину и паролю
            else
            {
                txtUserName.Enabled = true;
                txtPass.Enabled = true;

                // Следовательно, необходимо будет активировать роль приложения
                Properties.Settings.Default.IsRoleApp = true;
            }

        }
    }
}
