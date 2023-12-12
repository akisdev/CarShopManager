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
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class UpdateClient : Window
    {
        int clientID;
        DatabaseContext databaseContext = new();
        public UpdateClient(int id)
        {
            clientID = id;
            InitializeComponent();
        }

        private void update_client_apply(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the selected item?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                ID.Text = clientID.ToString();
                List<Client> clients = databaseContext.Clients.ToList();
                Client selectedClient = clients.FirstOrDefault(c => c.Id == clientID);
                databaseContext.Remove(selectedClient);
                Client client = new Client { Id = clientID, ClientName = Name.Text, ClientDateOfBirth = Convert.ToDateTime(DateOfBirth.Text).Date, ClientEmail = Email.Text, ClientGender = Gender.Text, ClientIdNumber = IDNumber.Text, ClientPhoneNumber = Phone.Text, ClientSurname = Surname.Text};
                databaseContext.Clients.Add(client);
                databaseContext.SaveChanges();
                MessageBox.Show("Update successful!", "Update", MessageBoxButton.OKCancel);
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ID.Text = clientID.ToString();
            List<Client> clients = databaseContext.Clients.ToList();
            Client selectedClient = clients.FirstOrDefault(c => c.Id == clientID);
            Name.Text = selectedClient.ClientName;
            Surname.Text = selectedClient.ClientSurname;
            Email.Text = selectedClient.ClientEmail;
            Phone.Text = selectedClient.ClientPhoneNumber;
            Gender.Text = selectedClient.ClientGender;
            IDNumber.Text = selectedClient.ClientIdNumber;
            DateOfBirth.Text = selectedClient.ClientDateOfBirth.ToString();
        }
    }
}
