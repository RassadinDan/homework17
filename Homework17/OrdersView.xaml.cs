using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace Homework17
{
    /// <summary>
    /// Логика взаимодействия для OrdersView.xaml
    /// </summary>
    public partial class OrdersView : Window
    {
        OrdersEntities context2;
        string email;
        public OrdersView(string email)
        {
            this.email = email;
            InitializeComponent();
            Preparing();
        }

        private void Preparing()
        {
            context2= new OrdersEntities();
            context2.OrderList.Load();
            Data2.DataContext = context2.OrderList.Local.Where(o => o.email == email);
        }
    }
}
