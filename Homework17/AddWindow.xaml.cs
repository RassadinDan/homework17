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
        private AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(DataRow row) : this()
        {
            CancelBut.Click += delegate { this.DialogResult = false; };

            OkBut.Click += delegate
            {
                row["Surname"] = SurnameBox.Text;
                row["Name"] = NameBox.Text;
                row["Midname"] = MidnameBox.Text;
                row["Phone"] = PhoneBox.Text;
                row["Email"] = EmailBox.Text;
                this.DialogResult = true;
            };

        }
    }
}
