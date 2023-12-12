using CarShopManager.Repository;
using CarShopManager.Repository.Models;
using System;
using System.Collections.Generic;
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

namespace CarShopManager
{
    /// <summary>
    /// Interaction logic for InsertClient.xaml
    /// </summary>
    public partial class InsertClient : Window
    {
        DatabaseContext databaseContext = new();
        public InsertClient()
        {
            InitializeComponent();
        }

        private void insert_client_apply(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to inset this item?", "Insert", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                Client client = new Client
                {
                    ClientIdNumber = IDNumber.Text,
                    ClientDateOfBirth = DateTime.Parse(DateOfBirth.Text).Date,
                    ClientEmail = Email.Text,
                    ClientGender = Gender.Text,
                    ClientName = Name.Text,
                    ClientPhoneNumber = Phone.Text,
                    ClientSurname = Surname.Text
                };
                databaseContext.Clients.Add(client);
                databaseContext.SaveChanges();
                MessageBox.Show("Insert successful!", "Insert", MessageBoxButton.OKCancel);
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ID.Text = String.Empty;
            Name.Text = String.Empty;
            Surname.Text = String.Empty;
            Email.Text = String.Empty;
            Phone.Text = String.Empty;
            Gender.Text = String.Empty;
            Email.Text = String.Empty;
            IDNumber.Text = String.Empty;
        }
    }
}
