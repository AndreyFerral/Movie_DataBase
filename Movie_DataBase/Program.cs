using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_DataBase
{
    static class Program
    {
        public static void openConnection(SqlConnection connection)
        {
            // Получаем данные из параметров
            string strConn = Properties.Settings.Default.ConnStr.ToString();
            bool isAppRole = Properties.Settings.Default.IsRoleApp;
            string roleApp = Properties.Settings.Default.RoleApp.ToString();

            // Создаем подключение 
            connection.ConnectionString = strConn;
            connection.Open();

            SqlCommand cmd = new SqlCommand(roleApp, connection);

            // Если была выбрана авторизация по пользователю, то необходимо активировать роль приложения
            if (isAppRole)
            {
                // Запускаем роль приложения
                cmd.ExecuteNonQuery();
            }

            cmd.Cancel();

        }

        public static void returnToStartForm()
        {
            switch (Properties.Settings.Default.StartForm)
            {
                case 0:
                    {
                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                    }
                    break;
                case 1:
                    {
                        Moderator_Second ms = new Moderator_Second();
                        ms.ShowDialog();
                    }
                    break;
                default:
                    {
                        MessageBox.Show(
                            "Невозможно перейти на предыдущю форму",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        public static void getCurrentUser(SqlConnection connection)
        {
            // Выполняем команду по просмотру пользователя
            SqlCommand command = new SqlCommand("SELECT CURRENT_USER", connection);
            SqlDataReader reader = command.ExecuteReader();
            string data = "";

            // Получаем результат
            while (reader.Read()) { data = reader[0].ToString(); }

            // Закрываем SqlDataReader
            reader.Close();

            // Выводим текущего пользователя посредством сообщения
            MessageBox.Show(
                "Текущий пользователь - " + data,
                "Получение текущего пользователя",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
