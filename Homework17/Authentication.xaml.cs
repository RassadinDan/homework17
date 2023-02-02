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
using System.Data.Entity;

namespace Homework17
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        private ClientDataEntities1 context;
        public Authentication(ClientDataEntities1 context)
        {
            this.context = context;

            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string email = Login.Text;
            string password = Password.Password;
            context.LogIn.Load();

            foreach(var item in context.LogIn)
            {
                if (item.Email == email && item.Password == password) 
                {
                    DialogResult = true; break;
                }
            }
        }
    }
}
