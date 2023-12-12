using CarShopManager.Repository;
using CarShopManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        DatabaseContext databaseContext = new();
        public Clients()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListClients();
        }
        private void delete_client(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                List<Client> clients = databaseContext.Clients.ToList();
                string row = ClientsGrid.SelectedCells.FirstOrDefault().Item.ToString();
                Client selectedClient = clients.FirstOrDefault(c => c.Id == GetSelectedId(row));
                List<Contract> contracts = databaseContext.Contracts.Where(t => t.ClientId == selectedClient.Id).ToList();
                foreach (Contract contract in contracts)
                {
                    databaseContext.Contracts.Remove(contract);
                }
                databaseContext.Clients.Remove(selectedClient);
                databaseContext.SaveChanges();
                ListClients();

            }

        }
        private void refresh(object sender, EventArgs e)
        {
            ListClients();
        }
        private void update_client(object sender, EventArgs e)
        {
            string row = ClientsGrid.SelectedCells.FirstOrDefault().Item.ToString();

            UpdateClient updateClient = new UpdateClient(GetSelectedId(row));
            updateClient.Show();
        }
        public void ListClients()
        {
            ClientsGrid.ItemsSource = "";
            var query =
            from Client in databaseContext.Clients
            select new { Client.Id, Client.ClientName, Client.ClientSurname, Client.ClientDateOfBirth, Client.ClientEmail, Client.ClientPhoneNumber, Client.ClientIdNumber, Client.ClientGender};

            ClientsGrid.ItemsSource = query.ToList();

            ClientsGrid.Columns[0].Header = "ID";
            ClientsGrid.Columns[1].Header = "Name";
            ClientsGrid.Columns[2].Header = "Surname";
            ClientsGrid.Columns[3].Header = "Birthdate";
            ClientsGrid.Columns[4].Header = "Email";
            ClientsGrid.Columns[5].Header = "Phone";
            ClientsGrid.Columns[6].Header = "ID";
            ClientsGrid.Columns[7].Header = "Gender";
        }
        private int GetSelectedId(string row)
        {
            string s = Regex.Match(row, "Id = (.*), ClientName =").Groups[1].Value;
            int idSelected = -1;
            Int32.TryParse(s, out idSelected);
            return idSelected;
        }

        private void insert_client(object sender, RoutedEventArgs e)
        {
            InsertClient insertClient = new InsertClient();
            insertClient.Show();
        }

        private void switch_to_cars(object sender, RoutedEventArgs e)
        {
            MainWindow cars = new MainWindow();
            cars.Show();
            this.Close();
        }
    }
}
