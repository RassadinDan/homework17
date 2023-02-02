using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Markup;

namespace Homework17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientDataEntities1 context1;

        public MainWindow()
        {
            context1 = new ClientDataEntities1();
            Authentication login = new Authentication(context1);
            login.ShowDialog();
            var clients = context1.Clients.Local.ToBindingList();

            InitializeComponent(); 
            Preparing();
        }

        private void Preparing()
        {
            context1.Clients.Load();
            Data.DataContext = context1.Clients.Local;
        }

        private void DGCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //var item = (Clients)Data.SelectedItem;
            //row.BeginEdit();
        }

        private void DGCurrentCellChanged(object sender, EventArgs e)
        {
            context1.SaveChanges();
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow(context1);
            add.ShowDialog();


            if (add.DialogResult.Value == true)
            {
                context1.SaveChanges();
            }
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            var item = Data.SelectedItem;
            Clients client = item as Clients;
            context1.Clients.Remove(client);
            context1.SaveChanges();
        }

        private void MenuItemViewClick(object sender, RoutedEventArgs e)
        {
            var item = Data.SelectedItem;
            string email = Convert.ToString((Email.GetCellContent(item) as TextBlock).Text);
            OrdersView orders = new OrdersView(email);
            orders.ShowDialog();
        }
    }
}
