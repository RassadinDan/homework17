using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Clients client;
        private AddWindow()
        {
            client = new Clients();
            InitializeComponent();
        }

        public AddWindow(ClientDataEntities1 context1) : this()
        { 
            CancelBut.Click += delegate { this.DialogResult = false; };

            OkBut.Click += delegate
            {
                var c = new
                {
                    Id = context1.Clients.Count<Clients>() + 1,
                    Surname = SurnameBox.Text,
                    Name = NameBox.Text,
                    Midname = MidnameBox.Text,
                    Phone = Convert.ToInt32(PhoneBox.Text),
                    Email = EmailBox.Text
                } ;

                client.Id = c.Id;
                client.Surname = c.Surname;
                client.Name = c.Name;
                client.Midname = c.Midname;
                client.Phone = c.Phone;
                client.Email = c.Email;
                context1.Clients.Add(client);
                this.DialogResult = true;
            };

        }
    }
}
