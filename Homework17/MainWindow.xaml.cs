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

namespace Homework17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable table;
        DataRowView row;

        public MainWindow()
        {

            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"ClientData",
                IntegratedSecurity = true,
                Pooling = false
            };

            connection = new SqlConnection() { ConnectionString = strCon.ConnectionString };

            Authentication login = new Authentication(strCon);
            login.ShowDialog();

            InitializeComponent(); 
            Preparing();

            conStr.Text = $"Connection string:{strCon.ConnectionString} Connection state:{connection.State}";

            #region mbwn
            //try
            //{
            //    connection.Open();
            //    Debug.WriteLine($"Connection string:{connection.ConnectionString}\nConnection state:{connection.State}");
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //    Debug.WriteLine($"{connection.State}");
            //}
            ////finally { connection.Close(); }
            ////Debug.WriteLine($"Connection state:{connection.State}");
            #endregion
        }
        private void Preparing()
        {
            table= new DataTable();
            adapter = new SqlDataAdapter();

            var sql = @"SELECT * FROM Clients ORDER BY Clients.Id";
            adapter.SelectCommand = new SqlCommand(sql, connection);

            sql = @"INSERT INTO Clients (Surname, Name, Midname, Phone, Email)
                            VALUES(@Surname, @Name, @Midname, @Phone, @Email);
                    SET @Id = @@IDENTITY;";
            adapter.InsertCommand= new SqlCommand(sql, connection);
            adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
            adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 30, "Surname");
            adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 30, "Name");
            adapter.InsertCommand.Parameters.Add("@Midname", SqlDbType.NVarChar, 30, "Midname");
            adapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.Int, 6, "Phone");
            adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");

            sql = @"UPDATE Clients SET
                           Surname = @Surname,
                           Name = @Name,
                           Midname = @Midname,
                           Phone = @Phone,
                           Email = @Email
                    WHERE Id = @Id;";
            adapter.UpdateCommand= new SqlCommand(sql, connection);
            adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 30, "Surname");
            adapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 30, "Name");
            adapter.UpdateCommand.Parameters.Add("@Midname", SqlDbType.NVarChar, 30, "Midname");
            adapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.Int, 6, "Phone");
            adapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");

            sql = @"DELETE FROM Clients WHERE Id = @Id";
            adapter.DeleteCommand= new SqlCommand(sql, connection);
            adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");

            adapter.Fill(table);
            Data.DataContext= table.DefaultView;
        }

        private void DGCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            row = (DataRowView)Data.SelectedItem;
            row.BeginEdit();
        }

        private void DGCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            adapter.Update(table);
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = table.NewRow();
            AddWindow add = new AddWindow(r);
            add.ShowDialog();


            if (add.DialogResult.Value == true)
            {
                table.Rows.Add(r);
                adapter.Update(table);
            }
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)Data.SelectedItem;
            row.Row.Delete();
            adapter.Update(table);
        }

        private void MenuItemViewClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)Data.SelectedItem;
            string email = Convert.ToString((Email.GetCellContent(row) as TextBlock).Text);
            OrdersView orders = new OrdersView(email);
            orders.ShowDialog();
        }
    }
}
