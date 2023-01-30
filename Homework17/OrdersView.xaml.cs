using System;
using System.Collections.Generic;
using System.Data;
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
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable table;
        string email;
        public OrdersView(string email)
        {
            this.email = email;
            InitializeComponent();
            Preparing();
        }

        private void Preparing()
        {
            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"Orders",
                IntegratedSecurity = true,
                Pooling = false
            };

            connection = new SqlConnection(strCon.ConnectionString);
            table = new DataTable();
            adapter = new SqlDataAdapter();

            var sql = $@"SELECT * FROM OrderList
                        WHERE [email] = '{email}'
                        ORDER BY OrderList.Id;";
            adapter.SelectCommand = new SqlCommand(sql, connection);

            adapter.Fill(table);
            Data2.DataContext = table.DefaultView;
        }
    }
}
