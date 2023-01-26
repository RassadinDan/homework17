using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Homework17
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public SqlConnectionStringBuilder connectionString;
        public Authentication(SqlConnectionStringBuilder connectionString)
        {
            this.connectionString = connectionString;

            InitializeComponent();


        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string sql = $@"SELECT * FROM LogIn WHERE [Email] = '{Login.Text}'";

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader sqlData = command.ExecuteReader();
                string email;
                string password;

                if (sqlData.HasRows)
                {
                    while(sqlData.Read()) 
                    {
                        email = sqlData.GetString(1);
                        password = sqlData.GetString(2);
                        Debug.WriteLine($"{email}, {password}");

                        if (Password.Password != password)
                        {
                            //this.DialogResult = fslse;
                            MessageBox.Show("Неверно введен пароль", "Ошибка", MessageBoxButton.OK);
                        }
                        else
                        {
                            this.DialogResult = true;
                        }
                        
                    }
                }
                sqlData.Close();
            }
        }
    }
}
